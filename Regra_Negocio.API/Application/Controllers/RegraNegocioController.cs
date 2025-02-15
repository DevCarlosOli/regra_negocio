using Microsoft.AspNetCore.Mvc;
using Regra_Negocio.API.Application.Services.Interfaces;
using Regra_Negocio.API.Domain;

namespace Regra_Negocio.API.Application.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RegraNegocioController : ControllerBase {
        private readonly IRegraNegocioService _regraNegocioService;

        public RegraNegocioController(IRegraNegocioService regraNegocioService) {
            _regraNegocioService = regraNegocioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RegraNegocio>>> GetRegistros() {
            try {
                var registros = await _regraNegocioService.FindAllRegistros();
                return Ok(registros);
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<RegraNegocio>> GetRegistroById(int id) {
            try {
                var registro = await _regraNegocioService.FindById(id);
                return Ok(registro);
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<RegraNegocio>> PostRegraNegocio(RegraNegocio regraNegocio) {
            try {
                var registro = await _regraNegocioService.InsertRegraNegocio(regraNegocio);
                return Ok(registro);
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}
