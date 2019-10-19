using System.Collections.Specialized;

namespace ZahediPal.Net.Integration.Core.Abstraction {
    public abstract class ApiParams<T> : IApiParams {
        public NameValueCollection GetParams() {
            var @params = new NameValueCollection();

            foreach (var prop in typeof(T).GetProperties()) {
                var rawValue = prop.GetValue(this, null)?.ToString() ?? "";

                if (prop.PropertyType.IsEnum)
                    rawValue = rawValue.ToLower();

                @params.Add(prop.Name.ToLower(), rawValue);
            }

            return @params;
        }
    }
}