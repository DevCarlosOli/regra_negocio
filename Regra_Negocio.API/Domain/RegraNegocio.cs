namespace Regra_Negocio.API.Domain {
    public class RegraNegocio {
        public int RegraId { get; set; }
        public string NomeRegra { get; set; }
        public string Identificador { get; set; }
        public string Descricao { get; set; }
        public string EventoGatilho { get; set; }
        public string ExemploCasoDeUso { get; set; }
        public string PseudoCodigo { get; set; }
        public string Documentacao { get; set; }
        public string RegrasRelacionadas { get; set; }
        public string AutorDocumento { get; set; }
        public DateTime DataCriacao { get; set; }
        public string AutorAtualizacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
