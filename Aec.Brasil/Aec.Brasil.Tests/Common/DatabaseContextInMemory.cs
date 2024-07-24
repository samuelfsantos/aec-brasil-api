using Microsoft.EntityFrameworkCore;
using Aec.Brasil.Data;
using Aec.Brasil.Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace Aec.Brasil.Tests.Common
{
    public class DatabaseContextInMemory
    {
        private static AecBrasilContext _context { get; set; }
        public static AecBrasilContext Context
        {
            get { return _context; }
        }

        private static List<Entity> _entities;
        public static List<Entity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = new List<Entity>();

                return _entities;
            }
        }

        public static AecBrasilContext Create()
        {
            if (_context == null)
            {
                var options = new DbContextOptionsBuilder<AecBrasilContext>()
                    .UseInMemoryDatabase(databaseName: "Aec.Brasil")
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    .Options;

                _context = new AecBrasilContext(options);
            }

            SaveDataContext();

            return _context;
        }

        private static void SaveDataContext()
        {
            foreach (var entity in Entities)
                _context.Add(entity);

            var entries = _context.ChangeTracker.Entries().ToList();

            foreach (var entry in entries.Where(x => x.Entity is Entity && x.State == EntityState.Added))
                (entry.Entity as Entity).GerarDadosControleCriacao("usuario.padrao");

            _context.SaveChanges();

            foreach (var entry in entries)
                entry.State = EntityState.Detached;

            Entities.Clear();
        }
    }
}
