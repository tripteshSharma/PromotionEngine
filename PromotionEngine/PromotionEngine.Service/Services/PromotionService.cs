using PromotionEngine.Service.Contracts;
using System;
using System.Collections.Generic;

namespace PromotionEngine.Service.Services
{
    public class PromotionService : IPromotionService
    {
        public int CheckAndApplyPromotion(List<string> skuType)
        {
            try
            {
                //Check and apply A's promotion
                int aTypePrice = PromotionCheckAndApplyForAType(skuType);

                return aTypePrice;                
            }
            catch (Exception)
            {
                throw;
            }
        }

        private int PromotionCheckAndApplyForAType(List<string> skuType)
        {
            var aType = skuType.FindAll(e => e == "A");
            int price = 0;

            //Check for 3 A's promotion
            if (aType.Count >= 3)
            {
                IPromotionApplyService promotionApplyService = new ThreeAFixPricePromotion();
                price = ApplyPromotion(promotionApplyService, aType);
            }

            //If any new promotion for A type comes add 'else if' check and promotion class for that

            else
            {
                //If no promotion applied.
                price = aType.Count * 50;
            }

            return price;
        }

        private int ApplyPromotion(IPromotionApplyService promotionApplyService, List<string> skuType)
        {
            return promotionApplyService.PromotionApply(skuType);
        }
    }
}
