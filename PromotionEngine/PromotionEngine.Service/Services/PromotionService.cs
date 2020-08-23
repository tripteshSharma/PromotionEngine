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

                //Check and apply C's promotion
                int cSKUTypePrice = PromotionCheckAndApplyForCType(skuType);

                //Check and apply C's promotion
                int dSKUTypePrice = PromotionCheckAndApplyForDType(skuType);

                return aSKUTypePrice + bSKUTypePrice + cSKUTypePrice + dSKUTypePrice;
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
        private int PromotionCheckAndApplyForCType(List<string> skuType)
        {
            var cType = skuType.FindAll(e => e == "C");
            var dType = skuType.FindAll(e => e == "D");
            int price = 0;

            //Get price of C SKU types on which combo promotion was not applied.
            if (cType.Count > 0 && dType.Count > 0)
            {
                if (cType.Count > dType.Count)
                {
                    var promotionNotAppliedCTypeCount = cType.Count - dType.Count;
                    price = promotionNotAppliedCTypeCount * 20;
                }
            }

            //If any new promotion for C type comes add 'if' check and promotion class for that

            else
            {
                //If no promotion applied.
                price = cType.Count * 20;
            }

            return price;
        }
        private int PromotionCheckAndApplyForDType(List<string> skuType)
        {
            var cType = skuType.FindAll(e => e == "C");
            var dType = skuType.FindAll(e => e == "D");
            int price = 0;

            if (cType.Count > 0 && dType.Count > 0)
            {
                IPromotionApplyService promotionApplyService = new SKUCAndDComboPromotion();
                price = ApplyPromotion(promotionApplyService, skuType);

                if (dType.Count > cType.Count)
                {
                    var promotionNotAppliedCTypeCount = dType.Count - cType.Count;
                    price += (promotionNotAppliedCTypeCount * 15);
                }
            }

            //If any new promotion for D type comes add 'else if' check and promotion class for that

            else
            {
                //If no promotion applied.
                price = dType.Count * 15;
            }

            return price;
        }
        private int ApplyPromotion(IPromotionApplyService promotionApplyService, List<string> skuType)
        {
            return promotionApplyService.PromotionApply(skuType);
        }
    }
}
