using Cep.Domain.Entities;

namespace Cep.Domain.Entities
{
    public class Pais : EntidadeBase
    {
        protected Pais() : base() { }
        
        public string Descricao { get; private set; }
        public string Sigla { get; private set; }
        public string Ddi { get; private set; }
    }
}
