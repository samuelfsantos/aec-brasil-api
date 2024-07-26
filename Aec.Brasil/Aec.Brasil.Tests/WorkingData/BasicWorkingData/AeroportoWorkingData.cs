using Aec.Brasil.Tests.Common;
using System;

namespace Aec.Brasil.Tests.WorkingData
{
    public class AeroportoWorkingData
    {
        private static bool criado;

        public static void Create()
        {
            if (!criado)
            {
                criado = true;

                CriarAeroportos();
            }
        }

        private static void CriarAeroportos()
        {
            CriarAeroporto("chave.aeroporto.1", 26, ">10000", "SBMG", 1022, 11, 70, "ps", "Predomínio de Sol", 27, new DateTime(2024, 07, 01));
            CriarAeroporto("chave.aeroporto.2", 27, ">10000", "SBMG", 1021, 12, 71, "ps", "Predomínio de Sol", 28, new DateTime(2024, 07, 05));
            CriarAeroporto("chave.aeroporto.3", 28, ">10000", "SBSP", 1020, 13, 72, "ps", "Predomínio de Sol", 29, new DateTime(2024, 07, 01));
            CriarAeroporto("chave.aeroporto.4", 29, ">10000", "SBSC", 1019, 14, 73, "ps", "Predomínio de Sol", 30, new DateTime(2024, 07, 02));
            CriarAeroporto("chave.aeroporto.5", 30, ">10000", "SBRJ", 1018, 15, 74, "ps", "Predomínio de Sol", 31, new DateTime(2024, 07, 03));
        }

        private static void CriarAeroporto(
            string chave,
            int umidade,
            string visibilidade,
            string codigoIcao,
            int pressaoAtmosferica,
            int vento,
            int direcaoVento,
            string condicao,
            string condicaoDesc,
            int temp,
            DateTime atualizadoEm)
        {
            DatabaseContextInMemory.Entities.Add(new Aec.Brasil.Domain.Entities.Aeroporto()
            {
                Id = KeyContainer.CriarId(typeof(Aec.Brasil.Domain.Entities.Aeroporto), chave),
                Umidade = umidade,
                Visibilidade = visibilidade,
                CodigoIcao = codigoIcao,
                PressaoAtmosferica = pressaoAtmosferica,
                Vento = vento,
                DirecaoVento = direcaoVento,
                Condicao = condicao,
                CondicaoDesc = condicaoDesc,
                Temp = temp,
                AtualizadoEm = atualizadoEm
            });
        }
    }
}
