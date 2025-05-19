namespace GamingCorner.Data;
using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class SecondHandProductEFRepository : ISecondHandProductRepository
{


    private readonly GamingCornerContext _context;

    public SecondHandProductEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<SecondHandProductDTO> GetAll()
    {
        var products = _context.SecondHandProducts.Include(p => p.Product).ToList();
            //.Where(p => p.Available == true)

        if (products != null)
        {
            var productDto = products.Select(p => new SecondHandProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                //Available = p.Available,
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

    public void Add(SecondHandProduct product)
    {
        //Primero se crea el producto
        var producto = new Product();
        _context.Products.Add(producto);
        SaveChanges();

        //Segundo se crea el producto de segunda mano con el id del producto
        product.ProductId = producto.Id;
        _context.SecondHandProducts.Add(product);
        SaveChanges();
    }

    public SecondHandProductDTO Get(int id)
    {
        var product = _context.SecondHandProducts
            .Where(product => product.Id == id)
            .Include(p => p.Product)
            //.Where(p => p.Available == true)
            .FirstOrDefault();

        if (product != null)
        {
            var productDTO = new SecondHandProductDTO
            {
                ProductId = product.Id,
                Name = product.Name,
                Description = product.Description,
                //Available =product.Available,
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

    public void Update(SecondHandProduct product)
    {
        var existingProduct = _context.SecondHandProducts.Find(product.Id);

        if (existingProduct != null)
        {
            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            _context.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException("Product not found.");
        }
    }

    public void Delete(int id)
    {
        var productDto = Get(id);
        if (productDto == null)
        {
            throw new KeyNotFoundException("Product not found.");
        }
        var product = _context.SecondHandProducts.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _context.SecondHandProducts.Remove(product);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
