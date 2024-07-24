using Aec.Brasil.Tests.Common;
using System;

namespace Aec.Brasil.Tests.WorkingData
{
    public class CidadeWorkingData
	{
		private static bool criado;

		public static void Create()
		{
			if (!criado)
			{
				criado = true;

                CriarCidades();
			}
		}

        private static void CriarCidades()
        {
            CriarCidade("chave.cidade.1", 1, "Cidade teste 1", "MG", new DateTime(2024, 07, 01));
            CriarCidade("chave.cidade.2", 1, "Cidade teste 1", "MG", new DateTime(2024, 07, 05));
            CriarCidade("chave.cidade.3", 2, "Cidade teste 2", "SP", new DateTime(2024, 07, 01));
            CriarCidade("chave.cidade.4", 3, "Cidade teste 3", "SC", new DateTime(2024, 07, 02));
            CriarCidade("chave.cidade.5", 4, "Cidade teste 4", "RJ", new DateTime(2024, 07, 03));
        }

        private static void CriarCidade(string chave, int idIntegracao, string nome, string estado, DateTime atualizadoEm)
        {
            DatabaseContextInMemory.Entities.Add(new Aec.Brasil.Domain.Entities.Cidade()
            {
                Id = KeyContainer.CriarId(typeof(Aec.Brasil.Domain.Entities.Cidade), chave),
                IdIntegracao = idIntegracao,
                Nome = nome,
                Estado = estado,
                AtualizadoEm = atualizadoEm
            });
        }
    }
}
