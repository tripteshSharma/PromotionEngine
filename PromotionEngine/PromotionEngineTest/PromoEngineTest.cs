using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PromotionEngine.Controllers;
using PromotionEngine.Service.Contracts;
using System.Collections.Generic;

namespace PromotionEngineTest
{
    [TestClass]
    public class PromoEngineTest
    {
        [TestMethod]
        public void ApplyPromo()
        {
            var mock = new Mock<IPromotionService>();
            var promotionController = new PromotionEngineController(mock.Object);
            var skuType = new List<string> { "A", "A", "B", "B", "c" };
            var result = promotionController.ApplyPromotion(skuType);

            var okResult = result as OkObjectResult;

            // assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
