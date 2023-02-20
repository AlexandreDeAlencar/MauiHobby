using GA_Intergado.CR2.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.Domain.Persistence.Base
{
    public interface IRespositoryDefault<T> where T : class
    {
        void InsertOrUpdate(T entity);
    }
}
