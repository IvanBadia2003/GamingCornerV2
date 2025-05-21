using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IVideogameGenderRepository
{
    List<VideogameGenderDTO> GetAll();
    // GetAll(int id);
    void Add(VideogameGender videogameGender);
    VideogameGenderDTO Get(int idGender, int idVideogame);
    // void Update(Gender gender);
    void Delete(int idGender, int idVideogame);
}