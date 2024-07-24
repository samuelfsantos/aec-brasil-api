using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Aec.Brasil.Domain.Common;

namespace Aec.Brasil.Data.MappingConfig
{
    public class EntityTypeConfigurationBase<TBase> : IEntityTypeConfiguration<TBase> where TBase : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.Property(e => e.AlteradoPor).HasMaxLength(80).IsUnicode(false);
            builder.Property(e => e.CriadoPor).IsRequired().HasMaxLength(80).IsUnicode(false);
            builder.Property(e => e.AlteradoEm).HasColumnType("datetime");
            builder.Property(e => e.CriadoEm).IsRequired().HasColumnType("datetime");
        }
    }
}
