using GA_Intergado.CR2.Domain.Users.ValueObjects;

namespace GA_Intergado.CR2.Domain.Common.Models
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
    {
        public TId Id { get; protected set; }
        public DateTime LastModifiedDateTime { get; }
        public DateTime status { get; }
        public UserId ModifierUserId { get; }
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
    }
}
