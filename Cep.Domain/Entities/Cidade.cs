using Cep.Domain.Entities;

namespace Cep.Domain.Entities
{
    public class Cidade : EntidadeBase
    {
        protected Cidade() : base() { }

        public Cidade(string descricao, long estadoId) : this()
        {
            Descricao = descricao.ToUpper();
            EstadoId = estadoId;
        }

        public string Descricao { get; private set; }
        public string Cep { get; private set; }
        public long EstadoId { get; private set; }
        public virtual Estado Estado { get; private set; }
    }
}
