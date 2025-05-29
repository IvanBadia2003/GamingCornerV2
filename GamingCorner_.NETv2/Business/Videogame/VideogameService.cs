namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class VideogameService : IVideogameService
{

    private readonly IVideogameRepository _videogameRepository;
    private readonly IProductEFRepository _productRepository;


    public VideogameService(IVideogameRepository videogameRepository, IProductEFRepository productRepository)
    {
        _videogameRepository = videogameRepository;
        _productRepository = productRepository;

    }

    /// <summary>
    /// Obtener lista de todos los videojuegos
    /// </summary>
    /// <returns></returns>
    public List<VideogameDTO> GetAll()
    {
        var videogames = _videogameRepository.GetAll();

        return videogames;
    }

    /// <summary>
    /// Obtener videojuego por su ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public VideogameDTO Get(int id)
    {
        var videogame = _videogameRepository.Get(id);
        if (videogame == null)
        {
            throw new KeyNotFoundException($"Videogame con Id {id} no encontrada.");
        }
        return videogame;
    }

    /// <summary>
    /// Añadir videojuego
    /// </summary>
    /// <param name="videogameCreateDTO"></param>
    public VideogameDTO Add(VideogameCreateDTO videogameCreateDTO)
    {
        var product = new Product()
        {
            PlatformId = videogameCreateDTO.PlatformId,
            Sales = 0            
        };

        var entityProduct = _productRepository.Add(product);

        var videogame = new Videogame()
        {
            ProductId = entityProduct.Id
        };

        var mappedVideogame = videogame.mapFromCreateDto(videogameCreateDTO);
        var videogameCreated = _videogameRepository.Add(mappedVideogame);
        return videogameCreated.mapToReadDto();
    }

    /// <summary>
    /// Actualizar videojuego
    /// </summary>
    /// <param name="id"></param>
    /// <param name="videogameUpdateDTO"></param>
    /// <exception cref="KeyNotFoundException"></exception>
    public void Update(int id, VideogameUpdateDTO videogameUpdateDTO)
    {
        var videogameDto = _videogameRepository.Get(id);
        if (videogameDto == null)
        {
            throw new KeyNotFoundException($"Videogame con Id {id} no encontrada.");
        }

        var videogame = videogameDto.ToVideogame();
        videogame.Stock = videogameUpdateDTO.Stock;
        //videogame.Available = videogameUpdateDTO.Available;
        videogame.Price = videogameUpdateDTO.Price;
        _videogameRepository.Update(videogame);
    }

    /// <summary>
    /// Borrar videojuego
    /// </summary>
    /// <param name="id"></param>
    public void Delete(int id)
    {
        _videogameRepository.Delete(id);
    }
}





