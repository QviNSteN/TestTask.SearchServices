using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;

namespace Test.General.Extension
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> GetOrNullAsync(this System.Net.Http.HttpClient client, string? requestUrl)
        {
            try
            {
                return await client.GetAsync(requestUrl);
            }
            catch
            {
                return null;
            }
        }

        public static async Task<HttpResponseMessage> GetOrNullAsync(this System.Net.Http.HttpClient client, string? requestUrl, CancellationToken cancellationToken)
        {
            try
            {
                return await client.GetAsync(requestUrl, cancellationToken);
            }
            catch
            {
                return null;
            }
        }
    }
}
