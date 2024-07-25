using Aec.Brasil.Domain.Common.Extensions;
using Aec.Brasil.Domain.Validators.Cidade;
using Aec.Brasil.Tests.Common;
using Aec.Brasil.Tests.WorkingData;
using System;
using System.Linq;
using Xunit;

namespace Aec.Brasil.Tests.Domain.Cidade
{
    [Collection("Aec.Brasil.Tests")]
    public class CidadeCriacaoValidatorTest : InitializeFixture<WorkingDataBase>
    {
        private const string UsuarioTeste = "usuario.criacao";
        private const string GuidTeste = "0D1D769A-54C6-4250-80FB-C3380F7C941B";
        private const string GuidVazioTeste = "00000000-0000-0000-0000-000000000000";
        private const string TextoVazioTeste = "";
        private const int IdIntegracaoTeste = 31;
        private const string NomeTeste = "Nome Criação de Cidade Teste 1";
        private const string EstadoTeste = "RJ";
        private const string AtualizadoEmTeste = "2024-05-26";

        private readonly ICidadeCriacaoValidator _validator;

        public CidadeCriacaoValidatorTest()
        {
            _validator = Resolve<ICidadeCriacaoValidator>();
        }

        [Fact]
        public void TestarCidadeCriacaoValidatorEntidadeValida()
        {
            var cidade = new Aec.Brasil.Domain.Entities.Cidade(UsuarioTeste)
            {
                Id = Guid.NewGuid(),
                IdIntegracao = IdIntegracaoTeste,
                Nome = NomeTeste,
                Estado = EstadoTeste,
                AtualizadoEm = AtualizadoEmTeste.ToDateTimeNotNull()
            };

            var result = _validator.Validar(cidade);

            Assert.True(result.Errors.Count == 0);
        }

        [Fact]
        public void TestarCidadeCriacaoValidatorEntidadeSemDadosControle()
        {
            var cidade = new Aec.Brasil.Domain.Entities.Cidade()
            {
                Id = Guid.NewGuid(),
                IdIntegracao = IdIntegracaoTeste,
                Nome = NomeTeste,
                Estado = EstadoTeste,
                AtualizadoEm = AtualizadoEmTeste.ToDateTimeNotNull()
            };

            var result = _validator.Validar(cidade);

            var valido = result.Errors.Count > 0
                && result.Errors.FirstOrDefault(x => x.ErrorMessage.Contains("Criado Por")) != null
                && result.Errors.FirstOrDefault(x => x.ErrorMessage.Contains("Criado Em")) != null;

            Assert.True(valido);
        }


        [Theory]
        [InlineData(GuidVazioTeste, NomeTeste, IdIntegracaoTeste, EstadoTeste, AtualizadoEmTeste, "O atributo Id é obrigatório")]
        [InlineData(GuidTeste, TextoVazioTeste, IdIntegracaoTeste, EstadoTeste, AtualizadoEmTeste, "O atributo Nome é obrigatório")]
        [InlineData(GuidTeste, null, IdIntegracaoTeste, EstadoTeste, AtualizadoEmTeste, "O atributo Nome é obrigatório")]
        [InlineData(GuidTeste, NomeTeste, 0, EstadoTeste, AtualizadoEmTeste, "O atributo Id Integracao deve ser maior que 0(zero)")]
        [InlineData(GuidTeste, NomeTeste, IdIntegracaoTeste, TextoVazioTeste, AtualizadoEmTeste, "O atributo Estado é obrigatório")]
        public void TestarCidadeCriacaoValidatorEntidadeInvalida(Guid id, string nome, int idIntegracaoTeste, string estado, string atualizadoEm, string mensagem)
        {
            var cidade = new Aec.Brasil.Domain.Entities.Cidade(UsuarioTeste)
            {
                Id = id,
                Nome = nome,
                IdIntegracao = idIntegracaoTeste,
                Estado = estado,
                AtualizadoEm = atualizadoEm.ToDateTimeNotNull()
            };

            var result = _validator.Validar(cidade);

            Assert.True(result.Errors.Count == 1 && result.Errors.FirstOrDefault(x => x.ErrorMessage == mensagem) != null);
        }

    }
}
