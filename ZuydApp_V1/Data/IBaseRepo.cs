using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydApp_V1.Data
{
    internal interface IBaseRepo<T> : IDisposable where T : Tabledata, new()
    {
        void SaveEntity(T entity);
        T? GetSpecificEntity(int id);
        List<T>? GetEntities();
        void DeleteEntity(T entity);
        bool Checkifempty();

        void SaveEntityWithChildren(T entity, bool recursive = false);
        void DeleteEntityWithChildren(T entity);
        List<T>? GetEntitiesWithChildren();
    }
}
