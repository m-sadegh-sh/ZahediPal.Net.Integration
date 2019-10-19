using System.Collections.Generic;
using System.Web;

namespace ZahediPal.Net.Integration.Core.Storage {
    public abstract class DbProviderBase<TEntity> {
        private readonly string _entityName = typeof(TEntity).FullName;
        private readonly HttpContext _context;

        protected DbProviderBase(HttpContext context) {
            _context = context;
        }

        protected List<TEntity> Query {
            get {
                var query = (List<TEntity>) _context.Cache[_entityName];
                _context.Cache[_entityName] = query = query ?? new List<TEntity>();
                return query;
            }
        }
    }
}