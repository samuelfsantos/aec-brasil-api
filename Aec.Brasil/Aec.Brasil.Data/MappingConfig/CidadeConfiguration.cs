using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Aec.Brasil.Domain.Entities;

namespace Aec.Brasil.Data.MappingConfig
{
    public class CidadeConfiguration : EntityTypeConfigurationBase<Cidade>
    {
        public override void Configure(EntityTypeBuilder<Cidade> entity)
        {
            base.Configure(entity);

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("IdCidade");

            entity.Property(e => e.IdIntegracao).IsRequired();
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(250).IsUnicode(false);
            entity.Property(e => e.Estado).IsRequired().HasMaxLength(2).IsUnicode(false);
            entity.Property(e => e.AtualizadoEm).IsRequired();

            entity.HasIndex(e => e.IdIntegracao).HasName("IDX_Cidade_IdIntegracao");

            entity.ToTable("Cidade", "AecBrasil");
        }
    }
}
