using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Shared.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.LoadingPlaces.ValueObjects
{
    [NotMapped]
    public abstract class LoadingPlaceId : ValueObject
    {
        public Guid Value { get; private set; }
        public LoadingPlaceType LoadingPlaceType { get; private set; }

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
