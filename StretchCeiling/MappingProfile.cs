using AutoMapper;
using Dom = StretchCeiling.Domain.Model;
using StretchCeiling.Model;
using StretchCeiling.Service.Arithmetic;

namespace StretchCeiling
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dom.OrdersList, OrdersList>().ReverseMap();
            CreateMap<Dom.Order, Order>().ReverseMap();
            CreateMap<Dom.Ceiling, Ceiling>().ReverseMap();
            CreateMap<Dom.Scheme, Scheme>().ReverseMap();
            CreateMap<Dom.Equipment, Equipment>().ReverseMap();
            CreateMap<Dom.Side, Side>().ReverseMap();
            CreateMap<Dom.Vertex, Vertex>().ReverseMap();
            CreateMap<Dom.Angle, Angle>().ReverseMap();
        }
    }
}