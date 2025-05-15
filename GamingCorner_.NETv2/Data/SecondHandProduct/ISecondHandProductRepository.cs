using GamingCorner.Models;

namespace GamingCorner.Data;

public interface ISecondHandProductRepository
{
    List<SecondHandProductDTO> GetAll();
    // GetAll(int id);
    void Add(SecondHandProduct product);
    SecondHandProductDTO Get(int id);
    void Update(SecondHandProduct product);
    void Delete(int id);

}