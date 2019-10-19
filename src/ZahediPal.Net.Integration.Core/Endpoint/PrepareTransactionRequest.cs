using System.ComponentModel;

using ZahediPal.Net.Integration.Core.Abstraction;
using ZahediPal.Net.Integration.Core.Endpoint.Parameters;

namespace ZahediPal.Net.Integration.Core.Endpoint {
    public class PrepareTransactionRequest : ApiParams<PrepareTransactionRequest> {
        public string Pin { get; set; }

        [DisplayName("مبلغ")]
        public string Amount { get; set; }

        public string Callback { get; set; }

        [DisplayName("درگاه")]
        public BankType Bank { get; set; }

        [DisplayName("توضیحات")]
        public string Description { get; set; }
    }
}