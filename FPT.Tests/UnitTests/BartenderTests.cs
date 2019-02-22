using System;
using FPT.Business;
using FPT.Business.Services.Interaces;
using FPT.Business.Services.Model;
using Moq;
using NUnit.Framework;

namespace FPT.Tests
{
    [TestFixture]
    public class BartenderTests
    {
        [Test]
        public void CreateOrder_ReturnsOrderWithNewId()
        {
            //given
            var barService = Mock.Of<IBarService>();
            var bartender = new Bartender("Test Bot", barService);

            //when
            var result = bartender.CreateOrder();

            //then
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test]
        public void CreateOrder_MultipleTimes_ReturnsOrderWithIncrementedId()
        {
            //given
            var barService = Mock.Of<IBarService>();
            var bartender = new Bartender("Test Bot", barService);

            //when
            bartender.CreateOrder();
            bartender.CreateOrder();
            var result = bartender.CreateOrder();

            //then
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(3));
        }

        [Test]
        public void GetBeverage_ReturnsBeverage()
        {
            //given
            var expected = new Beverage { Id = 1 };
            var barService = Mock.Of<IBarService>(s => s.GetBeverages(new[] { 1 }) == new[] { expected });
            var bartender = new Bartender("Test Bot", barService);

            //when
            var result = bartender.GetBeverage("1");

            //then
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetBeverage_NoBeverageFound_Throws()
        {
            //given
            var barService = Mock.Of<IBarService>();
            var bartender = new Bartender("Test Bot", barService);

            //when
            //then
            var ex = Assert.Throws<InvalidOperationException>(() => bartender.GetBeverage("1"));
            Assert.That(ex.Message, Is.EqualTo("No beverages with id 1 were found\n"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("not and integer for sure")]
        public void GetBeverage_IdWasNotAnIntegerValue_Throws(string input)
        {
            //given
            var bartender = new Bartender("Test Bot", null);

            //when
            //then
            var ex = Assert.Throws<InvalidOperationException>(() => bartender.GetBeverage(input));
            Assert.That(ex.Message, Is.EqualTo($"Failed to parse string '{input}', integer value expected\n"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("blabla")]
        [TestCase("2|3|3")]
        [TestCase("not a number or array")]
        public void GetAdditives_AdditivesStringIsNotValid_Throws(string value)
        {
            //given
            var beverage = new Beverage { Id = 1, Group = AdditiveGroup.Coffe };
            var additive = new Additive { Id = 1, Group = AdditiveGroup.Tea | AdditiveGroup.Coffe };
            var barService = Mock.Of<IBarService>(s => s.GetAdditives(new[] { 1 }) == new[] { additive });
            var bartender = new Bartender("Test Bot", barService);

            //when
            //then
            var ex = Assert.Throws<InvalidOperationException>(()=> bartender.GetAdditives(beverage, $"1, {value},2"));
            Assert.That(ex.Message, Is.EqualTo($"Failed to parse string '{value}', integer value expected\n"));
        }

        [Test]
        public void GetAdditives_BeverageIsCompatible_ReturnsAdditive()
        {
            //given
            var beverage = new Beverage { Id = 1, Group = AdditiveGroup.Coffe };
            var additive = new Additive { Id = 1, Group = AdditiveGroup.Tea | AdditiveGroup.Coffe };
            var barService = Mock.Of<IBarService>(s => s.GetAdditives(new[] { 1 }) == new[] { additive });
            var bartender = new Bartender("Test Bot", barService);

            //when
            var result = bartender.GetAdditives(beverage, "1");

            //then
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0], Is.EqualTo(additive));
        }

        [Test]
        public void GetAdditives_ManyOrDuplicated_ReturnsManyOrDuplicativeAdditives()
        {
            //given
            var beverage = new Beverage { Id = 1, Group = AdditiveGroup.Coffe };
            var additive4 = new Additive { Id = 4, Group = AdditiveGroup.Tea | AdditiveGroup.Coffe };
            var additive3 = new Additive { Id = 3, Group = AdditiveGroup.Tea | AdditiveGroup.Coffe };

            var barService = Mock.Of<IBarService>(s => s.GetAdditives(new[] { 4, 3, 4 }) == new[] { additive4, additive3, additive4 });
            var bartender = new Bartender("Test Bot", barService);

            //when
            var result = bartender.GetAdditives(beverage, "4,3,4");

            //then
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo(additive4));
            Assert.That(result[1], Is.EqualTo(additive3));
            Assert.That(result[2], Is.EqualTo(additive4));
        }

        [Test]
        public void GetAdditives_BeverageIsNotCompatible_Throws()
        {
            //given
            var beverage = new Beverage { Id = 1, Name = "Test Name", Group = AdditiveGroup.Coffe };
            var additive4 = new Additive { Id = 4, Group = AdditiveGroup.Tea | AdditiveGroup.Coffe };
            var additive3 = new Additive { Id = 3, Group = AdditiveGroup.Tea };
            var barService = Mock.Of<IBarService>(s => s.GetAdditives(new[] { 1 }) == new[] { additive4, additive3, additive4 });
            var bartender = new Bartender("Test Bot", barService);

            //when
            //then
            var ex = Assert.Throws<InvalidOperationException>(() => bartender.GetAdditives(beverage, "1"));
            Assert.That(ex.Message, Is.EqualTo($"Some of the additives is not be compatible with Test Name\n"));
        }
    }
}
