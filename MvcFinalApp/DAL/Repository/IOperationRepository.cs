using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcFinalApp.DAL.Repository
{
    interface IOperationRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T proj);
        void Update(T proj);
        void Delete(int id);
    }
}
