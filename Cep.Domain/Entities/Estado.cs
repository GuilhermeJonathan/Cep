using Cep.Domain.Entities;

namespace Cep.Domain.Entities
{
    public class Estado : EntidadeBase
    {
        protected Estado() : base() { }

        public string Sigla { get; private set; }
        public string Descricao { get; private set; }
        public long PaisId { get; private set; }
        public virtual Pais Pais { get; private set; }
    }
}
