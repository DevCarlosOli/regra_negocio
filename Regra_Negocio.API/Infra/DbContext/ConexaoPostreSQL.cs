using Npgsql;
using System.Data;

namespace Regra_Negocio.API.Infra.DbContext {
    public class ConexaoPostreSQL {
        private readonly string _connectionString;

        public ConexaoPostreSQL(IConfiguration connectionString) {
            _connectionString = connectionString.GetConnectionString("BancoPostgreSQL") ?? throw new ArgumentNullException("A string de conexão não foi encontrada.");
        }

        public IDbConnection GetConnection() { 
            return new NpgsqlConnection(_connectionString);
        }
    }
}
