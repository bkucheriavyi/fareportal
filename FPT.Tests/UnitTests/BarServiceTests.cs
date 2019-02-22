using FPT.Business.Repositories;
using FPT.Business.Services;
using FPT.Business.Services.Interaces;
using FPT.Business.Services.Model;
using Moq;
using NUnit.Framework;

namespace FPT.Tests
{
    [TestFixture]
    public class BarServiceTests
    {
        [Test]
        public void CloseOrder_CallculuatesTotal()
        {
            //given
            var order = new Order(1);
            var calculator = Mock.Of<IBarCalculator>(c => c.Calculate(order) == 10);
            var service = new BarService(null, null, calculator);

            //when
            var result = service.CloseOrder(order);

            //then
            Assert.That(result.Total, Is.EqualTo(10));
        }

        [Test]
        public void GetBeverages_ReturnsBeveragesListByIds()
        {
            //given
            var ids = new[] { 1, 2 };
            var beverages = new[] { new Beverage() };
            var repo = Mock.Of<IBarRepository<Beverage>>(r => r.Get(ids) == beverages);
            var service = new BarService(repo, null, null);

            //when
            var result = service.GetBeverages(ids);

            //then
            Assert.That(result, Is.EqualTo(beverages));
        }

        [Test]
        public void GetAdditives_ReturnsAdditivesListByIds()
        {
            //given
            var ids = new[] { 1, 2 };
            var additives = new[] { new Additive() };
            var repo = Mock.Of<IBarRepository<Additive>>(r => r.Get(ids) == additives);
            var service = new BarService(null, repo, null);

            //when
            var result = service.GetAdditives(ids);

            //then
            Assert.That(result, Is.EqualTo(additives));
        }
    }
}
