using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IGenderRepository
{
    List<GenderDTO> GetAll();
    // GetAll(int id);
    void Add(Gender gender);
    GenderDTO Get(int id);
    List<Videogame> GetVideogamesByGender(int id);
    void Update(Gender gender);
    void Delete(int id);
}