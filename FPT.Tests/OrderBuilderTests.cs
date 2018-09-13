using System;
using System.Collections.Generic;
using System.Text;
using FPT.Business;
using Moq;
using NUnit.Framework;

namespace FPT.Tests
{
    [TestFixture]
    public class OrderBuilderTests
    {
        [Test]
        public void Test()
        {
            //given
            var beverage1 = new Beverage();
            var additive1 = new Additive();
            var additive2 = new Additive();
            var additiveIds = new[] {1};
            var beverageIds = new[] {6, 4};
            
            var beverageRepository = Mock.Of<IRepository<Beverage>>(r => r.Get(1) == beverage1);
            var additivesRepository = Mock.Of<IRepository<Additive>>(r => r.Get(6) == additive1 || r.Get(4) == additive2);
            var orderBuilder = new OrderBuilder(beverageRepository, additivesRepository);

            //when
            Order order = orderBuilder.MakeOrder(additiveIds, beverageIds);

            //then
            Assert.That(order.Beverages.Count, Is.EqualTo(1));
            Assert.That(order.Beverages[0], Is.SameAs(beverage1));
            Assert.That(order.Additives.Count, Is.EqualTo(2));
            Assert.That(order.Additives[0], Is.SameAs(additive1));
            Assert.That(order.Additives[1], Is.SameAs(additive2));
        }
    }
}
