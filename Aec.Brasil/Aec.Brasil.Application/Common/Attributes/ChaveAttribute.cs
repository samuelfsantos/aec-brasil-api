using System;

namespace Aec.Brasil.Application.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class ChaveAttribute : Attribute
    {
        private readonly string _chave;

        public ChaveAttribute(string value)
        {
            _chave = value;
        }

        public virtual string Chave { get { return _chave; } }
    }
}
