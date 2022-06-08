using Default.Domain.Core;
using System;

namespace Default.Domain.Entities
{
    public class EntidadeBase : EntityBase
    {
        public EntidadeBase()
        {
            DataCadastro = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }

        public DateTime DataCadastro { get; protected set; }
        public DateTime DataAlteracao { get; protected set; }
    }
}
