using AutoMapper;
using GamingCornerAPI.Application.DTO;
using GamingCornerAPI.Application.DTO.UserDTOs;
using GamingCornerAPI.Domain.Entities;
using System.Data;

namespace GamingCornerAPI.CrossCutting.Mappings
{
    public class AutomapperConfiguration : Profile
    {

        public AutomapperConfiguration()
        {
            #region Usuarios
            CreateMap<Usuario, UserDTO>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom<string>(src => src.Nombre))
                .ForMember(dst => dst.Email, opt => opt.MapFrom<string>(src => src.Correo))
                .ForMember(dst => dst.Active, opt => opt.MapFrom<bool>(src => src.Activo))
                .ForMember(dst => dst.Id, opt => opt.MapFrom<int>(src => src.Id))
                .ForMember(dst => dst.Password, opt => opt.MapFrom<string>(src => src.Contraseña));
            #endregion

        }

    }
}
