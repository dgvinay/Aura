using Aura.Core.Extensions;
using Aura.Core.UnitTest.Common;
using Moq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;
using Aura.Core.Models;

namespace Aura.Core.UnitTest.Extensions
{
    public class IWebDriverExtensionsTests
    {
        [Fact]
        public void FindElementByClassName()
        {
            var driver = new ChromeDriver(Constants.CHROME_DRIVER_PATH);
            Assert.Throws<NoSuchElementException>(() =>
            WebDriverExtensions.FindElement(driver,
                                ElementLocatorMethods.ClassName,
                                "abc"));
            driver.Quit();
        }

        [Fact]
        public void FindElementByCssSelector()
        {
            var driver = new ChromeDriver(Constants.CHROME_DRIVER_PATH);
            Assert.Throws<NoSuchElementException>(() =>
            WebDriverExtensions.FindElement(driver,
                                ElementLocatorMethods.CssSelector,
                                "abc"));
            driver.Quit();
        }

        [Fact]
        public void FindElementById()
        {
            var driver = new ChromeDriver(Constants.CHROME_DRIVER_PATH);
            Assert.Throws<NoSuchElementException>(() =>
            WebDriverExtensions.FindElement(driver,
                                ElementLocatorMethods.ID,
                                "abc"));
            driver.Quit();
        }

        [Fact]
        public void FindElementByLinkText()
        {
            var driver = new ChromeDriver(Constants.CHROME_DRIVER_PATH);
            Assert.Throws<NoSuchElementException>(() =>
            WebDriverExtensions.FindElement(driver,
                                ElementLocatorMethods.LinkText,
                                "abc"));
            driver.Quit();
        }

        [Fact]
        public void FindElementByName()
        {
            var driver = new ChromeDriver(Constants.CHROME_DRIVER_PATH);
            Assert.Throws<NoSuchElementException>(() =>
            WebDriverExtensions.FindElement(driver,
                                ElementLocatorMethods.Name,
                                "abc"));
            driver.Quit();
        }

        [Fact]
        public void FindElementByNone()
        {
            var driver = new ChromeDriver(Constants.CHROME_DRIVER_PATH);
            var element =
            WebDriverExtensions.FindElement(driver,
                                ElementLocatorMethods.None,
                                "abc");
            driver.Quit();
            Assert.Null(element);
        }

        [Fact]
        public void FindElementByPartialLinkText()
        {
            var driver = new ChromeDriver(Constants.CHROME_DRIVER_PATH);
            Assert.Throws<NoSuchElementException>(() =>
            WebDriverExtensions.FindElement(driver,
                                ElementLocatorMethods.PartialLinkText,
                                "abc"));
            driver.Quit();
        }

        [Fact]
        public void FindElementByTagName()
        {
            var driver = new ChromeDriver(Constants.CHROME_DRIVER_PATH);
            Assert.Throws<NoSuchElementException>(() =>
            WebDriverExtensions.FindElement(driver,
                                ElementLocatorMethods.TagName,
                                "abc"));
            driver.Quit();
        }

        [Fact]
        public void FindElementByXPath()
        {
            var driver = new ChromeDriver(Constants.CHROME_DRIVER_PATH);
            Assert.Throws<NoSuchElementException>(() =>
            WebDriverExtensions.FindElement(driver,
                                ElementLocatorMethods.XPath,
                                "abc"));
            driver.Quit();
        }

        [Fact]
        public void FindElementDriverException()
        {
            var driver = new Mock<IWebDriver>();
            Assert.Throws<ArgumentException>(() =>
            WebDriverExtensions.FindElement(driver.Object,
                                ElementLocatorMethods.None,
                                string.Empty));
        }

        [Fact]
        public void FindElementElementNullException()
        {
            var driver = new ChromeDriver(Constants.CHROME_DRIVER_PATH);
            Assert.Throws<ArgumentNullException>(() =>
            WebDriverExtensions.FindElement(driver,
                                ElementLocatorMethods.None,
                                string.Empty));
            driver.Quit();
        }
    }
}