using Microsoft.EntityFrameworkCore;
using Aec.Brasil.Domain.Entities;
using Aec.Brasil.Domain.Repositories;
using System;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Dapper;

namespace Aec.Brasil.Data.Repositories
{
    public class LogErroRepository : ILogErroRepository
    {
        protected readonly AecBrasilContext _context;

        public LogErroRepository(AecBrasilContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<LogErro> Obter()
        {
            using (var connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();
                var logs = connection.Query<LogErro>(@"
                    SELECT 
                        IdLogErro AS Id,
                        Message,
                        Detail,
                        StackTrace,
                        Timestamp
                    FROM AecBrasil.LogErro(NOLOCK)
                    ORDER BY Timestamp DESC");
                return logs.ToList();
            }
        }
    }
}
