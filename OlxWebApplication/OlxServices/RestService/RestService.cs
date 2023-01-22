using Newtonsoft.Json;
using OlxCore.Interfaces.Services;
using System.Text;
using System.Threading.Tasks;

namespace OlxServices.Services.RestService
{
    public class RestService : IRestService
    {
        #region -- IRestService implementation --

        public async Task<T> RequestAsync<T>(HttpMethod method, string requestUrl, Dictionary<string, string>? additionalHeaders = null)
        {

            using (var response = await MakeRequestAsync(method, requestUrl, null, additionalHeaders).ConfigureAwait(false))
            {
                ThrowIfNotSuccess(response);

                var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return JsonConvert.DeserializeObject<T>(data);
            }
        }

        public async Task<T> RequestAsync<T>(HttpMethod method, string requestUrl, object requestBody, Dictionary<string, string>? additionalHeaders = null)
        {
            using (var response = await MakeRequestAsync(method, requestUrl, requestBody, additionalHeaders).ConfigureAwait(false))
            {
                ThrowIfNotSuccess(response);

                var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return JsonConvert.DeserializeObject<T>(data);
            }
        }

        #endregion

        #region -- Private helpers --

        private static void ThrowIfNotSuccess(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        private async Task<HttpResponseMessage> MakeRequestAsync(HttpMethod method, string requestUrl, object? requestBody = null, Dictionary<string, string>? additioalHeaders = null)
        {
            var client = new HttpClient{};

            var request = new HttpRequestMessage(method, requestUrl);

            if (requestBody is not null)
            {
                var json = JsonConvert.SerializeObject(requestBody);

                if (requestBody is IEnumerable<KeyValuePair<string, string>> body)
                {
                    request.Content = new FormUrlEncodedContent(body);
                }
                else
                {
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }
            }

            if (additioalHeaders is not null)
            {
                foreach (var header in additioalHeaders)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            return await client.SendAsync(request).ConfigureAwait(false);
        }

        #endregion
    }
}
