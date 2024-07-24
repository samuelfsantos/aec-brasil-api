using Microsoft.EntityFrameworkCore;
using Aec.Brasil.Data.MappingConfig;
using Aec.Brasil.Domain.Entities;

namespace Aec.Brasil.Data
{
    public partial class AecBrasilContext : DbContext
	{
		public AecBrasilContext(DbContextOptions<AecBrasilContext> options) : base(options) { }

        public virtual DbSet<Clima> Clima { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.HasDefaultSchema("AecBrasil");

            modelBuilder.ApplyConfiguration(new CidadeConfiguration());
            modelBuilder.ApplyConfiguration(new ClimaConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
