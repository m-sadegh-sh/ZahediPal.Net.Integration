using ZahediPal.Net.Integration.Core.Endpoint.Parameters;

namespace ZahediPal.Net.Integration.Core.Storage.Entities {
    public class TransactionEntity {
        public string Pin { get; set; }
        public int Amount { get; set; }
        public BankType Bank { get; set; }
        public string Description { get; set; }
        public string TransactionId { get; set; }
        public PaymentOpResult Result { get; set; }
    }
}