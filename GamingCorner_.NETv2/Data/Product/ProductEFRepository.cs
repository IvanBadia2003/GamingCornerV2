namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class ProductEFRepository : IProductRepository
{


    private readonly GamingCornerContext _context;

    public ProductEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<ProductDTO> GetAll()
    {
        var products = _context.Products
            .Where(p => p.Available == true)
            .ToList();

        if (products != null)
        {
            var productDto = products.Select(p => new ProductDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Available = p.Available,
                Price = p.Price,
                ImageURL = p.ImageURL,
            }).ToList();
            return productDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
        SaveChanges();
    }

    public ProductDTO Get(int id)
    {
        var product = _context.Products
            .Where(product => product.ProductId == id)
            .Where(p => p.Available == true)
            .FirstOrDefault();

        if (product != null)
        {
            var productDTO = new ProductDTO
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Available =product.Available,
                Price = product.Price,
                ImageURL = product.ImageURL,
            };
            return productDTO;
        }
        else
        {
            return null;
        }
    }

    public void Update(Product product)
    {
        var existingProduct = _context.Products.Find(product.ProductId);

        if (existingProduct != null)
        {
            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var productDto = Get(id);
        if (productDto == null)
        {
            throw new KeyNotFoundException("Product not found.");
        }
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
        if (product != null)
        {
            _context.Products.Remove(product);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
