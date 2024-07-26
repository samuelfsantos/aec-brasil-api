using Aec.Brasil.Domain.Common;
using System;

namespace Aec.Brasil.Domain.Entities
{
    public partial class LogErro : Entity
    {
        public LogErro()
        {
        }
        public LogErro(string criadoPor) : this()
        {
            GerarDadosControleCriacao(criadoPor);
        }
        public string Message { get; set; }
        public string Detail { get; set; }
        public string StackTrace { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
