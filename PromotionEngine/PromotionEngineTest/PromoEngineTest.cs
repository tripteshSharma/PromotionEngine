using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PromotionEngine.Controllers;
using PromotionEngine.Service.Contracts;
using PromotionEngine.Service.Services;
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
        [TestMethod]
        public void PromotionCheckAndApplyTestCase1()
        {
            var promotionservice = new PromotionService();
            var skuType = new List<string> { "A", "B", "C" };
            var result = promotionservice.CheckAndApplyPromotion(skuType);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(100, result);
        }
        [TestMethod]
        public void PromotionCheckAndApplyTestCase2()
        {
            var promotionservice = new PromotionService();
            var skuType = new List<string> { "A", "A", "A", "A", "A", "B", "B", "B", "B", "B", "C" };
            var result = promotionservice.CheckAndApplyPromotion(skuType);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(370, result);
        }
        [TestMethod]
        public void PromotionCheckAndApplyTestCase3()
        {
            var promotionservice = new PromotionService();
            var skuType = new List<string> { "A", "A", "A", "B", "B", "B", "B", "B", "C", "D" };
            var result = promotionservice.CheckAndApplyPromotion(skuType);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(280, result);
        }
    }
}
