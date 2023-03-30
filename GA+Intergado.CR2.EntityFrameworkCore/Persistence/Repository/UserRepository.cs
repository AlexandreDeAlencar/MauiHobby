using GA_Intergado.CR2.Domain.Users;
using GA_Intergado.CR2.EntityFrameworkCore.Persistence.Repository.Base;

namespace GA_Intergado.CR2.EntityFrameworkCore.Persistence.Repository
{
    public class UserRepository : RespositoryDefault<User>, IUserRepository
    {
        public UserRepository(MyDbContext context) : base(context)
        {
        }
    }
}
