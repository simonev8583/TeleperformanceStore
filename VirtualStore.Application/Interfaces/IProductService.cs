using System;
namespace VirtualStore.Application.Interfaces
{
    public interface IProductService<TEntity>
    {
        TEntity Create(TEntity dto, string personId);

        List<TEntity> GetProductsToBuy(string personId);

        List<TEntity> GetProductsOwn(string personId);

        TEntity GetById(string productId);

        TEntity Update(TEntity dto);

        string Delete(TEntity dto);
    }
}

