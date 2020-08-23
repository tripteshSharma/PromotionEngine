using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Service.Contracts
{
    public interface IPromotionApplyService
    {
        public int PromotionApply(List<string> skuType);
    }
}
