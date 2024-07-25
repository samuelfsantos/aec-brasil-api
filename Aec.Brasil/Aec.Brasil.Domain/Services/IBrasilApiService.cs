using Aec.Brasil.Domain.Entities;

namespace Aec.Brasil.Domain.Services
{
    public interface IBrasilApiService
    {
        Cidade ObterCidadePorId(int id);
        Aeroporto ObterAeroportoPorCodigo(string codigo);
    }
}
