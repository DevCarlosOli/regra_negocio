﻿using Microsoft.AspNetCore.Mvc;
using Regra_Negocio_API.Application.Services.Interfaces;
using Regra_Negocio_API.Domain;
using System.ComponentModel.DataAnnotations;

namespace Regra_Negocio_API.Application.Controllers {
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

        [HttpGet("{id}")]
        public async Task<ActionResult<RegraNegocio>> GetRegistroById([FromQuery(Name = "id")] int id) {
            try {
                var registro = await _regraNegocioService.FindById(id);
                return Ok(registro);
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<RegraNegocio>> PostRegraNegocio([FromBody] RegraNegocio regraNegocio) {
            try {
                var registro = await _regraNegocioService.InsertRegraNegocio(regraNegocio);
                return Ok(registro);
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<RegraNegocio>> PutRegraNegocio(
            [FromQuery(Name = "codigoIdentificador")][Required] string codigoIdentificador,
            [FromQuery(Name = "nomeAtual")][Required] string nomeAtual,
            [FromBody] RegraNegocio novaRegra
        ) {
            try {
                var registroAtualizado = await _regraNegocioService.UpdateRegraNegocio(codigoIdentificador, nomeAtual, novaRegra);
                return Ok(registroAtualizado);
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteRegraNegocio(int id) {
            try {
                int result = await _regraNegocioService.DeleteRegraNegocio(id);

                if (result == 0)
                    return NotFound(new {message = "Registro não encontrado!"});

                return Ok(new { message = "Registro deletado com sucesso." });
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}
