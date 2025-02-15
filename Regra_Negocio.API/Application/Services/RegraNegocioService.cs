﻿using Regra_Negocio.API.Application.Services.Interfaces;
using Regra_Negocio.API.Domain;
using Regra_Negocio.API.Infra.Repositories.Interfaces;

namespace Regra_Negocio.API.Application.Services {
    public class RegraNegocioService : IRegraNegocioService {
        private readonly IRegraNegocioRepository _regraNegocioRepository;

        public RegraNegocioService(IRegraNegocioRepository regraNegocioRepository) {
            _regraNegocioRepository = regraNegocioRepository;
        }

        public async Task<List<RegraNegocio>> FindAllRegistros() {
            return await _regraNegocioRepository.FindAllRegistros();
        }

        public async Task<RegraNegocio> FindById(int id) {
            return await _regraNegocioRepository.FindById(id);
        }

        public async Task<RegraNegocio> InsertRegraNegocio(RegraNegocio regraNegocio) {
            return await _regraNegocioRepository.InsertRegraNegocio(regraNegocio);
        }
    }
}
