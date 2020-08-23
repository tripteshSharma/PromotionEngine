using PromotionEngine.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Service.Services
{
    public class TwoBsFixedPricePromotion : IPromotionApplyService
    {
        public int PromotionApply(List<string> skuType)
        {
            try
            {
                //Implement two B's fixed price promotion calculations.
                var remainder = skuType.Count % 2;
                int price = 0;
                for (int typeCount = 2; typeCount <= skuType.Count; typeCount += 2)
                {
                    price += 45;
                }
                if (remainder > 0)
                {
                    price += (remainder * 30);
                }

                return price;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
