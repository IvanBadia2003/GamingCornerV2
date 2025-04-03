namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class GenderService : IGenderService
{

    private readonly IGenderRepository _genderRepository;


    public GenderService(IGenderRepository genderRepository)
    {
        _genderRepository = genderRepository;

    }
    public List<GenderDTO> GetAll()
    {
        var genders = _genderRepository.GetAll();
        return genders;
    }

    public GenderDTO Get(int id)
    {
        var gender = _genderRepository.Get(id);
        return gender;
    }

    public List<VideogameDTO> GetVideogamesByGender(int id)
    {
        var videogames = _genderRepository.GetVideogamesByGender(id);

        if (videogames == null || !videogames.Any())
        {
            return null;
        }

        return videogames.Select(v => new VideogameDTO
        {
            VideogameId = v.VideogameId,
            Name = v.Name,
            PlatformId = v.PlatformId,
            Price = v.Price,
            Stock = v.Stock,
            Description = v.Description,
            Requisitos1 = v.Requisitos1,
            Requisitos2 = v.Requisitos2,
            ImageURL = v.ImageURL
        }).ToList();
    }

    public void Add(GenderCreateDTO genderCreateDTO)
    {
        var gender = new Gender();
        var mappedGender = gender.mapFromCreateDto(genderCreateDTO);
        _genderRepository.Add(mappedGender);
    }


    public void Delete(int id)
    {
        _genderRepository.Delete(id);
    }
}


    
    

