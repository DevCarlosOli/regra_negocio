using Regra_Negocio_API.Domain;

namespace Regra_Negocio_API.Infra.Repositories.Interfaces {
    public interface IRegraNegocioRepository {
        Task<List<RegraNegocio>> FindAllRegistros();
        Task<RegraNegocio> FindById(int id);
        Task<RegraNegocio> InsertRegraNegocio(RegraNegocio regraNegocio);
        Task<RegraNegocio> UpdateRegraNegocio(string codigoIdentificador, string nomeAtual, RegraNegocio novaRegra);
        Task<int> DeleteRegraNegocio(int regraId);
    }
}
