namespace Common.Http
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    /// <summary>
    /// The http client service.
    /// </summary>
    public class HttpClientService
    {
        /// <summary>
        /// The http client.
        /// </summary>
        private static readonly System.Net.Http.HttpClient httpClient;

        private static object lockObj = new object();

        /// <summary>
        /// The uri.
        /// </summary>
        private readonly string uri;

        static HttpClientService()
        {
            if (httpClient == null)
            {
                lock (lockObj)
                {
                    if (httpClient == null)
                    {
                        httpClient = new System.Net.Http.HttpClient
                        {
                            Timeout = TimeSpan.FromSeconds(15),
                            MaxResponseContentBufferSize = 256000
                        };
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientService"/> class.
        /// </summary>
        /// <param name="uri">The uri.</param>
        public HttpClientService(string uri)
        {
            this.uri = uri;
        }

        /// <summary>
        /// Gets a <see cref="List{T}"/> <see cref="Task"/> from an HTTP Get request.
        /// </summary>
        /// <typeparam name="T">The generic Type <see cref="T"/>.</typeparam>
        /// <param name="serviceAddress">The service address in conjunction with the provided URI.</param>
        /// <returns>A <see cref="List{T}"/> <see cref="Task"/>.</returns>
        public async Task<List<T>> GetList<T>(string serviceAddress = null)
        {
            var response = await httpClient.GetAsync(this.uri + (serviceAddress ?? string.Empty));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var objResult = JsonConvert.DeserializeObject<List<T>>(content);
                return objResult;
            }

            throw new Exception(response.ReasonPhrase);
        }

        /// <summary>
        /// Gets a <see cref="T"/> <see cref="Task"/> from an HTTP Get request.
        /// </summary>
        /// <typeparam name="T">The generic Type <see cref="T"/>.</typeparam>
        /// <param name="serviceAddress">The service address in conjunction with the provided URI.</param>
        /// <returns>The <see cref="T"/> <see cref="Task"/>.</returns>
        /// <exception cref="Exception">Thrown when the HTTP response is not successful.</exception>
        public async Task<T> Get<T>(string serviceAddress = null)
        {
            var response = await httpClient.GetAsync(this.uri + (serviceAddress ?? string.Empty));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var objResult = JsonConvert.DeserializeObject<T>(content);
                return objResult;
            }

            throw new Exception(response.ReasonPhrase);
        }

        /// <summary>
        /// Posts a <see cref="T"/> <see cref="Task"/> to an HTTP Post request.
        /// </summary>
        /// <typeparam name="T">The generic Type <see cref="T"/>.</typeparam>
        /// <param name="obj">The <see cref="T"/> object.</param>
        /// <param name="serviceAddress">The service address in conjunction with the provided URI.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        /// <exception cref="Exception">Thrown when the HTTP response is not successful.</exception>
        public async Task Post<T>(T obj, string serviceAddress = null)
        {
            var json = JsonConvert.SerializeObject(obj);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(this.uri + (serviceAddress ?? string.Empty), content);

            if (response.IsSuccessStatusCode)
            {
                return;
            }

            throw new Exception(response.ReasonPhrase);
        }
    }
}
