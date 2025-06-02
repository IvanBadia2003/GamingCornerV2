namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class FavouriteService : IFavouriteService
{

    private readonly IFavouriteRepository _favouriteRepository;


    public FavouriteService(IFavouriteRepository favouriteRepository)
    {
        _favouriteRepository = favouriteRepository;

    }
    public List<FavouriteDTO> GetAll()
    {
        var favourites = _favouriteRepository.GetAll();
        return favourites;
    }

    public List<FavouriteDTO> Get(int idUser, int? idProduct = null)
    {
        var favourite = _favouriteRepository.Get(idUser);
        return favourite;
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


    public void Add(FavouriteCreateDTO favouriteCreateDTO)
    {
        var favourite = new Favourite();
        var mappedFavourite = favourite.mapFromCreateDto(favouriteCreateDTO);
        _favouriteRepository.Add(mappedFavourite);
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
        _favouriteRepository.Delete(idUser, idProduct);
    }
}


    
    