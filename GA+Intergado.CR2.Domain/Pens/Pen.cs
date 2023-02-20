using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Pens.ValueObjects;
using GA_Intergado.CR2.Domain.SupplyOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.Pens
{
    [NotMapped]
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
        public string Line { get; private set; }
        public int Number { get; private set; }
        public string Name { get; private set; }
        public string InitialTag { get; private set; }
        public string FinalTag { get; private set; }
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
