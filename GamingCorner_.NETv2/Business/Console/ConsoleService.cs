namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


public class ConsoleService : IConsoleService
{

    private readonly IConsoleRepository _consoleRepository;
    private readonly IProductEFRepository _productRepository;


    public ConsoleService(IConsoleRepository consoleRepository, IProductEFRepository productRepository)
    {
        _consoleRepository = consoleRepository;
        _productRepository = productRepository;

    }
    public List<ConsoleDTO> GetAll()
    {
        var consoles = _consoleRepository.GetAll();
        return consoles;
    }

    public ConsoleDTO Get(int id)
    {
        var console = _consoleRepository.Get(id);
        return console;
    }


    public ConsoleDTO Add(ConsoleCreateDTO consoleCreateDTO)
    {
        //Inicializamos el producto
        var product = new Product()
        {
            PlatformId = consoleCreateDTO.PlatformId,
            Sales = 0
        };

        //Creamos el producto       
        var entityProduct = _productRepository.Add(product);

        //Inicializamos la consola
        var console = new Console();

        //Mapeamos la consola
        var mappedConsole = console.mapFromCreateDto(consoleCreateDTO);

        //Asignamos al producto la consola
        mappedConsole.ProductId = entityProduct.Id;

        //Creamos la consola
        var consoleCreated = _consoleRepository.Add(mappedConsole);

        return consoleCreated.mapToReadDto();
    }

    public void Update(int id, ConsoleUpdateDTO dto)
    {
        var console = _consoleRepository.Get(id);
        if (console == null)
        {
            throw new KeyNotFoundException($"Console con Id {id} no encontrada.");
        }

        // Aquí actualizas las propiedades permitidas
        console.Name = dto.Name;
        console.Description = dto.Description;
        console.Stock = dto.Stock;
        console.Discount = dto.Discount;
        console.Price = dto.Price;
        console.PrincipalImageURL = dto.PrincipalImageURL;
        console.ReleaseDate = dto.ReleaseDate;
        console.Specifications = dto.Specifications;
        console.Brand = dto.Brand;
        console.PlatformId = dto.PlatformId;
        console.Generation = dto.Generation;
        console.Colors = dto.Colors;
        console.Services = dto.Services;



        _consoleRepository.Update(console.ToConsole());
    }

    public void Delete(int id)
    {
        _consoleRepository.Delete(id);
    }
}





