using System;
namespace VirtualStore.Application.Interfaces
{
    public interface ICartService<TEntity>
    {
        TEntity Update(TEntity entity, string personId);

        TEntity Get(string personId);
    }
}

