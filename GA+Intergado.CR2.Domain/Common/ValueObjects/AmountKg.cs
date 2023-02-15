using GA_Intergado.CR2.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.Domain.Common.ValueObjects
{
    public sealed class AmountKg : ValueObject
    {
        private AmountKg(
            decimal initialWeightKg
            , decimal finalWeightKg
            )
        {
            InitialWeightKg = initialWeightKg;
            FinalWeightKg = finalWeightKg;
            Value = finalWeightKg - initialWeightKg;
        }
        public decimal InitialWeightKg { get;}
        public decimal FinalWeightKg { get;}
        public decimal Value { get; }

        public static AmountKg CreateNew(
            decimal initialWeightKg
            , decimal finalWeightKg
            )
        {
            return new (initialWeightKg, finalWeightKg);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return InitialWeightKg;
            yield return FinalWeightKg;
        }
    }
}
