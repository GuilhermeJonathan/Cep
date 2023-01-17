using Cep.Application.Read.DTOs.Estados;

namespace Cep.Application.Read.DTOs.Cidades
{
    public class CidadeDTO
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public string Cep { get; set; }
        public long EstadoId { get; set; }
        public EstadoDTO Estado { get; set; }
    }
}
