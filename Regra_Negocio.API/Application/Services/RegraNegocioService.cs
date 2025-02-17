using Regra_Negocio.API.Application.Services.Interfaces;
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
            var registroId = id;
            if (registroId <= 0) {
                return null;
            }
            return await _regraNegocioRepository.FindById(id);
        }

        public async Task<RegraNegocio> InsertRegraNegocio(RegraNegocio regraNegocio) {
            return await _regraNegocioRepository.InsertRegraNegocio(regraNegocio);
        }

        public async Task<RegraNegocio> UpdateRegraNegocio(string codigoIdentificador, string nomeAtual, RegraNegocio novaRegra) {
            if (string.IsNullOrEmpty(codigoIdentificador) || string.IsNullOrEmpty(nomeAtual)) {
                return null;
            }
            return await _regraNegocioRepository.UpdateRegraNegocio(codigoIdentificador, nomeAtual, novaRegra);
        }

        public async Task<int> DeleteRegraNegocio(int id) { 
            var registro = await FindById(id);

            if (registro == null)
                return 0;

            return await _regraNegocioRepository.DeleteRegraNegocio(registro.RegraId);
        }
    }
}
