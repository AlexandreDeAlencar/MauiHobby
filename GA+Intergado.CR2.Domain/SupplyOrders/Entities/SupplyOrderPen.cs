using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Pens.ValueObjects;
using GA_Intergado.CR2.Domain.Supplies.ValueObjects;
using GA_Intergado.CR2.Domain.SupplyOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.SupplyOrders.Entities
{
    [NotMapped]
    public sealed class SupplyOrderPen : AggregateRoot<SupplyOrderPenId>
    {
        private readonly List<SupplyPenId> _supplyPenIds = new();
        private SupplyOrderPen(
            SupplyOrderPenId id
            , UserId modifierUserId
            , PenId penId
            , decimal expectedAmountKg
            ) 
            : base(id, modifierUserId)
        {
            PenId= penId;
            ExpectedAmountKg = expectedAmountKg;
        }
        public PenId PenId { get; private set; }
        public decimal ExpectedAmountKg { get; private set; }
        public IReadOnlyList<SupplyPenId> SupplyPenIds => _supplyPenIds.AsReadOnly();
        public static SupplyOrderPen Create(
            UserId modifierUserId
            , PenId penId
            , decimal expectedAmountKg
            , SupplyOrderPenId? supplyOrderPenId = null
            )
        {
            return new(
                supplyOrderPenId ?? SupplyOrderPenId.CreateUnique()
                , modifierUserId
                , penId
                , expectedAmountKg
                );
        }
    }
}
