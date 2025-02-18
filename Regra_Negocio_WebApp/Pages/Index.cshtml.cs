using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Regra_Negocio_API.Domain;
using Regra_Negocio_WebApp.Services;

namespace Regra_Negocio_WebApp.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;
        private readonly RegraNegocioService _regraNegocioService;

        public IndexModel(ILogger<IndexModel> logger, RegraNegocioService regraNegocioService) {
            _logger = logger;
            _regraNegocioService = regraNegocioService;
        }

        [BindProperty]
        public RegraNegocio NovaRegra {  get; set; }

        public async Task<IActionResult> OnPostInserirRegraAsync() {
            if (!ModelState.IsValid)
                return Page();

            bool sucesso = await _regraNegocioService.InserirRegraAsync(NovaRegra);
            
            if (!sucesso) {
                ModelState.AddModelError(string.Empty, "Erro ao inserir a regra de negócio.");
                return Page();
            }

            return RedirectToPage("Index");
        }

        public void OnGet() {

        }
    }
}
