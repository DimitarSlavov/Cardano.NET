using System;
using System.Collections.Generic;
using System.Linq;

namespace Cardano.Core.Http
{
    public class HttpHelper
    {
        public const string CardanoWalletHttpClient = nameof(CardanoWalletHttpClient);

        public const string CardanoExplorerHttpClient = nameof(CardanoExplorerHttpClient); 

        private const string UriDelimiter = "/";

        public static Uri NodeUrlFormat(Uri url, string path)
        {
            return new Uri($"{url}{path}");
        }

        public static string UrlCombine(params object[] pathParams)
        {
            return string.Join(UriDelimiter, pathParams);
        }

        public static string GetPathWithQueryParameters(string path, IDictionary<string, object> parameters)
        {
            if (parameters != null &&
                parameters.Any())
            {
                path += parameters.ToQueryString();
            }

            return path;
        }
    }
}
