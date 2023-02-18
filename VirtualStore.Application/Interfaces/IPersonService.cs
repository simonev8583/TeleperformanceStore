using System;
namespace VirtualStore.Application.Interfaces
{
    public interface IPersonService<TEntity>
    {
        TEntity Create(TEntity dto);

        TEntity GetById(string id);
    }
}

