using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IFavouriteRepository
{
    List<FavouriteDTO> GetAll();
    // GetAll(int id);
    void Add(Favourite favourite);
    List<FavouriteDTO> Get(int idUser);
    // void Update(Gender gender);
    void Delete(int idUser, int idProduct);

    // List<VideogameGender> GetGendersByVideogameId(int idVideogame);

}