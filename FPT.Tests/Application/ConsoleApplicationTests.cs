using System;
using System.IO;
using System.Text;
using FPT.ConsoleApp;
using Moq;
using NUnit.Framework;

namespace FPT.Tests
{
    [TestFixture]
    public class ConsoleApplicationTests
    {
        [Test]
        public void Run_CallsSingleRegisteredAction_Once()
        {
            //given
            var input = "1\nexit\n";
            TextReader reader;
            TextWriter writer;
            var sb = new StringBuilder();

            var actor = Mock.Of<IActor>(a=> a.Name == "Test Bot");
            var action = new Mock<IAction<IActor>>();

            var app = new ConsoleApplication<IActor>();

            app.Register(1, "test", action.Object);

            //when
            int exitCode = -1;
            using (reader = new StringReader(input))
            {
                using (writer = new StringWriter(sb))
                {
                    exitCode = app.Run(actor, reader, writer);
                }
            }

            //then
            Assert.That(exitCode, Is.EqualTo(0));
            action.Verify(a => a.Execute(It.Is<IActorContext<IActor>>(c =>
            c.Actor == actor &&
            c.In == reader &&
            c.Out == writer)), Times.Once);
        }

        [Test]
        public void Register_ThrowsOnIdDuplication()
        {
            //given
            var app = new ConsoleApplication<IActor>();

            //when
            app.Register(1, "test", It.IsAny<IAction<IActor>>());

            //then
            var ex = Assert.Throws<InvalidOperationException>(() => app.Register(1, "test", It.IsAny<IAction<IActor>>()));

            Assert.That(ex.Message, Is.EqualTo("Sorry ,the item with key 1 was already registered."));
        }
    }
}
