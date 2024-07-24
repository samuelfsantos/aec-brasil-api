using System;
using System.Collections.Generic;

namespace Aec.Brasil.Application.Dtos
{
    public class CidadeDto
    {
        public int IdIntegracao { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public DateTime CriadoEm { get; set; }
        public ICollection<ClimaDto> Climas { get; set; }
    }
}
