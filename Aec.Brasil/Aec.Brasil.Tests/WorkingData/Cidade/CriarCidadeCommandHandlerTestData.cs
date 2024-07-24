using Aec.Brasil.Tests.Common;
using System;

namespace Aec.Brasil.Tests.WorkingData.Cidade
{
    public class CriarCidadeCommandHandlerTestData : WorkingDataBase
    {
        private static bool criado;
        public string Chave_CidadeHandler_Criacao_1 { get; }
        public int IdIntegracao_CidadeHandler_Criacao_1 { get; }
        private string Nome_CidadeHandler_Criacao_1 { get; }
        private string Estado_CidadeHandler_Criacao_1 { get; }
        private DateTime AtualizadoEm_CidadeHandler_Criacao_1 { get; }

        public CriarCidadeCommandHandlerTestData()
        {
            Chave_CidadeHandler_Criacao_1 = "chave.cidade.handler.criacao.1";
            IdIntegracao_CidadeHandler_Criacao_1 = 11;
            Nome_CidadeHandler_Criacao_1 = "Nome da Cidade Handler Criação 1";
            Estado_CidadeHandler_Criacao_1 = "SP";
            AtualizadoEm_CidadeHandler_Criacao_1 = new DateTime(2024, 06, 20);

            MontarDadosParaTeste();
        }

        private void MontarDadosParaTeste()
        {
            if (!criado)
            {
                CriarCidade(
                     Chave_CidadeHandler_Criacao_1,
                     IdIntegracao_CidadeHandler_Criacao_1,
                     Nome_CidadeHandler_Criacao_1,
                     Estado_CidadeHandler_Criacao_1,
                     AtualizadoEm_CidadeHandler_Criacao_1);

                criado = true;
            }
        }

        private void CriarCidade(string chave, int idIntegracao, string nome, string estado, DateTime atualizadoEm)
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
