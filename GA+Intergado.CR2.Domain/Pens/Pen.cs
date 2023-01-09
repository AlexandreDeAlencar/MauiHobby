using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Pens.ValueObjects;
using GA_Intergado.CR2.Domain.SupplyOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;

namespace GA_Intergado.CR2.Domain.Pens
{
    public sealed class Pen : AggregateRoot<PenId>
    {
        private readonly List<SupplyOrderPenId> _supplyOrderPenIds = new();
        private Pen(PenId id
            , UserId modifierUserId
            , string line 
            , int number
            , string name 
            , string initialTag
            , string finalTag
            )
            : base(id, modifierUserId)
        {
            Line = line;
            Number = number;
            Name = name;
            InitialTag = initialTag;
            FinalTag = finalTag;
        }
        public string Line { get; }
        public int Number { get; }
        public string Name { get; }
        public string InitialTag { get; }
        public string FinalTag { get; }
        public IReadOnlyList<SupplyOrderPenId> SupplyOrderPenIds => _supplyOrderPenIds.AsReadOnly();
        public static Pen Create(
            UserId modifierUserId
            , string line
            , int number
            , string name
            , string initialTag
            , string finalTag
            , PenId? penId =  null
            )
        {
            return new(
                penId ?? PenId.CreateUnique()
                , modifierUserId
                , line
                , number
                , name
                , initialTag
                , finalTag
                );
        }
    }
}
