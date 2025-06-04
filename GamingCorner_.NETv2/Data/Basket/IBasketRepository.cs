using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IBasketRepository
{
    List<BasketDTO> GetAll();
    // GetAll(int id);
    void Add(Basket basket);
    List<BasketDTO> Get(int idUser);
    // void Update(Gender gender);
    void Delete(int idUser, int idProduct);
    
    void DeleteByUser(int idUser);

    // List<VideogameGender> GetGendersByVideogameId(int idVideogame);

}