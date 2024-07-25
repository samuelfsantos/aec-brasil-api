using Aec.Brasil.Domain.Common;
using System;

namespace Aec.Brasil.Domain.Entities
{
    public partial class Aeroporto : Entity
    {
        public Aeroporto()
        {
        }
        public Aeroporto(string criadoPor) : this()
        {
            GerarDadosControleCriacao(criadoPor);
        }

        public int Umidade { get; set; }
        public string Visibilidade { get; set; }
        public string CodigoIcao { get; set; }
        public int PressaoAtmosferica { get; set; }
        public int Vento { get; set; }
        public int DirecaoVento { get; set; }
        public string Condicao { get; set; }
        public string CondicaoDesc { get; set; }
        public int Temp { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
