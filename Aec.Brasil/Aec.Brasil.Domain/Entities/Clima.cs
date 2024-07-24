using Aec.Brasil.Domain.Common;
using System;

namespace Aec.Brasil.Domain.Entities
{
    public partial class Clima : Entity
    {
        public Clima()
        {
        }
        public Clima(string criadoPor) : this()
        {
            GerarDadosControleCriacao(criadoPor);
        }

        public DateTime Data { get; set; }
        public string Condicao { get; set; }
        public string CondicaoDesc { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int IndiceUV { get; set; }

        public Guid IdCidade { get; set; }

        public virtual Cidade Cidade { get; set; }
    }
}
