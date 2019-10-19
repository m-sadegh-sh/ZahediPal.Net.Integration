using System.Collections.Generic;
using System.Linq;
using System.Web;

using ZahediPal.Net.Integration.Core.Storage.Entities;

namespace ZahediPal.Net.Integration.Core.Storage {
    public class TransactionProvider : DbProviderBase<TransactionEntity> {
        private TransactionProvider(HttpContext context) : base(context) {}

        public static TransactionProvider Current => new TransactionProvider(HttpContext.Current);

        public TransactionEntity GetTransaction(string transactionId) {
            return Query.FirstOrDefault(t => string.Equals(t.TransactionId, transactionId));
        }

        public void SaveTransaction(TransactionEntity entity) {
            Query.Add(entity);
        }

        public List<TransactionEntity> GetAllTransactions() {
            return Query;
        }
    }
}