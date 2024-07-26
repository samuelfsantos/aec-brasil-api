using System.Collections.Generic;
using Aec.Brasil.Domain.Entities;

namespace Aec.Brasil.Domain.Repositories
{
    public interface ILogErroRepository
    {
        IEnumerable<LogErro> Obter();
    }
}
