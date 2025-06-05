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
    /// <summary>
    /// cambia isChecked de false a true o viceversa
    /// </summary>
    /// <param name="id"></param>
    void CangeStatus(int id);

    /// <summary>
    /// Obtener todos los productos que están chequeados
    /// </summary>
    /// <returns></returns>
    List<SecondHandProductDTO> GetAllChecked();
}