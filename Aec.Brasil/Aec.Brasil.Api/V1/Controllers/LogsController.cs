using Aec.Brasil.Api.Controllers;
using Aec.Brasil.Domain.Common.Notification;
using Aec.Brasil.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Aec.Brasil.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/logs")]
    public class LogsController : ControllerBaseCustom
    {
        private readonly ILogErroRepository _logErroRepository;
        private readonly IConfiguration _configuration;
        public LogsController(
            ILogger<LogsController> logger,
            INotificationDomain<NotificationDomainMessage> notifications,
            IMediator mediator,
            ILogErroRepository logErroRepository,
            IConfiguration configuration) : base(logger, notifications, mediator)
        {
            _logErroRepository = logErroRepository;
            _configuration = configuration;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            var logs = _logErroRepository.Obter();

            return Ok(logs);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] string mensagem)
        {
            const int TAMANHO_MAXIMO = 50;
            mensagem = string.IsNullOrWhiteSpace(mensagem) ? string.Empty : mensagem;
            mensagem = mensagem.Length > TAMANHO_MAXIMO ? mensagem.Substring(0, TAMANHO_MAXIMO) : mensagem;

            throw new System.Exception(mensagem);
        }
    }
}