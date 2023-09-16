using AutoMapper;
using IntegraBrasilAPI.Dtos;
using IntegraBrasilAPI.Models;

namespace IntegraBrasilAPI.Mappings
{
    public class BancoMapping : Profile
    {
        public BancoMapping()
        {
            CreateMap(typeof(ResponseBase<>), typeof(ResponseBase<>));
            CreateMap<BancoResponse, BancoModel>();
            CreateMap<BancoModel, BancoResponse>();
        }
    }
}
