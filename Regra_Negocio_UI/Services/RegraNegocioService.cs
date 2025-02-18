

using Regra_Negocio_API.Domain;

namespace Regra_Negocio_UI.Services {
    public class RegraNegocioService {
        private readonly HttpClient _httpClient;

        public RegraNegocioService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<List<RegraNegocio>> GetRegrasAsync() {
            var regras = await _httpClient.GetFromJsonAsync<List<RegraNegocio>>();
        }
    }
}
