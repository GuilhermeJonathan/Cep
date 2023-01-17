using Default.Domain.Entities;
using Default.Domain.Repositories;
using Default.Infra.Data.Context;
using Default.Infra.Data.Repository.Base.UnitOfWork;

namespace Default.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DefaultDbContext context) : base(context)
        {

        }
    }
}
