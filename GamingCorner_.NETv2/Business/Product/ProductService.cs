namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class ProductService : IProductService
{

    private readonly IProductRepository _productRepository;


    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;

    }
    public List<ProductDTO> GetAll()
    {
        var products = _productRepository.GetAll();
        return products;
    }

    public ProductDTO Get(int id)
    {
        var product = _productRepository.Get(id);
        return product;
    }


    public void Add(ProductCreateDTO productCreateDTO)
    {
        var product = new Product();
        var mappedProduct = product.mapFromCreateDto(productCreateDTO);
        _productRepository.Add(mappedProduct);
    }

    public void Update(int id, ProductUpdateDTO productUpdateDTO)
    {
        var productDto = _productRepository.Get(id);
        if(productDto == null)
        {
            throw new KeyNotFoundException($"Product con Id {id} no encontrada.");
        }

        var product = productDto.ToProduct();
        product.Available = productUpdateDTO.Available;
        _productRepository.Update(product);
    }

    public void Delete(int id)
    {
        _productRepository.Delete(id);
    }
}


    
    

