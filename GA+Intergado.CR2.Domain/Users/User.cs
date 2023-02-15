using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Shared.Users;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.Domain.Users
{
    public sealed class User : AggregateRoot<UserId>
    {
        private User(UserId id
           , UserId modifierUserId
           , string userName
           , string password
           , UserType userType
           )
           : base(id, modifierUserId)
        {
            this.UserName = userName;
            this.Password = password;
            this.UserType = userType;
        }
        public string UserName { get; }
        public string Password { get; }
        public UserType UserType { get; }
        public static User Create(
            UserId modifierUserId
            , string userName
            , string password
            , UserType userType
            , UserId? userId = null
            )
        {
            return new(
                userId ?? UserId.CreateUnique()
                , modifierUserId
                , userName
                , password
                , userType
                );
        }
    }
}