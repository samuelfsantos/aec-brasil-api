using System;

namespace Aec.Brasil.Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public string CriadoPor { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public string AlteradoPor { get; private set; }
        public DateTime? AlteradoEm { get; private set; }

        public virtual void GerarDadosControleCriacao(string usuario)
        {
            CriadoPor = usuario;
            CriadoEm = DateTime.Now;
        }

        public virtual void GerarDadosControleAlteracao(string usuario)
        {
            AlteradoPor = usuario;
            AlteradoEm = DateTime.Now;
        }

        protected virtual void GerarDadosControle(string criadoPor, string alteradoPor, DateTime criadoEm, DateTime? alteradoEm) 
        {
            CriadoEm = criadoEm;
            CriadoPor = criadoPor;
            AlteradoEm = alteradoEm;
            AlteradoPor = alteradoPor;
        }
    }
}
