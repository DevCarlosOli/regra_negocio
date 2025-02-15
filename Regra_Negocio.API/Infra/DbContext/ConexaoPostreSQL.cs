using Npgsql;

namespace Regra_Negocio.API.Infra.DbContext {
    public class ConexaoPostreSQL {
        private readonly string _connectionString;

        public ConexaoPostreSQL(IConfiguration connectionString) {
            _connectionString = connectionString.GetConnectionString("BancoPostgreSQL") ?? throw new ArgumentNullException("A string de conexão não foi encontrada.");
        }

        public NpgsqlConnection GetConnection() { 
            return new NpgsqlConnection(_connectionString);
        }
    }
}
