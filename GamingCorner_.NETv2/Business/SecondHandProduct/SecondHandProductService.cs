namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class SecondHandProductService : ISecondHandProductService
{

    private readonly ISecondHandProductRepository _productRepository;


    public SecondHandProductService(ISecondHandProductRepository productRepository)
    {
        _productRepository = productRepository;

    }
    public List<SecondHandProductDTO> GetAll()
    {
        var products = _productRepository.GetAll();
        return products;
    }

    public SecondHandProductDTO Get(int id)
    {
        var product = _productRepository.Get(id);
        if (product == null)
        {
            throw new KeyNotFoundException($"Product con Id {id} no encontrada.");
        }
        return product;
    }


    //public void Add(int productId, SecondHandProductCreateDTO productCreateDTO)
    public void Add(SecondHandProductCreateDTO productCreateDTO)
    {
        var product = new SecondHandProduct();
        var mappedProduct = product.mapFromCreateDto(productCreateDTO);
        _productRepository.Add(mappedProduct);
    }

    public void Update(int id, SecondHandProductUpdateDTO productUpdateDTO)
    {
        var productDto = _productRepository.Get(id);
        if(productDto == null)
        {
            throw new KeyNotFoundException($"Product con Id {id} no encontrada.");
        }

        var product = productDto.ToProduct();
        //product.Available = productUpdateDTO.Available;
        _productRepository.Update(product);
    }

    public void Delete(int id)
    {
        _productRepository.Delete(id);
    }
}


    
    

