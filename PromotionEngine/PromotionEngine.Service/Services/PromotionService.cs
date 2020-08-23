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
                return 0;                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
