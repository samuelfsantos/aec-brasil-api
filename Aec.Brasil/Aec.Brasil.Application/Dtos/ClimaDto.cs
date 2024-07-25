using System;

namespace Aec.Brasil.Application.Dtos
{
    public class ClimaDto
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string Condicao { get; set; }
        public string CondicaoDesc { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int IndiceUV { get; set; }
    }
}
