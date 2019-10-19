using System;
using System.Net;
using System.Text;
using System.Web;

using ZahediPal.Net.Integration.Core.Endpoint;
using ZahediPal.Net.Integration.Core.Endpoint.Parameters;

namespace ZahediPal.Net.Integration.Core.Helpers {
    public static class HttpHelpers {
        public static PaymentOpResult PrepareTransaction(PrepareTransactionRequest request, out string transactionId) {
            transactionId = null;

            try {
                using (var client = new WebClient()) {
                    var response = client.UploadValues($"{Api.Base}/{Api.Create}/", request.GetParams());

                    transactionId = Encoding.UTF8.GetString(response);
                    int errorCode;

                    if (int.TryParse(transactionId, out errorCode) && (errorCode > -15) && (errorCode <= -1)) {
                        transactionId = null;
                        return (PaymentOpResult) errorCode;
                    }

                    return PaymentOpResult.Succeeded;
                }
            } catch {
                return PaymentOpResult.Failed;
            }
        }

        public static void StartTransaction(HttpResponse response, StartTransactionRequest request) {
            StartTransaction(new HttpResponseWrapper(response), request);
        }

        public static void StartTransaction(HttpResponseBase response, StartTransactionRequest request) {
            response.Redirect($"{Api.Base}/{Api.Startpay}/{request.TransactionId}/");
        }

        public static bool VerifyTransaction(VerifyTransactionRequest request) {
            try {
                using (var client = new WebClient()) {
                    var response = client.UploadValues($"{Api.Base}/{Api.Verify}/", request.GetParams());

                    var result = Encoding.UTF8.GetString(response);
                    return string.Equals(result, "1", StringComparison.CurrentCultureIgnoreCase);
                }
            } catch {
                return false;
            }
        }
    }
}