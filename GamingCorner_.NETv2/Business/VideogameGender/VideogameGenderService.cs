namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class VideogameGenderService : IVideogameGenderService
{

    private readonly IVideogameGenderRepository _videogameGenderRepository;


    public VideogameGenderService(IVideogameGenderRepository videogameGenderRepository)
    {
        _videogameGenderRepository = videogameGenderRepository;

    }
    public List<VideogameGenderDTO> GetAll()
    {
        var videogameGenders = _videogameGenderRepository.GetAll();
        return videogameGenders;
    }

    public VideogameGenderDTO Get(int idGender, int idVideogame)
    {
        var videogameGender = _videogameGenderRepository.Get(idGender, idVideogame);
        return videogameGender;
    }


    public void Add(VideogameGenderCreateDTO videogameGenderCreateDTO)
    {
        var videogameGender = new VideogameGender();
        var mappedVideogameGender = videogameGender.mapFromCreateDto(videogameGenderCreateDTO);
        _videogameGenderRepository.Add(mappedVideogameGender);
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

    public void Delete(int idGender, int idVideogame)
    {
        _videogameGenderRepository.Delete(idGender, idVideogame);
    }
}


    
    