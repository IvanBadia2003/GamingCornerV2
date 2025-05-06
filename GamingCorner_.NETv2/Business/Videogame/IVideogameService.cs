namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface IVideogameService
{
    List<VideogameDTO> GetAll();
    // GetAll(int id);
    void Add(VideogameCreateDTO videogameCreateDTO);
    VideogameDTO Get(int id);
    void Update(int id, VideogameUpdateDTO videogameUpdateDTO);
    void Delete(int id);
}
