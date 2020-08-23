using System.Collections.Generic;

namespace PromotionEngine.Service.Contracts
{
    public interface IPromotionService
    {
        public int CheckAndApplyPromotion(List<string> skuType);
    }
}
