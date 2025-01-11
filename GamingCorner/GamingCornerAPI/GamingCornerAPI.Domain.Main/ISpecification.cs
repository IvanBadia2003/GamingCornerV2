using System.Linq.Expressions;

namespace GamingCornerAPI.Domain.Main
{
    public interface ISpecification<TEntity> where TEntity : class, new()
    {
        //
        // Resumen:
        //     Obtiene la condición a cumplir por el patrón.
        //
        // Devuelve:
        //     Condición.
        Expression<Func<TEntity, bool>> SatisfiedBy();
    }
}