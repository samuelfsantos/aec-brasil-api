using Aec.Brasil.Domain.Common;
using System;
using System.Collections.Generic;

namespace Aec.Brasil.Domain.Entities
{
    public partial class Cidade : Entity
    {
        public Cidade()
        {
            Climas = new HashSet<Clima>();
        }
        public Cidade(string criadoPor) : this()
        {
            GerarDadosControleCriacao(criadoPor);
        }

        public int IdIntegracao { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public virtual ICollection<Clima> Climas { get; set; }
    }
}
