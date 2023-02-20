using GA_Intergado.CR2.Domain.Users.ValueObjects;
using System.Xml.Linq;

namespace GA_Intergado.CR2.Domain.Common.Models
{
    public abstract class AggregateRoot<TId> : Entity<TId>
        where TId : notnull, ValueObject
    {
        protected AggregateRoot(
            TId id
            , UserId modifierUserId) 
            : base(id, modifierUserId)
        {
        }

        #pragma warning disable CS8618
        protected AggregateRoot()
        {

        }

        #pragma warning restore CS8618
    }
}
