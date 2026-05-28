using AutoMapper;
using CentroComputo.DTOS;
using CentroComputoDTOS;
using EIN.Entidades;

namespace CentroComputo.data.AutoMapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile() 
        {
            CreateMap<GeneracionSetDTO, GeneracionEntity>()
                    .ForMember(campo => campo.EstaActivo, asignar => asignar.MapFrom(valor => true));

            CreateMap<GeneracionEntity, GeneracionGetDTO>();

            CreateMap<GrupoSetDTO, GrupoEntity>()
                .ForMember(campo => campo.EstarActivo, asignar => asignar.MapFrom(valor => true));

            CreateMap<GrupoEntity, GrupoGetDTO>()
                .ForMember(campo => campo.NombreGeneracion,asignar=>asignar.MapFrom(valor=> valor.Generacion.Nombre));
        }
    }
}
