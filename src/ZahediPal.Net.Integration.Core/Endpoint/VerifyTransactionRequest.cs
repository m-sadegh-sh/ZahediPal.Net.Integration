using ZahediPal.Net.Integration.Core.Abstraction;

namespace ZahediPal.Net.Integration.Core.Endpoint {
    public class VerifyTransactionRequest : ApiParams<VerifyTransactionRequest> {
        public string Pin { get; set; }
        public int Amount { get; set; }
        public string TransId { get; set; }
    }
}