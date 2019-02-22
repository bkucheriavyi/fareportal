using FPT.Business.Repositories;
using FPT.Business.Services.Model;
using NUnit.Framework;

namespace FPT.Tests.IntegrationTests
{
    [TestFixture(Category = "Integation")]
    public class DefaultAdditivesRepositoryTests
    {

        [Test]
        public void GetAdditives_Returns()
        {
            //given
            var repo = new DefaultAdditivesRepository();

            //when
            var result = repo.Get(new[] { 1,2,3, 12,-100 });

            //then

            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result[2].Id, Is.EqualTo(3));
            Assert.That(result[2].Name, Is.EqualTo("Milk"));
            Assert.That(result[2].Group, Is.EqualTo(AdditiveGroup.Coffe | AdditiveGroup.Tea));
            Assert.That(result[2].Price, Is.EqualTo(2));
        }
    }
}
