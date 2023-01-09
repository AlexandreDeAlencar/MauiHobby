using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Supplies.ValueObjects;
using GA_Intergado.CR2.Domain.SupplyOrders.ValueObjects;
using GA_Intergado.CR2.Domain.SupplyTimes.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.Domain.SupplyTimes
{
    public sealed class SupplyTime : AggregateRoot<SupplyTimeId>
    {
        private readonly List<SupplyOrderId> _supplyOrderIds = new();
        private SupplyTime(SupplyTimeId id
            , UserId modifierUserId
            , DateTime ExpectedDatetime
            ) 
            : base(id, modifierUserId)
        {
        }
        public DateTime ExpectedDatetime { get; }
        public IReadOnlyList<SupplyOrderId> SupplyOrderIds => _supplyOrderIds.AsReadOnly();
        public static SupplyTime Create (
            UserId modifierUserId
            , DateTime ExpectedDatetime
            , SupplyTimeId? supplyTimeId = null
            )
        {
            return new SupplyTime(
                supplyTimeId?? SupplyTimeId.CreateUnique()
                , modifierUserId
                , ExpectedDatetime );
        }
    }
}
