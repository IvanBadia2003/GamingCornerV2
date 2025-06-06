namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface IGenderService
{
    List<GenderDTO> GetAll();
    // GetAll(int id);
    void Add(GenderCreateDTO genderCreateDTO);
    GenderDTO Get(int id);
    List<VideogameDTO> GetVideogamesByGender(int id);
    void Delete(int id);
}
