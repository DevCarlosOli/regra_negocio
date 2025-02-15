using Regra_Negocio.API.Domain;

namespace Regra_Negocio.API.Application.Services.Interfaces {
    public interface IRegraNegocioService {
        Task<List<RegraNegocio>> FindAllRegistros();
        Task<RegraNegocio> FindById(int id);
        Task<RegraNegocio> InsertRegraNegocio(RegraNegocio regraNegocio);
    }
}
