using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Regra_Negocio_API.Domain;
using Regra_Negocio_WebApp.Services;

namespace Regra_Negocio_WebApp.Pages {
    public class RegistrosModel : PageModel {
        private readonly ILogger<RegistrosModel> _logger;
        private readonly RegraNegocioService _regraNegocioService;

        public List<RegraNegocio> Registros { get; set; } = new();

        public RegistrosModel(ILogger<RegistrosModel> logger, RegraNegocioService regraNegocioService) {
            _logger = logger;
            _regraNegocioService = regraNegocioService;
        }

        public async Task OnGetAsync() {
            Registros = await _regraNegocioService.GetRegrasAsync();
        }
    }

}
