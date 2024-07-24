using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aec.Brasil.Api.Controllers;
using Aec.Brasil.Api.Configurations;
using Aec.Brasil.Application.Commands.Cidade;
using Aec.Brasil.Application.Queries.Cidade;
using Aec.Brasil.Domain.Common;
using Aec.Brasil.Domain.Common.Notification;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Aec.Brasil.Application.Dtos;
using System.Collections.Generic;

namespace Aec.Brasil.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/cidades")]
    public class CidadesController : ControllerBaseCustom
    {
        public CidadesController(
            ILogger<CidadesController> logger,
            INotificationDomain<NotificationDomainMessage> notifications,
            IMediator mediator,            
            IDistributedCache cache) : base(logger, notifications, mediator)
        {
        }

        [HttpGet("id-integracao/{idIntegracao}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdIntegracao(int idIntegracao)
        {
            if (!IsSuccess) return CustomResponse();

            var results = await _mediator.Send(new CidadeQuery() { IdIntegracao = idIntegracao });

            return CustomResponse(results);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CriacaoCidadeCommand command)
        {
            var result = await _mediator.Send(command);

            return CustomResponse(new { IdCidade = result });
        }

        [HttpPut("{idCidade:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(string idCidade, [FromBody] AlteracaoCidadeCommand command)
        {
            ValidarEntradas(idCidade);

            if (!IsSuccess) return CustomResponse();

            command.IdCidade = new Guid(idCidade);

            await _mediator.Send(command);

            return CustomResponse();
        }

        [HttpDelete("{idCidade:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(string idCidade)
        {
            ValidarEntradas(idCidade);

            if (!IsSuccess) return CustomResponse();

            var command = new ExclusaoCidadeCommand() { IdCidade = new Guid(idCidade) };

            await _mediator.Send(command);

            return CustomResponse();
        }
    }
}