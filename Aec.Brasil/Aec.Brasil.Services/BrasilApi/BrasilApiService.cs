using Newtonsoft.Json;
using RestSharp;
using System.Net;
using Aec.Brasil.Domain.Entities;
using Aec.Brasil.Domain.Services;
using Aec.Brasil.Services.Configurations;
using Aec.Brasil.Services.BrasilApi.Models;

namespace Aec.Brasil.Services.BrasilApi
{
    public class BrasilApiService : IBrasilApiService
    {
        private readonly BrasilApiServiceConfiguration _configuration;
        public BrasilApiService(BrasilApiServiceConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Cidade ObterCidadePorId(int id)
        {
            try
            {
                var client = new RestClient(_configuration.Url);
                var resquest = new RestRequest($"/cptec/v1/clima/previsao/{id}");
                var response = client.ExecuteGet(resquest);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var apiResponse = JsonConvert.DeserializeObject<CidadeBrasilApi>(response.Content);

                    var cidade = new Cidade("usuario.generico");
                    cidade.Id = Guid.NewGuid();
                    cidade.IdIntegracao = id;
                    cidade.Nome = apiResponse.cidade;
                    cidade.Estado = apiResponse.estado;
                    cidade.AtualizadoEm = apiResponse.atualizado_em;                    

                    var climas = apiResponse.clima.Select(x => new Clima("usuario.generico")
                    {
                        Id = Guid.NewGuid(),
                        Data = x.data,
                        Condicao = x.condicao,
                        CondicaoDesc = x.condicao_desc,
                        Min = x.min,
                        Max = x.max,
                        IndiceUV = x.indice_uv,
                        IdCidade = cidade.Id,
                        Cidade = cidade
                    }).ToList();

                    cidade.Climas = climas;

                    return cidade;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Aeroporto ObterAeroportoPorCodigo(string codigo)
        {
            try
            {
                var client = new RestClient(_configuration.Url);
                var resquest = new RestRequest($"/cptec/v1/clima/aeroporto/{codigo}");
                var response = client.ExecuteGet(resquest);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var apiResponse = JsonConvert.DeserializeObject<AeroportoBrasilApi>(response.Content);

                    var aeroporto = new Aeroporto("usuario.generico");
                    aeroporto.Id = Guid.NewGuid();
                    aeroporto.CodigoIcao = apiResponse.codigo_icao;
                    aeroporto.Umidade = apiResponse.umidade;
                    aeroporto.Visibilidade = apiResponse.visibilidade;
                    aeroporto.PressaoAtmosferica = apiResponse.pressao_atmosferica;
                    aeroporto.Vento = apiResponse.vento;
                    aeroporto.DirecaoVento = apiResponse.direcao_vento;
                    aeroporto.Condicao = apiResponse.condicao;
                    aeroporto.CondicaoDesc = apiResponse.condicao_desc;
                    aeroporto.Temp = apiResponse.temp;
                    aeroporto.AtualizadoEm = apiResponse.atualizado_em;

                    return aeroporto;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
