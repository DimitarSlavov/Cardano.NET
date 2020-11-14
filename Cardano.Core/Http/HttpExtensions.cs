using System.Collections.Generic;
using System.Text;

namespace Cardano.Core.Http
{
    public static class HttpExtensions
    {
		private const string QueryBegining = "?";

		private const string EqualsSign = "=";

		private const string QueryConcat = "&";

		private static string ToQueryParams(string name, object value)
			=> $"{name}{EqualsSign}{value}";

		public static string ToQueryString(this IDictionary<string, object> queryParams)
		{
			var queryString = new StringBuilder();

			foreach (var kvp in queryParams)
			{
				queryString.AppendQuery(kvp.Key, kvp.Value);
			}

			return queryString.ToString();
		}

		public static StringBuilder AppendQuery(this StringBuilder query, string name, object value)
		{
			var indexOfQueryBegining = query.ToString().IndexOf(QueryBegining);

			if (indexOfQueryBegining > -1)
			{
				if (indexOfQueryBegining != query.Length)
				{
					query.Append(QueryConcat);
				}
			}
			else
			{
				query.Append(QueryBegining);
			}

			query.Append(ToQueryParams(name, value));

			return query;
		}

		public static string AppendQuery(this string query, string name, object value)
		{
			if(value != null)
            {
				var queryBuilder = new StringBuilder(query);

				if (query.IndexOf(QueryBegining) > -1)
				{
					if (query.IndexOf(QueryBegining) != query.Length)
					{
						queryBuilder.Append(QueryConcat);
					}
				}
				else
				{
					queryBuilder.Append(QueryBegining);
				}

				queryBuilder.Append(ToQueryParams(name, value));

				query = queryBuilder.ToString();
			}

			return query;
		}
	}
}
