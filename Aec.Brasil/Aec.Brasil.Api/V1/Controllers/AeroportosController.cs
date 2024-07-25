using Aec.Brasil.Api.Controllers;
using Aec.Brasil.Application.Commands.Aeroporto;
using Aec.Brasil.Application.Queries.Aeroporto;
using Aec.Brasil.Domain.Common.Notification;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Aec.Brasil.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/aeroportos")]
    public class AeroportosController : ControllerBaseCustom
    {
        public AeroportosController(
            ILogger<AeroportosController> logger,
            INotificationDomain<NotificationDomainMessage> notifications,
            IMediator mediator) : base(logger, notifications, mediator)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            if (!IsSuccess) return CustomResponse();

            var results = await _mediator.Send(new AeroportoQuery() { });

            return CustomResponse(results);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CriacaoAeroportoCommand command)
        {
            var result = await _mediator.Send(command);

            return CustomResponse(new { IdAeroporto = result });
        }

        [HttpPut("{idAeroporto:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(string idAeroporto, [FromBody] AlteracaoAeroportoCommand command)
        {
            ValidarEntradas(idAeroporto);

            if (!IsSuccess) return CustomResponse();

            command.IdAeroporto = new Guid(idAeroporto);

            await _mediator.Send(command);

            return CustomResponse();
        }

        [HttpDelete("{idAeroporto:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string idAeroporto)
        {
            ValidarEntradas(idAeroporto);

            if (!IsSuccess) return CustomResponse();

            var command = new ExclusaoAeroportoCommand() { IdAeroporto = new Guid(idAeroporto) };

            await _mediator.Send(command);

            return CustomResponse();
        }

        [HttpGet("{codigoIcao}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByCodigoIcao(string codigoIcao)
        {
            if (!IsSuccess) return CustomResponse();

            var results = await _mediator.Send(new AeroportoQuery() { CodigoIcao = codigoIcao });

            return CustomResponse(results);
        }

        [HttpPost("integracao/codigo-icao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostIntegracaoByCodigoIcao([FromBody] ExecutarIntegracaoAeroportoPorIdCommand command)
        {
            var result = await _mediator.Send(command);

            return CustomResponse(new { CodigoIcao = result });
        }
    }
}