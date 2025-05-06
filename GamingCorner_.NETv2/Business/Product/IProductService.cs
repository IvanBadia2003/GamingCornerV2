namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface IProductService
{
    List<ProductDTO> GetAll();
    // GetAll(int id);
    void Add(ProductCreateDTO productCreateDTO);
    ProductDTO Get(int id);
    void Update(int id, ProductUpdateDTO productUpdateDTO);
    void Delete(int id);
}
