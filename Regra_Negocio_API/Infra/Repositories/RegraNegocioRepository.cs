using Regra_Negocio_API.Domain;
using Regra_Negocio_API.Infra.DbContext;
using Regra_Negocio_API.Infra.Repositories.Interfaces;
using System.Data;

namespace Regra_Negocio_API.Infra.Repositories {
    public class RegraNegocioRepository : IRegraNegocioRepository {
        private readonly ConexaoPostreSQL _conexaoPostreSQL;

        public RegraNegocioRepository(ConexaoPostreSQL conexaoPostreSQL) {
            _conexaoPostreSQL = conexaoPostreSQL;
        }

        public async Task<List<RegraNegocio>> FindAllRegistros() {
            var listaRegistros = new List<RegraNegocio>();

            using (var connection = _conexaoPostreSQL.GetConnection()) {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand()) {
                    command.CommandText = @"
                                            SELECT 
                                                    regra_id,
	                                                nome_regra,
	                                                identificador,
	                                                descricao,
	                                                evento_gatilho,
	                                                exemplo_caso_de_uso,
	                                                pseudo_codigo,
	                                                documentacao,
	                                                regras_relacionadas,
	                                                autor_documento,
	                                                data_criacao,
	                                                autor_atualizacao,
	                                                data_atualizacao
                                                FROM regranegocio
                    ";

                    using (var reader = await command.ExecuteReaderAsync()) {
                        while (await reader.ReadAsync()) {
                            var regraNegocio = new RegraNegocio();
                            regraNegocio.RegraId = reader.IsDBNull("regra_id") ? 0 : reader.GetInt32("regra_id");
                            regraNegocio.NomeRegra = reader.IsDBNull("nome_regra") ? null : reader.GetString("nome_regra");
                            regraNegocio.Identificador = reader.IsDBNull("identificador") ? null : reader.GetString("identificador");
                            regraNegocio.Descricao = reader.IsDBNull("descricao") ? null : reader.GetString("descricao");
                            regraNegocio.EventoGatilho = reader.IsDBNull("evento_gatilho") ? null : reader.GetString("evento_gatilho");
                            regraNegocio.ExemploCasoDeUso = reader.IsDBNull("exemplo_caso_de_uso") ? null : reader.GetString("exemplo_caso_de_uso");
                            regraNegocio.PseudoCodigo = reader.IsDBNull("pseudo_codigo") ? null : reader.GetString("pseudo_codigo");
                            regraNegocio.Documentacao = reader.IsDBNull("documentacao") ? null : reader.GetString("documentacao");
                            regraNegocio.RegrasRelacionadas = reader.IsDBNull("regras_relacionadas") ? null : reader.GetString("regras_relacionadas");
                            regraNegocio.AutorDocumento = reader.IsDBNull("autor_documento") ? null : reader.GetString("autor_documento");
                            regraNegocio.DataCriacao = reader.GetDateTime("data_criacao");
                            regraNegocio.AutorAtualizacao = reader.IsDBNull("autor_atualizacao") ? null : reader.GetString("autor_atualizacao");
                            regraNegocio.DataAtualizacao = reader.IsDBNull("data_atualizacao") ? (DateTime?)null : reader.GetDateTime("data_atualizacao");

                            listaRegistros.Add(regraNegocio);
                        }
                    }
                }
                return listaRegistros.ToList();
            }
        }

        public async Task<RegraNegocio> FindById(int id) {
            var registro = new RegraNegocio();

            using (var connection = _conexaoPostreSQL.GetConnection()) {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand()) {
                    command.CommandText = @"
                                            SELECT 
                                                    regra_id,
	                                                nome_regra,
	                                                identificador,
	                                                descricao,
	                                                evento_gatilho,
	                                                exemplo_caso_de_uso,
	                                                pseudo_codigo,
	                                                documentacao,
	                                                regras_relacionadas,
	                                                autor_documento,
	                                                data_criacao,
	                                                autor_atualizacao,
	                                                data_atualizacao
                                                FROM regranegocio
                                                WHERE regra_id = @id
                    ";

                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = await command.ExecuteReaderAsync()) {
                        if (await reader.ReadAsync()) {
                            registro.RegraId = reader.IsDBNull("regra_id") ? 0 : reader.GetInt32("regra_id");
                            registro.NomeRegra = reader.IsDBNull("nome_regra") ? null : reader.GetString("nome_regra");
                            registro.Identificador = reader.IsDBNull("identificador") ? null : reader.GetString("identificador");
                            registro.Descricao = reader.IsDBNull("descricao") ? null : reader.GetString("descricao");
                            registro.EventoGatilho = reader.IsDBNull("evento_gatilho") ? null : reader.GetString("evento_gatilho");
                            registro.ExemploCasoDeUso = reader.IsDBNull("exemplo_caso_de_uso") ? null : reader.GetString("exemplo_caso_de_uso");
                            registro.PseudoCodigo = reader.IsDBNull("pseudo_codigo") ? null : reader.GetString("pseudo_codigo");
                            registro.Documentacao = reader.IsDBNull("documentacao") ? null : reader.GetString("documentacao");
                            registro.RegrasRelacionadas = reader.IsDBNull("regras_relacionadas") ? null : reader.GetString("regras_relacionadas");
                            registro.AutorDocumento = reader.IsDBNull("autor_documento") ? null : reader.GetString("autor_documento");
                            registro.DataCriacao = reader.GetDateTime("data_criacao");
                            registro.AutorAtualizacao = reader.IsDBNull("autor_atualizacao") ? null : reader.GetString("autor_atualizacao");
                            registro.DataAtualizacao = reader.IsDBNull("data_atualizacao") ? (DateTime?)null : reader.GetDateTime("data_atualizacao");
                            
                            return registro;
                        }
                    }
                }
            }
            return null;
        }

        public async Task<RegraNegocio> InsertRegraNegocio(RegraNegocio regraNegocio) {
            using (var connection = _conexaoPostreSQL.GetConnection()) {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand()) {
                    command.CommandText = @"
                                            INSERT INTO regranegocio (
                                                nome_regra, 
                                                identificador, 
                                                descricao, 
                                                evento_gatilho, 
                                                exemplo_caso_de_uso, 
                                                pseudo_codigo, 
                                                documentacao, 
                                                regras_relacionadas, 
                                                autor_documento, 
                                                data_criacao, 
                                                autor_atualizacao, 
                                                data_atualizacao
                                            ) VALUES (
                                                @nome_regra, 
                                                @identificador, 
                                                @descricao, 
                                                @evento_gatilho, 
                                                @exemplo_caso_de_uso, 
                                                @pseudo_codigo, 
                                                @documentacao, 
                                                @regras_relacionadas, 
                                                @autor_documento, 
                                                @data_criacao, 
                                                @autor_atualizacao, 
                                                @data_atualizacao
                                            ) RETURNING regra_id
                    ";

                    command.Parameters.AddWithValue("@nome_regra", regraNegocio.NomeRegra);
                    command.Parameters.AddWithValue("@identificador", regraNegocio.Identificador);
                    command.Parameters.AddWithValue("@descricao", regraNegocio.Descricao);
                    command.Parameters.AddWithValue("@evento_gatilho", regraNegocio.EventoGatilho ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@exemplo_caso_de_uso", regraNegocio.ExemploCasoDeUso ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@pseudo_codigo", regraNegocio.PseudoCodigo ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@documentacao", regraNegocio.Documentacao ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@regras_relacionadas", regraNegocio.RegrasRelacionadas ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@autor_documento", regraNegocio.AutorDocumento);
                    command.Parameters.AddWithValue("@data_criacao", regraNegocio.DataCriacao);
                    command.Parameters.AddWithValue("@autor_atualizacao", regraNegocio.AutorAtualizacao ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@data_atualizacao", regraNegocio.DataAtualizacao ?? (object)DBNull.Value);

                    var regraId = await command.ExecuteScalarAsync();
                    regraNegocio.RegraId = (int)regraId;

                    return regraNegocio;
                }
            }
        }

        public async Task<RegraNegocio> UpdateRegraNegocio(string codigoIdentificador, string nomeAtual, RegraNegocio novaRegra) {
            using (var connection = _conexaoPostreSQL.GetConnection()) {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand()) {
                    command.CommandText = @"
                                            UPDATE regranegocio
                                                SET nome_regra = COALESCE(@nome_regra, nome_regra), 
                                                    identificador = COALESCE(@identificador, identificador), 
                                                    descricao = COALESCE(@descricao, descricao), 
                                                    evento_gatilho = @evento_gatilho, 
                                                    exemplo_caso_de_uso = @exemplo_caso_de_uso, 
                                                    pseudo_codigo = @pseudo_codigo, 
                                                    documentacao = @documentacao, 
                                                    regras_relacionadas = @regras_relacionadas, 
                                                    autor_atualizacao = @autor_atualizacao, 
                                                    data_atualizacao = @data_atualizacao
                                                WHERE identificador = @codigoIdentificador
                                                AND nome_regra = @nomeAtual
                                                RETURNING regra_id
                    ";

                    command.Parameters.AddWithValue("@nome_regra", novaRegra.NomeRegra ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@identificador", novaRegra.Identificador ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@descricao", novaRegra.Descricao ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@evento_gatilho", novaRegra.EventoGatilho ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@exemplo_caso_de_uso", novaRegra.ExemploCasoDeUso ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@pseudo_codigo", novaRegra.PseudoCodigo ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@documentacao", novaRegra.Documentacao ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@regras_relacionadas", novaRegra.RegrasRelacionadas ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@autor_atualizacao", novaRegra.AutorAtualizacao ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@data_atualizacao", novaRegra.DataAtualizacao ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@codigoIdentificador", codigoIdentificador);
                    command.Parameters.AddWithValue("@nomeAtual", nomeAtual);

                    object result = await command.ExecuteScalarAsync();

                    if (result != null && int.TryParse(result.ToString(), out int regraId))
                        return await FindById(regraId);
                }
            }
            return null;
        }

        public async Task<int> DeleteRegraNegocio(int regraId) {
            using (var connection = _conexaoPostreSQL.GetConnection()) {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand()) {
                    command.CommandText = @"
                                            DELETE FROM regranegocio
                                                  WHERE regra_id = @regraId
                    ";

                    command.Parameters.AddWithValue("regraId", regraId);

                    return await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
