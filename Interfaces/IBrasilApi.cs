using IntegraBrasilAPI.Dtos;
using IntegraBrasilAPI.Models;

namespace IntegraBrasilAPI.Interfaces
{
    public interface IBrasilApi
    {
        Task<ResponseBase<EnderecoModel>> BuscarEnderecoPorCep(string cep);
        Task<ResponseBase<List<BancoModel>>> BuscarTodosBancos();
        Task<ResponseBase<BancoModel>> BuscarBanco(string codigoBanco);
    }
}
