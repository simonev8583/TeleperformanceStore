using System;
namespace VirtualStore.Domain.Interfaces
{
    public interface IProductRepository<TEntity>
    {
        List<TEntity> GetProductsToBuy(string personId);

        List<TEntity> GetProductsOwn(string personId);

        TEntity GetById(string productId);

        TEntity Update(TEntity product);

        void Delete(string productId, string ownerId);

        TEntity Create(TEntity product);

        TEntity UploadImagen(TEntity entity);
    }
}

