using System;
using System.Linq;
using System.Web.UI;

using Microsoft.Ajax.Utilities;

using ZahediPal.Net.Integration.Core;
using ZahediPal.Net.Integration.Core.Endpoint;
using ZahediPal.Net.Integration.Core.Endpoint.Parameters;
using ZahediPal.Net.Integration.Core.Helpers;
using ZahediPal.Net.Integration.Core.Storage;
using ZahediPal.Net.Integration.Core.Storage.Entities;

namespace ZahediPal.Net.Integration.WebForms {
    public partial class Default : Page {
        protected void Page_Load(object sender, EventArgs e) {
            VerifyTransaction();
            BindTransactions();
        }

        private void VerifyTransaction() {
            var transactionId = Request.Form["transid"];
            if (string.IsNullOrEmpty(transactionId))
                return;

            var newTransaction = TransactionProvider.Current.GetTransaction(transactionId);
            if (newTransaction == null)
                Message.InnerHtml = UiHelpers.AsError("تراکنش مورد نظر یافت نشد!");
            else {
                var isSucceeded = HttpHelpers.VerifyTransaction(new VerifyTransactionRequest {
                    Pin = newTransaction.Pin,
                    Amount = newTransaction.Amount,
                    TransId = newTransaction.TransactionId
                });
                newTransaction.Result = isSucceeded ? PaymentOpResult.Succeeded : PaymentOpResult.Failed;

                if (isSucceeded)
                    Message.InnerHtml = UiHelpers.AsSuccess("تراکنش موفقیت آمیز بود.");
                else
                    Message.InnerHtml = UiHelpers.AsError("تراکنش ناموفق بود.");
            }
        }

        private void BindTransactions() {
            var transactions = TransactionProvider.Current.GetAllTransactions();
            var i = 1;

            Transactions.InnerHtml = "<tr>";

            if (transactions.Any()) {
                foreach (var transaction in transactions) {
                    Transactions.InnerHtml += $"<th scope=\"row\">{i++}</th>";
                    Transactions.InnerHtml += $"<td>{transaction.TransactionId}</td>";
                    Transactions.InnerHtml += $"<td>{transaction.Amount} تومان</td>";
                    Transactions.InnerHtml += $"<td>{UiHelpers.ToHumanReadable(transaction.Bank)}</td>";
                    Transactions.InnerHtml += $"<td>{transaction.Description.IfNullOrWhiteSpace("-")}</td>";
                    Transactions.InnerHtml += $"<td>{UiHelpers.ToHumanReadable(transaction.Result)}</td>";
                }
            } else
                Transactions.InnerHtml += $"<td colspan=\"6\" style=\"text-align: center;color: #c8c8c8;\">هنوز تراکنشی انجام نشده است.</td>";

            Transactions.InnerHtml += "</tr>";
        }

        protected void InitiateRequestButtonOnClick(object sender, EventArgs e) {
            var prepareRequest = new PrepareTransactionRequest {
                Pin = Api.Pin,
                Amount = AmountTextBox.Text,
                Callback = "http://localhost:2996/Default",
                Bank = (BankType) Enum.Parse(typeof(BankType),
                BankTypeDropDownList.SelectedValue),
                Description = DescriptionTextBox.Text
            };
            string transactionId;

            var result = HttpHelpers.PrepareTransaction(prepareRequest, out transactionId);

            if (result == PaymentOpResult.Succeeded) {
                TransactionProvider.Current.SaveTransaction(new TransactionEntity {
                    Pin = prepareRequest.Pin,
                    Amount = int.Parse(prepareRequest.Amount),
                    Bank = prepareRequest.Bank,
                    Description = prepareRequest.Description,
                    TransactionId = transactionId,
                    Result = PaymentOpResult.Unkndown
                });

                HttpHelpers.StartTransaction(Response, new StartTransactionRequest {
                    TransactionId = transactionId
                });
                return;
            }

            Message.InnerHtml = UiHelpers.AsError(UiHelpers.ToHumanReadable(result));
        }
    }
}