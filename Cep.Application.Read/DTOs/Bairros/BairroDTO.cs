using Cep.Application.Read.DTOs.Cidades;

namespace Cep.Application.Read.DTOs.Bairros
{
    public class BairroDTO
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public long CidadeId { get; set; }
        public CidadeDTO Cidade { get; set; }
    }
}
