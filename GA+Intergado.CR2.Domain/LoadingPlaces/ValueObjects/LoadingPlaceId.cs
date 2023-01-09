using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Shared.Common;

namespace GA_Intergado.CR2.Domain.LoadingPlaces.ValueObjects
{
    public abstract class LoadingPlaceId : ValueObject
    {
        public Guid Value { get; }
        public LoadingPlaceType LoadingPlaceType { get; }

        protected LoadingPlaceId(Guid value, LoadingPlaceType loadingPlaceType)
        {
            Value = value;
            LoadingPlaceType = loadingPlaceType;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return LoadingPlaceType;
        }
    }
}
