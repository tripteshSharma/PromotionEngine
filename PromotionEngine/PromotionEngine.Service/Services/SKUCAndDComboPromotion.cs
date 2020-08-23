using PromotionEngine.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Service.Services
{
    public class SKUCAndDComboPromotion : IPromotionApplyService
    {
        public int PromotionApply(List<string> skuType)
        {
            try
            {
                //Implement C & D combo price promotion calculations.
                var cType = skuType.FindAll(e => e == "C");
                var dType = skuType.FindAll(e => e == "D");

                int comboSet = 0;

                if (cType.Count > dType.Count)
                    comboSet = dType.Count;
                else
                    comboSet = cType.Count;

                return comboSet * 30;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
