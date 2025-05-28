namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class PlatformService : IPlatformService
{

    private readonly IPlatformRepository _platformRepository;


    public PlatformService(IPlatformRepository platformRepository)
    {
        _platformRepository = platformRepository;

    }
    public List<PlatformDTO> GetAll()
    {
        var platforms = _platformRepository.GetAll();
        return platforms;
    }

    public PlatformDTO Get(int id)
    {
        var platform = _platformRepository.Get(id);
        return platform;
    }
    
    // public List<VideogameDTO> GetVideogamesByPlatform(int id)
    // {
    //     var videogames = _platformRepository.GetVideogamesByPlatform(id);

    //     if (videogames == null || !videogames.Any())
    //     {
    //         return null;
    //     }

    //     return videogames.Select(v => new VideogameDTO
    //     {
    //         //VideogameId = v.Id,
    //         Name = v.Name,
    //         //PlatformId = v.PlatformId,
    //         Price = v.Price,
    //         Stock = v.Stock,
    //         Description = v.Description,
    //         Requisitos1 = v.Requisitos1,
    //         Requisitos2 = v.Requisitos2,
    //         //ImageURL = v.ImageURL
    //     }).ToList();
    // }
    // public List<ConsoleDTO> GetConsolesByPlatform(int id)
    // {
    //     var consoles = _platformRepository.GetConsolesByPlatform(id);

    //     if (consoles == null || !consoles.Any())
    //     {
    //         return null;
    //     }

    //     return consoles.Select(v => new ConsoleDTO
    //     {
    //         Id = v.Id,
    //         Name = v.Name,
    //         Specifications = v.Specifications,
    //         Price = v.Price,
    //         Stock = v.Stock,
    //         //ImageURL = v.ImageURL
    //     }).ToList();
    // }


    public void Add(PlatformCreateDTO platformCreateDTO)
    {
        var platform = new Platform();
        var mappedPlatform = platform.mapFromCreateDto(platformCreateDTO);
        _platformRepository.Add(mappedPlatform);
    }


    public void Delete(int id)
    {
        _platformRepository.Delete(id);
    }
}


    
    

