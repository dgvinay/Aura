using Aura.Core.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace Aura.Core.Extensions
{
    /// <summary>
    /// </summary>
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Finds the element.
        /// </summary>
        /// <param name="webDriver">The web driver.</param>
        /// <param name="method">The method.</param>
        /// <param name="elementName">Name of the element.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Invalid driver.</exception>
        public static IWebElement FindElement(this IWebDriver webDriver, ElementLocatorMethods method, string elementName)
        {
            if (!(webDriver is RemoteWebDriver driver))
            {
                throw new ArgumentException("Invalid driver.");
            }

            if (string.IsNullOrEmpty(elementName))
            {
                throw new ArgumentNullException(nameof(elementName));
            }

            switch (method)
            {
                case ElementLocatorMethods.ID:
                    return driver.FindElementById(elementName);

                case ElementLocatorMethods.ClassName:
                    return driver.FindElementByClassName(elementName);

                case ElementLocatorMethods.CssSelector:
                    return driver.FindElementByCssSelector(elementName);

                case ElementLocatorMethods.LinkText:
                    return driver.FindElementByLinkText(elementName);

                case ElementLocatorMethods.Name:
                    return driver.FindElementByName(elementName);

                case ElementLocatorMethods.None:
                    return null;

                case ElementLocatorMethods.PartialLinkText:
                    return driver.FindElementByPartialLinkText(elementName);

                case ElementLocatorMethods.TagName:
                    return driver.FindElementByTagName(elementName);

                case ElementLocatorMethods.XPath:
                    return driver.FindElementByXPath(elementName);
            }

            return null;
        }
    }
}