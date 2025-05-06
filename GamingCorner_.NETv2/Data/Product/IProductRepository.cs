using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IProductRepository
{
    List<ProductDTO> GetAll();
    // GetAll(int id);
    void Add(Product product);
    ProductDTO Get(int id);
    void Update(Product product);
    void Delete(int id);

}