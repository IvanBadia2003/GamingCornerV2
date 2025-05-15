using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IPlatformRepository
{
    List<PlatformDTO> GetAll();
    // GetAll(int id);
    void Add(Platform platform);
    PlatformDTO Get(int id);
    List<Videogame> GetVideogamesByPlatform(int id);
    List<Models.Console> GetConsolesByPlatform(int id);
    void Update(Platform platform);
    void Delete(int id);
}