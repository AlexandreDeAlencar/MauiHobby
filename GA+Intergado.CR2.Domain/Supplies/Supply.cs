using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Common.ValueObjects;
using GA_Intergado.CR2.Domain.Loadings.ValueObjects;
using GA_Intergado.CR2.Domain.Supplies.Entities;
using GA_Intergado.CR2.Domain.Supplies.ValueObjects;
using GA_Intergado.CR2.Domain.SupplyOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.Domain.Supplies
{
    [NotMapped]
    public sealed class Supply : AggregateRoot<SupplyId>
    {
        private readonly List<SupplyPen> _supplyPens = new();
        private Supply(SupplyId id
            , UserId modifierUserId
            , SupplyOrderId supplyOrderId
            , LoadingId loadingId
            , AmountKg amountKg
            , List<SupplyPen>? supplyPens
            ) 
            : base(id, modifierUserId)
        {
            SupplyOrderId = supplyOrderId;
            LoadingId = loadingId;
            AmountKg = amountKg;
            _supplyPens = supplyPens;
        }
        public SupplyOrderId SupplyOrderId { get; private set; }
        public LoadingId LoadingId { get; private set; }
        public AmountKg AmountKg { get; private set; }
        public IReadOnlyList<SupplyPen> SupplyPens => _supplyPens.AsReadOnly();
        public static Supply Create(
            UserId modifierUserId
            , SupplyOrderId supplyOrderId
            , LoadingId loadingId
            , AmountKg amountKg
            , List<SupplyPen>? supplyPens
            , SupplyId? supplyId = null
            )
        {
            return new(
                supplyId ?? SupplyId.CreateUnique()
                , modifierUserId
                , supplyOrderId
                , loadingId
                , amountKg
                , supplyPens
                );
        }
    }
}
