namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface IPlatformService
{
    List<PlatformDTO> GetAll();
    // GetAll(int id);
    void Add(PlatformCreateDTO platformCreateDTO);
    PlatformDTO Get(int id);
    // List<VideogameDTO> GetVideogamesByPlatform(int id);
    // List<ConsoleDTO> GetConsolesByPlatform(int id);
    void Delete(int id);
}
