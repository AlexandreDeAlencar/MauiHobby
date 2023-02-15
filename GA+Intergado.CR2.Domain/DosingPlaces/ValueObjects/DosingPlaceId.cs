using GA_Intergado.CR2.Domain.LoadingPlaces.ValueObjects;
using GA_Intergado.CR2.Domain.Shared.Common;

namespace GA_Intergado.CR2.Domain.DosingPlaces.ValueObjects
{
    public sealed class DosingPlaceId : LoadingPlaceId
    {
        public Guid Value { get; }

        private DosingPlaceId(Guid value)
            : base(value, LoadingPlaceType.DosingPlace)
        {
            Value = value;
        }

        public static DosingPlaceId CreateUnique()
        {
            return new DosingPlaceId(Guid.NewGuid());
        }

        public static DosingPlaceId Create(Guid value)
        {
            return new(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
