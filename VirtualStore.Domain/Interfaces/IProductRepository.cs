using System;
namespace VirtualStore.Domain.Interfaces
{
    public interface IProductRepository<TEntity>
    {
        List<TEntity> GetProductsToBuy(string personId);

        List<TEntity> GetProductsOwn(string personId);

        TEntity GetById(string productId);

        TEntity Update(TEntity product);

        string Delete(TEntity product);

        TEntity Create(TEntity product);
    }
}

