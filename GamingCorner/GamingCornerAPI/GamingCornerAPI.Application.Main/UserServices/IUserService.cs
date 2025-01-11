using GamingCornerAPI.Application.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCornerAPI.Application.Main.UserServices
{
    public interface IUserService
    {
        UserDTO getUserById(int id);
        UserDTO getUserByActive(bool active);
    }
}
