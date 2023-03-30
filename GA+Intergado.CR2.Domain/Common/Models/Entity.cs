using GA_Intergado.CR2.Domain.Shared.Common;
using GA_Intergado.CR2.Domain.Users.ValueObjects;

namespace GA_Intergado.CR2.Domain.Common.Models
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull, ValueObject
    {
        public TId Id { get; protected set; }
        public DateTime LastModifiedDateTime { get; private set; }
        public StatusType Status { get; private set; }
        public UserId ModifierUserId { get; private set; }
        protected Entity(
                TId id
                , UserId modifierUserId)
        {
            Id = id;
            ModifierUserId = modifierUserId;
            LastModifiedDateTime = DateTime.Now;
        }

        public override bool Equals(object? obj)
        {
            return obj is Entity<TId> entity && Id.Equals(entity.Id);
        }

        public bool Equals(Entity<TId>? other)
        {
            return Equals((object?)other);
        }

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #pragma warning disable CS8618
        protected Entity()
        {

        }

        #pragma warning restore CS8618
    }
}
