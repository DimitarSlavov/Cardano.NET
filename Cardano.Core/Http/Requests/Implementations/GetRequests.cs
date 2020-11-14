using Cardano.Core.Http.Requests.Interfaces;
using Cardano.Core.Json.Interfaces;
using Cardano.Core.Models.Common;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cardano.Core.Http.Requests.Implementations
{
    internal class GetRequests : IGetRequests
    {
        private readonly HttpClient httpClient;
        private readonly IJsonSerializer jsonSerializer;

        public GetRequests(IHttpClientFactory httpClientFactory,
            IJsonSerializer jsonSerializer)
        {
            httpClient = httpClientFactory.CreateClient(RequestsBase.HttpClientName);
            this.jsonSerializer = jsonSerializer;
        }

        public async Task<Response<TRequestBody>> GetAsync<TRequestBody>(
            string path)
            where TRequestBody : class
        {
            try
            {
                using (var httpResponse = await httpClient.GetAsync(path))
                {
                    var result = Response<TRequestBody>.GetResponse(httpResponse.ReasonPhrase, httpResponse.StatusCode);

                    var content = await httpResponse.Content.ReadAsStringAsync();

                    if (content == null)
                    {
                        return result;
                    }

                    try
                    {
                        var error = jsonSerializer.Deserialize<CardanoHttpResponseModel>(content);

                        if (error.Message != null && error.Code != null)
                        {
                            result.CardanoHttpResponseModel = new CardanoHttpResponseModel
                            {
                                Message = error.Message,
                                Code = error.Code
                            };

                            return result;
                        }
                    }
                    catch { }

                    var model = jsonSerializer.Deserialize<TRequestBody>(content);

                    result.Content = model;

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
