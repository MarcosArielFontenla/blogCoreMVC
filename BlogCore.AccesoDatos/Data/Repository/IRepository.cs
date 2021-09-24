using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogCore.AccesoDatos.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        // metodo para obtener los registros.
        T Get(int id);
        
        // metodo generico para obtener los registros completos o por filtrado.
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null);

        //metodo para obtener el primero o por defecto que encuentre.
        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null);

        // agregar
        void Add(T entity);

        // eliminar por id
        void Remove(int id);

        // eliminar por entidad
        void Remove(T entity);

        // --- el metodo Update no lo hacemos porque va a cambiar mucho en funcion de cada entidad. ---
    }
}
