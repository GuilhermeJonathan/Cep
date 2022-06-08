namespace Default.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        protected Usuario() : base() { }

        public string Nome { get; private set; }
        public string Login { get; private set; }
        public bool Ativo { get; private set; }
    }
}
