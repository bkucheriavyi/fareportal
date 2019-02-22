using FPT.Business.Repositories;
using FPT.Business.Services.Model;
using NUnit.Framework;

namespace FPT.Tests.IntegrationTests
{
    [TestFixture(Category = "Integation")]
    public class DefaultBeveragesRepositoryTests
    {

        [Test]
        public void GetBeverages_Returns()
        {
            //given
            var repo = new DefaultBeveragesRepository();

            //when
            var result = repo.Get(new[] { 1,2,3 });

            //then

            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0].Id, Is.EqualTo(1));
            Assert.That(result[0].Name, Is.EqualTo("coffee"));
            Assert.That(result[0].Group, Is.EqualTo(AdditiveGroup.Coffe));
            Assert.That(result[0].Price, Is.EqualTo(15));
        }
    }
}
