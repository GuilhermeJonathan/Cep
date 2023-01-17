using Cep.Domain.Entities;

namespace Cep.Domain.Entities
{
    public class Endereco : EntidadeBase
    {
        protected Endereco() : base() { }

        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Complemento { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
    }
}
