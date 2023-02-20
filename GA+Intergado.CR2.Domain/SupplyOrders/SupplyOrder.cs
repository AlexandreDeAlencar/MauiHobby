using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Loadings.ValueObjects;
using GA_Intergado.CR2.Domain.Supplies;
using GA_Intergado.CR2.Domain.Supplies.ValueObjects;
using GA_Intergado.CR2.Domain.SupplyOrders.Entities;
using GA_Intergado.CR2.Domain.SupplyOrders.ValueObjects;
using GA_Intergado.CR2.Domain.SupplyTimes.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.Domain.SupplyOrders
{
    [NotMapped]
    public sealed class SupplyOrder : AggregateRoot<SupplyOrderId>
    {
        private readonly List<SupplyOrderPen> _supplyOrderPens = new();
        private readonly List<SupplyId> _supplysIds = new();
        private SupplyOrder(SupplyOrderId id
            , UserId modifierUserId
            , SupplyTimeId supplyTimeId
            , decimal expectedAmountKg
            , List<SupplyOrderPen>? supplyOrderPens
            ) 
            : base(id, modifierUserId)
        {
            SupplyTimeId = supplyTimeId;
            ExpectedAmountKg = expectedAmountKg;
            _supplyOrderPens = supplyOrderPens;
        }
        public SupplyTimeId SupplyTimeId { get; private set; }
        public decimal ExpectedAmountKg { get; private set; }
        public IReadOnlyList<SupplyOrderPen> SupplyOrderPens => _supplyOrderPens.AsReadOnly();
        public IReadOnlyList<SupplyId> SupplyIds => _supplysIds.AsReadOnly();
        public static SupplyOrder Create(
            UserId modifierUserId
            , SupplyTimeId supplyTimeId
            , decimal expectedAmountKg
            , List<SupplyOrderPen>? supplyOrderPens
            , SupplyOrderId? supplyOrderId = null
            )
        {
            return new(
                supplyOrderId ?? SupplyOrderId.CreateUnique()
                , modifierUserId
                , supplyTimeId
                , expectedAmountKg
                , supplyOrderPens
                );
        }
    }
}
