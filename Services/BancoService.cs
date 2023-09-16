using AutoMapper;
using IntegraBrasilAPI.Dtos;
using IntegraBrasilAPI.Interfaces;

namespace IntegraBrasilAPI.Services
{
    public class BancoService : IBancoService
    {
        private readonly IMapper _mapper;
        private readonly IBrasilApi _brasilApi;

        public BancoService(IMapper mapper, IBrasilApi brasilApi)
        {
            _mapper = mapper;
            _brasilApi = brasilApi;
        }

        public async Task<ResponseBase<List<BancoResponse>>> GetBancoAsync()
        {
            var bancoList = await _brasilApi.BuscarTodosBancos();
            return _mapper.Map<ResponseBase<List<BancoResponse>>>(bancoList);
        }

        public async Task<ResponseBase<BancoResponse>> GetBancoByIdAsync(string codigoBanco)
        {
            var banco = await _brasilApi.BuscarBanco(codigoBanco);
            return _mapper.Map<ResponseBase<BancoResponse>>(banco);
        }
    }
}
