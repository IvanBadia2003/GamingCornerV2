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
        var products = _context.SecondHandProducts.Include(p => p.Product).Include(p => p.User).ToList();
        //.Where(p => p.Available == true)

        if (products != null)
        {

            return products.Select(r => r.ToSecondHandProductDTO()).ToList();
        }
        else
        {
            return null;
        }
    }
    
    public List<SecondHandProductDTO> GetAllChecked()
    {
        var products = _context.SecondHandProducts.Where(p => p.IsChecked == true).Include(p => p.Product).Include(p => p.User).ToList();
        //.Where(p => p.Available == true)

        if (products != null)
        {

            return products.Select(r => r.ToSecondHandProductDTO()).ToList();
        }
        else
        {
            return null;
        }
    }

    public void Add(SecondHandProduct product)
    {

        _context.SecondHandProducts.Add(product);
        SaveChanges();
    }

    public SecondHandProductDTO Get(int id)
    {
        var product = _context.SecondHandProducts
            .Where(product => product.Id == id)
            .Include(p => p.Product)
            .Include(p => p.User)
            //.Where(p => p.Available == true)
            .FirstOrDefault();

        if (product != null)
        {

            return product.ToSecondHandProductDTO();
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

    public void CangeStatus(int id)
    {
        var product = _context.SecondHandProducts
                    .Where(product => product.Id == id)
                    .Include(p => p.Product)
                    .Include(p => p.User)
                    //.Where(p => p.Available == true)
                    .FirstOrDefault();

        if (product == null)
        {
            throw new KeyNotFoundException("Product not found.");
        }

        product.IsChecked = !product.IsChecked;
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }


}
