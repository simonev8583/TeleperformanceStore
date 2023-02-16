using System;
namespace VirtualStore.Domain.Interfaces
{
    public interface IPersonRepository<TEntity>
    {
        TEntity Create(TEntity entity);

        TEntity? GetByUsername(string username, string? password);
    }
}

