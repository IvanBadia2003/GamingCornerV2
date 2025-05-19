namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


    public class ConsoleService : IConsoleService
{

    private readonly IConsoleRepository _consoleRepository;


    public ConsoleService(IConsoleRepository consoleRepository)
    {
        _consoleRepository = consoleRepository;

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


    public void Add(int productId, ConsoleCreateDTO consoleCreateDTO)
    {
        var console = new Console();
        var mappedConsole = console.mapFromCreateDto(productId, consoleCreateDTO);
        _consoleRepository.Add(mappedConsole);
    }

    public void Update(int id, ConsoleUpdateDTO consoleUpdateDTO)
    {
        var consoleDto = _consoleRepository.Get(id);
        if(consoleDto == null)
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


    
    

