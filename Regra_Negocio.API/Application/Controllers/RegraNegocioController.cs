using Microsoft.AspNetCore.Mvc;
using Regra_Negocio.API.Application.Services.Interfaces;

namespace Regra_Negocio.API.Application.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RegraNegocioController : ControllerBase {
        private readonly IRegraNegocioService _regraNegocioService;

        public RegraNegocioController(IRegraNegocioService regraNegocioService) {
            _regraNegocioService = regraNegocioService;
        }

        [HttpGet]
        public IActionResult GetRegistros() {
            try {
                var registros = _regraNegocioService.GetAllRegistros();
                return Ok(registros);
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}
