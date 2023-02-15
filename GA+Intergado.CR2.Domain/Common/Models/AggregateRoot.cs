using GA_Intergado.CR2.Domain.Users.ValueObjects;

namespace GA_Intergado.CR2.Domain.Common.Models
{
    public abstract class AggregateRoot<TId> : Entity<TId>
        where TId : notnull
    {
        protected AggregateRoot(
            TId id
            , UserId modifierUserId) 
            : base(id, modifierUserId)
        {
        }
    }
}
