using Default.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Default.Infra.Data.EntityMappingConfig
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");

            builder.Property(P => P.Id).HasColumnName("ID");
            builder.Property(p => p.Login).HasColumnName("LOGIN");
            builder.Property(p => p.Nome).HasColumnName("NOME");
            builder.Property(p => p.Ativo).HasColumnName("ATIVO");

            builder.Property(p => p.DataCadastro).HasColumnName("DT_CRIACAO");
            builder.Property(p => p.DataAlteracao).HasColumnName("DT_ALTERACAO");
        }
    }
}
