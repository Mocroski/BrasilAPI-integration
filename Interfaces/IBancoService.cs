using IntegraBrasilAPI.Dtos;

namespace IntegraBrasilAPI.Interfaces
{
    public interface IBancoService
    {
        Task<ResponseBase<List<BancoResponse>>> GetBancoAsync();
        Task<ResponseBase<BancoResponse>> GetBancoByIdAsync(string codigoBanco);
    }
}
