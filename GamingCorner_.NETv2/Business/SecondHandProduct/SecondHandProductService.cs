namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class SecondHandProductService : ISecondHandProductService
{

    private readonly ISecondHandProductRepository _secondHandProductRepository;
    private readonly IProductEFRepository _productRepository;



    public SecondHandProductService(ISecondHandProductRepository secondHandProductRepository, IProductEFRepository productRepository)
    {
        _secondHandProductRepository = secondHandProductRepository;
        _productRepository = productRepository;

    }
    public List<SecondHandProductDTO> GetAll()
    {
        var products = _secondHandProductRepository.GetAll();
        return products;
    }

    public SecondHandProductDTO Get(int id)
    {
        var product = _secondHandProductRepository.Get(id);
        if (product == null)
        {
            throw new KeyNotFoundException($"Product con Id {id} no encontrada.");
        }
        return product;
    }


    //public void Add(int productId, SecondHandProductCreateDTO productCreateDTO)
    public void Add(SecondHandProductCreateDTO productCreateDTO)
    {
        //Inicializo el produtco
        var product = new Product()
        {
            Sales = 0
        };

        //Creo el producto
        var entityProduct = _productRepository.Add(product);

        //Inicializo el producto de segunda mano
        var secondHandProduct = new SecondHandProduct();

        //Mapeo el producto de segunda mano
        var mappedsecondHandProduct = secondHandProduct.mapFromCreateDto(productCreateDTO);

        //Le añado el id del producto al producto de segunda mano
        mappedsecondHandProduct.ProductId = entityProduct.Id;
        mappedsecondHandProduct.IsChecked= false;

        //Creo el producto de segunda mano
        _secondHandProductRepository.Add(mappedsecondHandProduct);
    }

    public void Update(int id, SecondHandProductUpdateDTO productUpdateDTO)
    {
        var productDto = _secondHandProductRepository.Get(id);
        if(productDto == null)
        {
            throw new KeyNotFoundException($"Product con Id {id} no encontrada.");
        }

        var product = productDto.ToProduct();
        //product.Available = productUpdateDTO.Available;
        _secondHandProductRepository.Update(product);
    }

    public void Delete(int id)
    {
        _secondHandProductRepository.Delete(id);
    }

    public void CangeStatus(int id)
    {
        _secondHandProductRepository.CangeStatus(id);
    }

    public List<SecondHandProductDTO> GetAllChecked()
    {
        return _secondHandProductRepository.GetAllChecked();
    }
}


    
    

