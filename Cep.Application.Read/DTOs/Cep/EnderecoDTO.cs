using Cep.Application.Read.DTOs.Bairros;

namespace Cep.Application.Read.DTOs.Cep
{
    public class EnderecoDTO
    {
        public long Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public long BairroId { get; set; }
        public BairroDTO Bairro { get; set; }
    }
}
