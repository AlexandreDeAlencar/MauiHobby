using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Common.ValueObjects;
using GA_Intergado.CR2.Domain.Pens.ValueObjects;
using GA_Intergado.CR2.Domain.Supplies.ValueObjects;
using GA_Intergado.CR2.Domain.SupplyOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.Domain.Supplies.Entities
{
    public sealed class SupplyPen : Entity<SupplyPenId>
    {
        private SupplyPen(SupplyPenId id
            , UserId modifierUserId
            , SupplyOrderPenId supplyOrderPenId
            , AmountKg amountKg
            ) 
            : base(id, modifierUserId)
        {
            SupplyOrderPenId = supplyOrderPenId;
            AmountKg = amountKg;
        }
        public SupplyOrderPenId SupplyOrderPenId { get; }
        public AmountKg AmountKg { get; }
        public static SupplyPen Create(
             UserId modifierUserId
            , SupplyOrderPenId supplyOrderPenId
            , AmountKg amountKg
            , SupplyPenId? supplyPenId = null
            )
        {
            return new(
                supplyPenId ?? SupplyPenId.CreateUnique()
                , modifierUserId
                , supplyOrderPenId
                , amountKg
                );
        }
    }
}
