using MediatR;
using Aec.Brasil.Application.Commands.Cidade;
using Aec.Brasil.Domain.Common.Extensions;
using Aec.Brasil.Domain.Common.Notification;
using Aec.Brasil.Tests.Common;
using Aec.Brasil.Tests.WorkingData.Cidade;
using System.Linq;
using Xunit;

namespace Aec.Brasil.Tests.Application.Commands.Cidade
{
    [Collection("Aec.Brasil.Tests")]
    public class CriarCidadeCommandHandlerTest : InitializeFixture<CriarCidadeCommandHandlerTestData>
    {
        private readonly IMediator _mediator;
        private readonly INotificationDomain<NotificationDomainMessage> _notificationDomain;

        private const string NomeTeste = "Nome Criação de Cidade Handler Teste 1";
        private const int IdIntegracaoTeste = 40;
        private const string EstadoTeste = "AA";
        private const string AtualizadoEmTeste = "2024-01-25";

        public CriarCidadeCommandHandlerTest()
        {
            _mediator = Resolve<IMediator>();

            _notificationDomain = Resolve<INotificationDomain<NotificationDomainMessage>>();
        }

        [Fact]
        public void CriarCidadeDadosValidos()
        {
            var command = new CriacaoCidadeCommand()
            {
                Nome = NomeTeste,
                IdIntegracao = IdIntegracaoTeste,
                Estado = EstadoTeste,
                AtualizadoEm = AtualizadoEmTeste.ToDateTime().GetValueOrDefault()
            };

            var results = _mediator.Send(command);

            Assert.True(results.Exception == null && !_notificationDomain.HasNotifications());
        }
    }
}
