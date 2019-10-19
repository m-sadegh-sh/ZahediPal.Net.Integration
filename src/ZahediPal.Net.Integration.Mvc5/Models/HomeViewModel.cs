using System.Collections.Generic;

using ZahediPal.Net.Integration.Core.Endpoint;
using ZahediPal.Net.Integration.Core.Storage.Entities;

namespace ZahediPal.Net.Integration.Mvc5.Models {
    public class HomeViewModel {
        public PrepareTransactionRequest Request { get; set; }
        public List<TransactionEntity> Transactions { get; set; }
    }
}