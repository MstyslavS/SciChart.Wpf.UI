﻿using System;
using SciChart.UI.Reactive.Observability;
using NUnit.Framework;
using SciChart.UI.Reactive.Tests.QualityTools;

namespace SciChart.UI.Reactive.Tests.Observability
{
    [TestFixture]
    public class ExceptionViewModelTests
    {
        private ExceptionViewModelTestContext _ctx;

        public class ExceptionViewModelTestContext : TestContextBase { }

        [SetUp]
        public void Setup()
        {
            this._ctx = new ExceptionViewModelTestContext();
        }
        [Test]
        public void WhenHeaderUpdatedShouldUpdateMessages()
        {
            // Arrange
            var vm = new ExceptionViewModel();

            // Act
            vm.Header = "Something broke";

            // Assert
            Assert.That(vm.Messages, Is.EquivalentTo(new[] { "Something broke"}));
        }

        [Test]
        public void WhenExceptionUpdatedShouldUpdateMessages()
        {
            // Arrange
            var vm = new ExceptionViewModel();
            var inner1 = new ArgumentNullException("i", "An argument was null");
            var inner0 = new InvalidOperationException("Terrible failure", inner1);

            // Act
            vm.Header = "Something broke";
            vm.Exception = inner0;

            // Assert
            Assert.That(vm.Messages, Is.EquivalentTo(new[] { "Something broke", "InvalidOperationException: " + inner0.Message, "ArgumentNullException: " + inner1.Message }));
        }
    }
}