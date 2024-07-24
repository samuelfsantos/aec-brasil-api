using MediatR;
using Aec.Brasil.Application.Commands.Cidade;
using Aec.Brasil.Domain.Common.Notification;
using Aec.Brasil.Tests.Common;
using Aec.Brasil.Tests.WorkingData.Cidade;
using Xunit;

namespace Aec.Brasil.Tests.Application.Commands.Cidade
{
    [Collection("Aec.Brasil.Tests")]
    public class ExcluirCidadeCommandHandlerTest : InitializeFixture<ExcluirCidadeCommandHandlerTestData>
    {
        private readonly IMediator _mediator;
        private readonly INotificationDomain<NotificationDomainMessage> _notificationDomain;

        public ExcluirCidadeCommandHandlerTest()
        {
            _mediator = Resolve<IMediator>();

            _notificationDomain = Resolve<INotificationDomain<NotificationDomainMessage>>();
        }

        [Fact]
        public void ExcluirCidadeExistente()
        {
            var command = new ExclusaoCidadeCommand()
            {
                IdCidade = KeyContainer.ObterId(typeof(Aec.Brasil.Domain.Entities.Cidade), WorkingData.Chave_CidadeHandler_Exclusao_1)
            };

            var results = _mediator.Send(command);

            Assert.True(results.Exception == null && !_notificationDomain.HasNotifications());
        }
    }
}
