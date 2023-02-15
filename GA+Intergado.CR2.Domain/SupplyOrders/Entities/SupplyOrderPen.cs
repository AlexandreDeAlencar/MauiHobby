using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Pens.ValueObjects;
using GA_Intergado.CR2.Domain.Supplies.ValueObjects;
using GA_Intergado.CR2.Domain.SupplyOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;


namespace GA_Intergado.CR2.Domain.SupplyOrders.Entities
{
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
        public PenId PenId { get; }
        public decimal ExpectedAmountKg { get; }
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
