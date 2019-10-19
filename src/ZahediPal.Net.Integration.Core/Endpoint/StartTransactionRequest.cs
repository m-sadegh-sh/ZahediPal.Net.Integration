using ZahediPal.Net.Integration.Core.Abstraction;

namespace ZahediPal.Net.Integration.Core.Endpoint {
    public class StartTransactionRequest : ApiParams<StartTransactionRequest> {
        public string TransactionId { get; set; }
    }
}