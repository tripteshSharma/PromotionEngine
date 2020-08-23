using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Service.Contracts;
using System;
using System.Collections.Generic;

namespace PromotionEngine.Controllers
{
    public class PromotionEngineController : Controller
    {
        private readonly IPromotionService _promotionServices;
        public PromotionEngineController(IPromotionService promotionServices)
        {
            _promotionServices = promotionServices;
        }
        public IActionResult ApplyPromotion(List<string> skuType)
        {
            try
            {
                return Ok(new { Result = _promotionServices.CheckAndApplyPromotion(skuType) });
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}