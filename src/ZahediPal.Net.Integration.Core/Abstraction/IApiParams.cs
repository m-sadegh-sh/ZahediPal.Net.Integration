using System.Collections.Specialized;

namespace ZahediPal.Net.Integration.Core.Abstraction {
    public interface IApiParams {
        NameValueCollection GetParams();
    }
}