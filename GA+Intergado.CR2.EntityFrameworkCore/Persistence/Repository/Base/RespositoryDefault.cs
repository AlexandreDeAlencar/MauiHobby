using GA_Intergado.CR2.Domain.Common.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace GA_Intergado.CR2.EntityFrameworkCore.Persistence.Repository.Base
{
    public class RespositoryDefault<T> : IRepositoryDefault<T> where T : class
    {
        private MyDbContext _context;

        public RespositoryDefault(MyDbContext context)
        {
            _context = context;
        }

        public void InsertOrUpdate(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this._context.Add(entity);
            this._context.SaveChanges();
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this._context.Add(entity);
            this._context.SaveChanges();
        }
        
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList<T>();
        }
    }
}
