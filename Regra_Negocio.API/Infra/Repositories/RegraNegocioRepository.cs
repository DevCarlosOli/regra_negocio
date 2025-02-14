using Dapper;
using Regra_Negocio.API.Domain;
using Regra_Negocio.API.Infra.DbContext;
using Regra_Negocio.API.Infra.Repositories.Interfaces;

namespace Regra_Negocio.API.Infra.Repositories {
    public class RegraNegocioRepository : IRegraNegocioRepository {
        private readonly ConexaoPostreSQL _conexaoPostreSQL;

        public RegraNegocioRepository(ConexaoPostreSQL conexaoPostreSQL) {
            _conexaoPostreSQL = conexaoPostreSQL;
        }

        public IEnumerable<RegraNegocio> GetAllRegistros() {
            using (var conn = _conexaoPostreSQL.GetConnection()) {
                conn.Open();
                return conn.Query<RegraNegocio>("SELECT * FROM regranegocio");
            }
        }
    }
}
