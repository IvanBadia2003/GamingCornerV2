namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface ISecondHandProductService
{
    List<SecondHandProductDTO> GetAll();
    // GetAll(int id);
    //void Add(int productId, SecondHandProductCreateDTO productCreateDTO);
    void Add(SecondHandProductCreateDTO productCreateDTO);
    SecondHandProductDTO Get(int id);
    void Update(int id, SecondHandProductUpdateDTO productUpdateDTO);
    void Delete(int id);
}
