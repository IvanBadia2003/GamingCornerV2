namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class BasketService : IBasketService
{

    private readonly IBasketRepository _basketRepository;


    public BasketService(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;

    }
    public List<BasketDTO> GetAll()
    {
        var baskets = _basketRepository.GetAll();
        return baskets;
    }

    public List<BasketDTO> Get(int idUser, int? idProduct = null)
    {
        var basket = _basketRepository.Get(idUser);
        return basket;
    }

    // public List<VideogameGenderDTO> GetGendersByVideogameId(int idVideogame)
    // {
    //     List<VideogameGenderDTO> videogameGenderDTOs = new List<VideogameGenderDTO>();
    //     List<VideogameGender> videogameGenderList = _basketRepository.GetGendersByVideogameId(idVideogame);

    //     foreach (VideogameGender vg in videogameGenderList)
    //     {
    //         videogameGenderDTOs.Add(vg.MapToVideogameGenderDTO());
    //     }

    //     return videogameGenderDTOs;
    // }


    public void Add(BasketCreateDTO basketCreateDTO)
    {
        var basket = new Basket();
        var mappedBasket = basket.mapFromCreateDto(basketCreateDTO);
        _basketRepository.Add(mappedBasket);
    }

    // public void Update(int id, VideogameUpdateDTO videogameUpdateDTO)
    // {
    //     var videogameDto = _genderRepository.Get(id);
    //     if(videogameDto == null)
    //     {
    //         throw new KeyNotFoundException($"Videogame con Id {id} no encontrada.");
    //     }

    //     var videogame = videogameDto.ToVideogame();
    //     videogame.Stock = videogameDto.Stock;
    //     videogame.Available = videogameDto.Available;
    //     videogame.Price = videogameDto.Price;
    //     _genderRepository.Update(videogame);
    // }

    public void Delete(int idUser, int idProduct)
    {
        _basketRepository.Delete(idUser, idProduct);
    }
}


    
    