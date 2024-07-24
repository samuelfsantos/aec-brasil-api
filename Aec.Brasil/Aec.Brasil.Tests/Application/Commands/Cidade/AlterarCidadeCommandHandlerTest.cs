using MediatR;
using Aec.Brasil.Application.Commands.Cidade;
using Aec.Brasil.Domain.Common.Notification;
using Aec.Brasil.Tests.Common;
using Xunit;
using Aec.Brasil.Tests.WorkingData.Cidade;

namespace Aec.Brasil.Tests.Application.Commands.Cidade
{
    [Collection("Aec.Brasil.Tests")]
    public class AlterarCidadeCommandHandlerTest : InitializeFixture<AlterarCidadeCommandHandlerTestData>
    {
        private readonly IMediator _mediator;
        private readonly INotificationDomain<NotificationDomainMessage> _notificationDomain;

        private const string NomeTeste = "Nome Alteração de Cidade Handler Teste 1";
        private const string EstadoTeste = "AA";

        public AlterarCidadeCommandHandlerTest()
        {
            _mediator = Resolve<IMediator>();

            _notificationDomain = Resolve<INotificationDomain<NotificationDomainMessage>>();
        }

        [Fact]
        public void AlterarCidadeDadosValidos()
        {
            var idCidade = KeyContainer.ObterId(typeof(Aec.Brasil.Domain.Entities.Cidade), WorkingData.Chave_CidadeHandler_Alteracao_1);

            var command = new AlteracaoCidadeCommand()
            {
                IdCidade = idCidade,
                Nome = NomeTeste,
                Estado = EstadoTeste
            };

            var results = _mediator.Send(command);

            Assert.True(results.Exception == null && !_notificationDomain.HasNotifications());
        }
    }
}
