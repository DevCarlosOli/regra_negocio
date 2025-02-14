using Regra_Negocio.API.Application.Services.Interfaces;
using Regra_Negocio.API.Domain;
using Regra_Negocio.API.Infra.Repositories.Interfaces;

namespace Regra_Negocio.API.Application.Services {
    public class RegraNegocioService : IRegraNegocioService {
        private readonly IRegraNegocioRepository _regraNegocioRepository;

        public RegraNegocioService(IRegraNegocioRepository regraNegocioRepository) {
            _regraNegocioRepository = regraNegocioRepository;
        }

        public IEnumerable<RegraNegocio> GetAllRegistros() {
            return _regraNegocioRepository.GetAllRegistros();
        }
    }
}
