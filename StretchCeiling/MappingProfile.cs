using AutoMapper;
using StretchCeiling.Domain.Model;
using StretchCeiling.Model;

namespace StretchCeiling
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IOrder, Order>();
            CreateMap<ICeiling, Ceiling>().ReverseMap();
        }
    }
}