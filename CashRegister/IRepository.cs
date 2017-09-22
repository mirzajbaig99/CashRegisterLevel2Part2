using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public interface IRepository<T>
    {
        bool Add(T item);

        bool Add(IEnumerable<T> items);

        IEnumerable<T> Get();

        T Get(int id);

        T Get(string name);

        int GetNextId();

        bool Update(T item);

        bool Remove(T item);
    }
}
