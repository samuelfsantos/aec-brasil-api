using Aec.Brasil.Tests.Common;
using System;

namespace Aec.Brasil.Tests.WorkingData
{
    public class ClimaWorkingData
    {
		private static bool criado;

		public static void Create()
		{
			if (!criado)
			{
				criado = true;

                CriarClimas();
			}
		}

        private static void CriarClimas()
        {
            CriarClima("chave.clima.1", new DateTime(2024, 07, 01), "pn", "Parcialmente Nublado", 12, 28, 5, KeyContainer.ObterId(typeof(Aec.Brasil.Domain.Entities.Cidade), "chave.cidade.1"));
            CriarClima("chave.clima.2", new DateTime(2024, 07, 02), "pn", "Parcialmente Nublado", 14, 29, 8, KeyContainer.ObterId(typeof(Aec.Brasil.Domain.Entities.Cidade), "chave.cidade.1"));

            CriarClima("chave.clima.3", new DateTime(2024, 07, 05), "pn", "Parcialmente Nublado", 10, 25, 4, KeyContainer.ObterId(typeof(Aec.Brasil.Domain.Entities.Cidade), "chave.cidade.2"));

            CriarClima("chave.clima.4", new DateTime(2024, 07, 01), "pn", "Parcialmente Nublado", 16, 31, 14, KeyContainer.ObterId(typeof(Aec.Brasil.Domain.Entities.Cidade), "chave.cidade.3"));

            CriarClima("chave.clima.5", new DateTime(2024, 07, 02), "pn", "Parcialmente Nublado", 15, 23, 9, KeyContainer.ObterId(typeof(Aec.Brasil.Domain.Entities.Cidade), "chave.cidade.4"));

            CriarClima("chave.clima.6", new DateTime(2024, 07, 03), "pn", "Parcialmente Nublado", 18, 32, 10, KeyContainer.ObterId(typeof(Aec.Brasil.Domain.Entities.Cidade), "chave.cidade.5"));
            CriarClima("chave.clima.7", new DateTime(2024, 07, 04), "pn", "Parcialmente Nublado", 19, 33, 11, KeyContainer.ObterId(typeof(Aec.Brasil.Domain.Entities.Cidade), "chave.cidade.5"));
        }

        private static void CriarClima(string chave, DateTime data, string condicao, string condicaoDesc, int min, int max, int indiceUV, Guid idCidade)
        {
            DatabaseContextInMemory.Entities.Add(new Aec.Brasil.Domain.Entities.Clima()
            {
                Id = KeyContainer.CriarId(typeof(Aec.Brasil.Domain.Entities.Clima), chave),
                Data = data,
                Condicao = condicao,
                CondicaoDesc = condicaoDesc,
                Min = min,
                Max = max,
                IndiceUV = indiceUV,
                IdCidade = idCidade
            });
        }
    }
}
