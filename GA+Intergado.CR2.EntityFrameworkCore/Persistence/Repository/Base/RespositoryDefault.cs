using GA_Intergado.CR2.Domain.Persistence.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.EntityFrameworkCore.Persistence.Repository.Base
{
    public class RespositoryDefault<T> : IRespositoryDefault<T> where T : class
    {
        public void InsertOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
