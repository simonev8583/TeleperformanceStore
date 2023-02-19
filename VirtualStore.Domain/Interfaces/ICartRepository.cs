using System;
namespace VirtualStore.Domain.Interfaces
{
    public interface ICartRepository<TEntity>
    {
        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity? GetById(string cartId, string personId);

        TEntity? GetByPerson(string personId);
    }
}

