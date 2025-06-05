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
        //Inicializo el produtco
        var product = new Product()
        {
            PlatformId = videogameCreateDTO.PlatformId,
            Sales = 0            
        };

        //Creo el producto
        var entityProduct = _productRepository.Add(product);
        
        //Inicializo el juego
        var videogame = new Videogame();

        //Mapeo el juego
        var mappedVideogame = videogame.mapFromCreateDto(videogameCreateDTO);

        //Le añado el id del producto al juegos
        mappedVideogame.ProductId = entityProduct.Id;

        //Creo el juego
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
        var prodcutDto = _productRepository.Get(videogameDto.ProductId);
        if (videogameDto == null)
        {
            throw new KeyNotFoundException($"Videogame con Id {id} no encontrada.");
        } 
        if (prodcutDto == null)
        {
            throw new KeyNotFoundException($"Producto con Id {id} no encontrada.");
        }

        prodcutDto.PlatformId = videogameUpdateDTO.PlatformId;
        // Actualizamos todos los campos del DTO
        videogameDto.Name = videogameUpdateDTO.Name;
        videogameDto.Pegi = videogameUpdateDTO.Pegi;
        videogameDto.Description = videogameUpdateDTO.Description;
        videogameDto.Requisitos1 = videogameUpdateDTO.Requisitos1;
        videogameDto.Requisitos2 = videogameUpdateDTO.Requisitos2;
        videogameDto.Stock = videogameUpdateDTO.Stock;
        videogameDto.Discount = videogameUpdateDTO.Discount;
        videogameDto.Price = videogameUpdateDTO.Price;
        videogameDto.ReleaseDate = videogameUpdateDTO.ReleaseDate;
        videogameDto.PrincipalImageURL = videogameUpdateDTO.PrincipalImageURL;
        videogameDto.Distributor = videogameUpdateDTO.Distributor;
        videogameDto.Developer = videogameUpdateDTO.Developer;
        videogameDto.PlatformId = videogameUpdateDTO.PlatformId;
        videogameDto.GenderId = videogameUpdateDTO.GenderId;

        _productRepository.Update(prodcutDto);
        _videogameRepository.Update(videogameDto.ToVideogame());
    }

    /// <summary>
    /// Borrar videojuego
    /// </summary>
    /// <param name="id"></param>
    public void Delete(int id)
    {
        _videogameRepository.Delete(id);
    }

    /// <summary>
    /// Obtener lista de todos los videojuegos
    /// </summary>
    /// <returns></returns>
    public List<VideogameDTO> GetFiltered(VideogameFilterDto filters)
    {
        var videogames = _videogameRepository.GetFiltered(filters);

        return videogames;
    }

    /// <summary>
    /// Obtenemos lista con los videojuegos más vendidos
    /// </summary>
    /// <returns></returns>
    public List<VideogameDTO> TopSellingVideogames()
    {
        var videogames = _videogameRepository.TopSellingVideogames();

        return videogames;
    }

}





