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
        var product = new Product()
        {
            PlatformId = consoleCreateDTO.PlatformId,
            Sales = 0
        };

        var entityProduct = _productRepository.Add(product);

        var console = new Console()
        {
            ProductId = entityProduct.Id
        };
        var mappedConsole = console.mapFromCreateDto(consoleCreateDTO);
        var consoleCreated = _consoleRepository.Add(mappedConsole);

        return consoleCreated.mapToReadDto();
    }

    public void Update(int id, ConsoleUpdateDTO consoleUpdateDTO)
    {
        var consoleDto = _consoleRepository.Get(id);
        if (consoleDto == null)
        {
            throw new KeyNotFoundException($"Console con Id {id} no encontrada.");
        }

        var console = consoleDto.ToConsole();
        console.Price = consoleUpdateDTO.Price;
        console.Stock = consoleUpdateDTO.Stock;
        //console.Available = consoleUpdateDTO.Available;
        _consoleRepository.Update(console);
    }

    public void Delete(int id)
    {
        _consoleRepository.Delete(id);
    }
}





