using PromotionEngine.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Service.Services
{
    public class ThreeAFixPricePromotion : IPromotionApplyService
    {
        public int PromotionApply(List<string> skuType)
        {
            try
            {
                var remainder = skuType.Count % 3;
                int price = 0;
                for (int typeCount = 3; typeCount <= skuType.Count; typeCount += 3)
                {
                    price += 130;
                }
                if (remainder > 0)
                {
                    price += (remainder * 50);
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
