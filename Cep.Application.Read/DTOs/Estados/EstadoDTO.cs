using Cep.Application.Read.DTOs.Pais;

namespace Cep.Application.Read.DTOs.Estados
{
    public class EstadoDTO
    {
        public long Id { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public long PaisId { get; set; }
        public PaisDTO Pais { get; set; }
    }
}
