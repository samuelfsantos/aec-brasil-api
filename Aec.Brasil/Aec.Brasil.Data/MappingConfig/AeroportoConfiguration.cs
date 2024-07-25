using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Aec.Brasil.Domain.Entities;

namespace Aec.Brasil.Data.MappingConfig
{
    public class AeroportoConfiguration : EntityTypeConfigurationBase<Aeroporto>
    {
        public override void Configure(EntityTypeBuilder<Aeroporto> entity)
        {
            base.Configure(entity);

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("IdAeroporto");

            entity.Property(e => e.CodigoIcao).IsRequired().HasMaxLength(4).IsUnicode(false);
            entity.Property(e => e.Umidade).IsRequired();
            entity.Property(e => e.Visibilidade).IsRequired().HasMaxLength(20).IsUnicode(false);
            entity.Property(e => e.PressaoAtmosferica).IsRequired();
            entity.Property(e => e.Vento).IsRequired();
            entity.Property(e => e.DirecaoVento).IsRequired();
            entity.Property(e => e.Condicao).IsRequired().HasMaxLength(2).IsUnicode(false);
            entity.Property(e => e.CondicaoDesc).IsRequired().HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.Temp).IsRequired();
            entity.Property(e => e.AtualizadoEm).IsRequired();

            entity.HasIndex(e => e.CodigoIcao).HasName("IDX_Aeroporto_CodigoIcao");

            entity.ToTable("Aeroporto", "AecBrasil");
        }
    }
}
