namespace Cardano.Core.Http.Requests.Implementations
{
    internal sealed class RequestsBase
    {
        public static string HttpClientName { get; private set; }

        public RequestsBase(string httpClientName)
        {
            HttpClientName = httpClientName;
        }
    }
}
