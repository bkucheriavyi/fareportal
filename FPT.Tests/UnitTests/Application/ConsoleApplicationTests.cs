﻿using System;
using System.IO;
using System.Text;
using FPT.Business.Application;
using FPT.Business.Application.Interfaces;
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
        [TestCase("")]
        [TestCase("still not and integer")]
        [TestCase(null)]
        public void Run_InputWasntString_NoActionCalls(string testCase)
        {
            //given
            var input = $"{testCase}\nexit\n";
            var expected = "Hello Test Bot, choose action and press enter when ready:\n1. test\nWrong input, expected integer ID\n1. test\n";
            TextReader reader;
            TextWriter writer;
            var sb = new StringBuilder();

            var actor = Mock.Of<IActor>(a => a.Name == "Test Bot");
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
            Assert.That(sb.ToString(), Is.EqualTo(expected));
            action.Verify(a => a.Execute(It.IsAny<IActorContext<IActor>>()), Times.Never);
        }

        [Test]

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void Run_InputIdWasOutOfTheRange_NoActionCalls(int testCase)
        {
            //given
            var input = $"{testCase}\nexit\n";
            var expected = $"Hello Test Bot, choose action and press enter when ready:\n1. test\nSorry Test Bot, there is no action registered with #{testCase}\n1. test\n";
            TextReader reader;
            TextWriter writer;
            var sb = new StringBuilder();

            var actor = Mock.Of<IActor>(a => a.Name == "Test Bot");
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
            Assert.That(sb.ToString(), Is.EqualTo(expected));
            action.Verify(a => a.Execute(It.IsAny<IActorContext<IActor>>()), Times.Never);
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
