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
                int aSKUTypePrice = PromotionCheckAndApplyForAType(skuType);

                //Check and apply B's promotion
                int bSKUTypePrice = PromotionCheckAndApplyForBType(skuType);

                return aSKUTypePrice + bSKUTypePrice;                
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


        private int PromotionCheckAndApplyForBType(List<string> skuType)
        {
            var bType = skuType.FindAll(e => e == "B");
            int price = 0;

            //Check for 2 B's promotion
            if (bType.Count >= 2)
            {
                IPromotionApplyService promotionApplyService = new TwoBsFixedPricePromotion();
                price = ApplyPromotion(promotionApplyService, bType);
            }
            //If any new promotion for B type comes add 'else if' check and promotion class for that

            else
            {
                //If no promotion applied.
                price = bType.Count * 30;
            }

            return price;
        }

        private int ApplyPromotion(IPromotionApplyService promotionApplyService, List<string> skuType)
        {
            return promotionApplyService.PromotionApply(skuType);
        }
    }
}
