using MediatR;
using Aec.Brasil.Application.Queries.Cidade;
using Aec.Brasil.Tests.Common;
using Aec.Brasil.Tests.WorkingData;
using Xunit;

namespace Aec.Brasil.Tests.Application.Queries.Cidade
{
    [Collection("Aec.Brasil.Tests")]
    public class ObterCidadeQueryHandlerTest : InitializeFixture<WorkingDataBase>
    {
        private readonly IMediator _mediator;

        public ObterCidadeQueryHandlerTest()
        {
            _mediator = Resolve<IMediator>();
        }

        [Fact]
        public void ObtemCidadeExistente()
        {
            var results = _mediator.Send(new CidadeQuery() { IdIntegracao = 1 });

            Assert.True(results.Result != null && results.Result.Count > 0);
        }
    }
}
