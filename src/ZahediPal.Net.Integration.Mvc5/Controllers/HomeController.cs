using System.Web.Mvc;

using ZahediPal.Net.Integration.Core;
using ZahediPal.Net.Integration.Core.Endpoint;
using ZahediPal.Net.Integration.Core.Endpoint.Parameters;
using ZahediPal.Net.Integration.Core.Helpers;
using ZahediPal.Net.Integration.Core.Storage;
using ZahediPal.Net.Integration.Core.Storage.Entities;
using ZahediPal.Net.Integration.Mvc5.Models;

namespace ZahediPal.Net.Integration.Mvc5.Controllers {
    public class HomeController : Controller {
        [HttpGet]
        public ActionResult Index() {
            var model = PopulateModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel model) {
            if (!VerifyTransaction()) {
                string transactionId;

                var result = HttpHelpers.PrepareTransaction(model.Request, out transactionId);

                if (result == PaymentOpResult.Succeeded) {
                    TransactionProvider.Current.SaveTransaction(new TransactionEntity {
                        Pin = model.Request.Pin,
                        Amount = int.Parse(model.Request.Amount),
                        Bank = model.Request.Bank,
                        Description = model.Request.Description,
                        TransactionId = transactionId,
                        Result = PaymentOpResult.Unkndown
                    });

                    HttpHelpers.StartTransaction(Response, new StartTransactionRequest {
                        TransactionId = transactionId
                    });
                    return new EmptyResult();
                }

                ViewBag.Message = UiHelpers.AsError(UiHelpers.ToHumanReadable(result));
            }

            model = PopulateModel();

            return View(model);
        }

        private static HomeViewModel PopulateModel() {
            return new HomeViewModel {
                Request = new PrepareTransactionRequest {
                    Pin = Api.Pin,
                    Callback = "http://localhost:3017/"
                },
                Transactions = TransactionProvider.Current.GetAllTransactions()
            };
        }

        private bool VerifyTransaction() {
            var transactionId = Request.Form["transid"];
            if (string.IsNullOrEmpty(transactionId))
                return false;

            ModelState.Clear();
            var newTransaction = TransactionProvider.Current.GetTransaction(transactionId);
            if (newTransaction == null)
                ViewBag.Message = UiHelpers.AsError("تراکنش مورد نظر یافت نشد!");
            else {
                var isSucceeded = HttpHelpers.VerifyTransaction(new VerifyTransactionRequest {
                    Pin = newTransaction.Pin,
                    Amount = newTransaction.Amount,
                    TransId = newTransaction.TransactionId
                });
                newTransaction.Result = isSucceeded ? PaymentOpResult.Succeeded : PaymentOpResult.Failed;

                if (isSucceeded)
                    ViewBag.Message = UiHelpers.AsSuccess("تراکنش موفقیت آمیز بود.");
                else
                    ViewBag.Message = UiHelpers.AsError("تراکنش ناموفق بود.");
            }

            return true;
        }
    }
}