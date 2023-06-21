using Autolote.Models;
using Autolote.Models.DTO;
using AutoloteAPI.Models;
using AutoloteAPI.Models.DTO;
using AutoMapper;

namespace Autolote
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Cliente, ClienteCreateDTO>().ReverseMap();
            CreateMap<Cliente, ClienteUpdateDTO>().ReverseMap();

            CreateMap<RegistroVenta, RegistroVentaDTO>().ReverseMap();
            CreateMap<RegistroVenta, RegistroVentaCreateDTO>().ReverseMap();
            CreateMap<RegistroVenta, RegistroVentaUpdateDTO>().ReverseMap();

            CreateMap<Vehiculo, VehiculoDTO>().ReverseMap();
            CreateMap<Vehiculo,VehiculoCreateDTO>().ReverseMap();
            CreateMap<Vehiculo,VehiculoUpdateDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();    
        }
    }
}
