using Cep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cep.Domain.Entities
{
    public class Bairro : EntidadeBase
    {
        protected Bairro() : base() { }        

        public Bairro(string nome, long cidadeId) : this()
        {
            Nome = nome.ToUpper();
            CidadeId = cidadeId;
        }

        public string Codigo { get; private set; }
        public string Nome { get; private set; }        
        public long CidadeId { get; private set; }
        public virtual Cidade Cidade { get; private set; }
    }
}
