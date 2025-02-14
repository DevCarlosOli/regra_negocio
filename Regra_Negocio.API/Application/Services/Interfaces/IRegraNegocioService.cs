using Regra_Negocio.API.Domain;

namespace Regra_Negocio.API.Application.Services.Interfaces {
    public interface IRegraNegocioService {
        IEnumerable<RegraNegocio> GetAllRegistros();
    }
}
