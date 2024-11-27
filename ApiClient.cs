using System.Net.Http.Json;

namespace InflectionApi {

    public class ApiClient : IDisposable {

        public string EndpointUrl { get; set; } = DEFAULT_ENDPOINT_URL;

        private readonly HttpClient httpClient;

        public ApiClient(string apiKey) {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);
        }

        public ApiResponse? GetResponse(ApiRequest apiRequest) {

            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, EndpointUrl) {
                Content = JsonContent.Create(apiRequest)
            };

            using var response = httpClient.Send(httpRequest, HttpCompletionOption.ResponseContentRead);
           
            return response.Content.ReadFromJsonAsync<ApiResponse>().Result;
        }

        public void Dispose() {
            httpClient.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
