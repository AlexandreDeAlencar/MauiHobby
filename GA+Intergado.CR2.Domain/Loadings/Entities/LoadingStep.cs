using GA_Intergado.CR2.Domain.Common.Models;
using GA_Intergado.CR2.Domain.Common.ValueObjects;
using GA_Intergado.CR2.Domain.LoadingOrders.ValueObjects;
using GA_Intergado.CR2.Domain.Loadings.ValueObjects;
using GA_Intergado.CR2.Domain.Users.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA_Intergado.CR2.Domain.Loadings.Entities
{
    [NotMapped]
    public sealed class LoadingStep : Entity<LoadingStepId>
    {
        private LoadingStep(LoadingStepId id
            , UserId modifierUserId
            , AmountKg amountKg
            , LoadingOrderStepId loadingOrderStepId
            ) : base(id, modifierUserId)
        {
            AmountKg= amountKg;
            LoadingOrderStepId = loadingOrderStepId;
        }
        public AmountKg AmountKg { get; private set; }
        public LoadingOrderStepId LoadingOrderStepId { get; private set; }
        public static LoadingStep Create(
            UserId modifierUserId
            , AmountKg amountKg
            , LoadingOrderStepId loadingOrderStepId
            , LoadingStepId? loadingStepsId = null
            )
        {
            return new(
                loadingStepsId ?? LoadingStepId.CreateUnique()
                , modifierUserId
                , amountKg
                , loadingOrderStepId
                );
        }
    }
}
