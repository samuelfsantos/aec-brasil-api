using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Aec.Brasil.Domain.Entities;

namespace Aec.Brasil.Data.MappingConfig
{
    public class ClimaConfiguration : EntityTypeConfigurationBase<Clima>
    {
        public override void Configure(EntityTypeBuilder<Clima> entity)
        {
            base.Configure(entity);

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("IdClima");

            entity.Property(e => e.Data).IsRequired();
            entity.Property(e => e.Condicao).IsRequired().HasMaxLength(2).IsUnicode(false);
            entity.Property(e => e.CondicaoDesc).IsRequired().HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.Min).IsRequired();
            entity.Property(e => e.Max).IsRequired();
            entity.Property(e => e.IndiceUV).IsRequired();

            entity.HasOne(d => d.Cidade)
                    .WithMany(p => p.Climas)
                    .HasForeignKey(d => d.IdCidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clima_Cidade");

            entity.HasIndex(e => e.IdCidade).HasName("FKIDX_Clima_Cidade");

            entity.ToTable("Clima", "AecBrasil");
        }
    }
}
