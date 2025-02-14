using Regra_Negocio.API.Domain;

namespace Regra_Negocio.API.Infra.Repositories.Interfaces {
    public interface IRegraNegocioRepository {
        IEnumerable<RegraNegocio> GetAllRegistros();
    }
}
