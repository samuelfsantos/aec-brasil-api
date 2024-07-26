using Aec.Brasil.Api.Controllers;
using Aec.Brasil.Application.Commands.Aeroporto;
using Aec.Brasil.Application.Queries.Cidade;
using Aec.Brasil.Domain.Common.Notification;
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
        private readonly IConfiguration _configuration;
        public LogsController(
            ILogger<LogsController> logger,
            INotificationDomain<NotificationDomainMessage> notifications,
            IMediator mediator,
            IConfiguration configuration) : base(logger, notifications, mediator)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            return Ok(new
            {
                DefaultConnection = _configuration["ConnectionStrings:DefaultConnection"]
            });
        }

        [HttpPost("erro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] string mensagem)
        {
            throw new System.Exception(mensagem);
        }
    }
}