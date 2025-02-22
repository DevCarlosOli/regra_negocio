using Regra_Negocio_API.Domain;
using System.Text;
using System.Text.Json;

namespace Regra_Negocio_WebApp.Services {
    public class RegraNegocioService {
        private readonly HttpClient _httpClient;

        public RegraNegocioService(IHttpClientFactory httpClientFactory) {
            _httpClient = httpClientFactory.CreateClient("Regra_Negocio_API");
        }

        public async Task<bool> InserirRegraAsync(RegraNegocio regra) {
            var json = JsonSerializer.Serialize(regra);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("RegraNegocio", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<RegraNegocio>> GetRegrasAsync() {
            var response = await _httpClient.GetAsync("RegraNegocio");

            if (response.IsSuccessStatusCode) {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<RegraNegocio>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return result;
            }

            return new List<RegraNegocio>();
        }
    }
}
