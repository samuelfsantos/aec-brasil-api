using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Aec.Brasil.Domain.Entities;

namespace Aec.Brasil.Data.MappingConfig
{
    public class LogErroConfiguration : EntityTypeConfigurationBase<LogErro>
    {
        public override void Configure(EntityTypeBuilder<LogErro> entity)
        {
            base.Configure(entity);

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("IdLogErro");

            entity.Property(e => e.Message).IsRequired().HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.Detail).IsRequired().HasMaxLength(5000).IsUnicode(false);
            entity.Property(e => e.StackTrace).IsRequired().HasMaxLength(15000).IsUnicode(false);
            entity.Property(e => e.Timestamp).IsRequired();

            entity.ToTable("LogErro", "AecBrasil");
        }
    }
}
