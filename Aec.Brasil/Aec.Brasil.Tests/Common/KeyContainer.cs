using System;
using System.Collections.Generic;
using System.Linq;

namespace Aec.Brasil.Tests.Common
{
    public class KeyContainer
    {
        private class Key {
            public string ObjectName { get; set; }
            public List<KeyValuePair<string, Guid>> IdList { get; set; }
        }

        private static List<Key> _keys;
        private static List<Key> Keys
        {
            get
            {
                if (_keys == null) _keys = new List<Key>();

                return _keys;
            }
        }

        public static Guid CriarId(Type objectType, string chave)
        {
            var container = Keys.Where(x => x.ObjectName == objectType.Name).FirstOrDefault();

            if (container == null)
            {
                container = new Key() { ObjectName = objectType.Name, IdList = new List<KeyValuePair<string, Guid>>() };

                Keys.Add(container);
            }

            var id = container.IdList.Where(x => x.Key == chave).FirstOrDefault();

            if (id.Key != null)
                throw new Exception("Chave existente: " + chave);

            id = new KeyValuePair<string, Guid>(chave, Guid.NewGuid());

            container.IdList.Add(id);

            return id.Value;
        }

        public static Guid ObterId(Type objectType, string chave)
        {
            var container = Keys.Where(x => x.ObjectName == objectType.Name).FirstOrDefault();

            if (container == null)
                throw new Exception("Container inexistente: " + objectType.Name);

            var id = container.IdList.Where(x => x.Key == chave).FirstOrDefault();

            if (id.Key == null)
                throw new Exception("Identificador inexistente: " + chave);

            return id.Value;
        }

        public static List<Guid> ObterRangeId(Type objectType)
        {
            var container = Keys.Where(x => x.ObjectName == objectType.Name).FirstOrDefault();

            if (container == null)
                throw new Exception("Container inexistente: " + objectType.Name);

            var ids = container.IdList.Select(x => x.Value).ToList();

            return ids;
        }
    }
}
