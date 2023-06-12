using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro_de_Series.Interfaces
{
    public interface iRepository<T>
    {
        List<T> Lista();

        T ReturnById(int id);

        void Insert(T entity);
        void delete(int id);
        void update(int id, T entity);
        int NextId();
    }
}