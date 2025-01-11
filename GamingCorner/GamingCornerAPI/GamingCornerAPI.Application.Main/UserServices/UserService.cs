using AutoMapper;
using GamingCornerAPI.Application.DTO.UserDTOs;
using GamingCornerAPI.Domain.Entities;
using GamingCornerAPI.Domain.Main;
using GamingCornerAPI.Domain.Main.Services;
using GamingCornerAPI.Domain.Main.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCornerAPI.Application.Main.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public UserDTO getUserById(int id)
        {
            var specification = new UserByIDSpecification(id);
            Usuario usuario = _usuarioRepository.GetBySpec(specification).FirstOrDefault();
            return _mapper.Map<UserDTO>(usuario);
        }

        public UserDTO getUserByActive(bool active)
        {
            var specification = new UserByActiveSpecification(active);
            Usuario usuario = _usuarioRepository.GetBySpec(specification).FirstOrDefault();
            return _mapper.Map<UserDTO>(usuario);
        }

    }
}
