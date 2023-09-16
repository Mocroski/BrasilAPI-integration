using IntegraBrasilAPI.Dtos;

namespace IntegraBrasilAPI.Interfaces
{
    public interface IEnderecoService
    {
        Task<ResponseBase<EnderecoResponse>> BuscarEndereco(string cep);
    }
}
