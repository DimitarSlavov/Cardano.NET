using System.Net;

namespace Cardano.Core.Models.Common
{
    public class HttpResponseModel
    {
        public string ReasonPhrase { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
