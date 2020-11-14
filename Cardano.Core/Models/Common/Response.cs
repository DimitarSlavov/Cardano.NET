using System.Net;

namespace Cardano.Core.Models.Common
{
	public class Response<T> : Response
	{
		public Response()
		{

		}

		public Response(string reasonPhrase, HttpStatusCode statusCode)
		{
			HttpResponseModel = new HttpResponseModel
			{
				ReasonPhrase = reasonPhrase,
				StatusCode = statusCode
			};
		}

		public T Content { get; set; }

		new public static Response<T> GetResponse(string reasonPhrase, HttpStatusCode statusCode)
		{
			return new Response<T>(reasonPhrase, statusCode);
		}
	}

	public class Response
	{
        public Response()
        {

        }

        public Response(string reasonPhrase, HttpStatusCode statusCode)
        {
			HttpResponseModel = new HttpResponseModel
			{
				ReasonPhrase = reasonPhrase,
				StatusCode = statusCode
			};
		}

		public CardanoHttpResponseModel CardanoHttpResponseModel { get; set; }

		public HttpResponseModel HttpResponseModel { get; set; }

		public static Response GetResponse(string reasonPhrase, HttpStatusCode statusCode)
		{
			return new Response(reasonPhrase, statusCode);
		}
	}
}
