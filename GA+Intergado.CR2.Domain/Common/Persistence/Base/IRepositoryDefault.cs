using GA_Intergado.CR2.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.Domain.Common.Persistence.Base
{
    public interface IRepositoryDefault<T> where T : class
    {
        void InsertOrUpdate(T entity);
        List<T> GetAll();
        void Add(T entity);
    }
}
