using Aura.Core.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Aura.Core.AutomationDriver
{
    /// <summary>
    /// </summary>
    /// <seealso cref="Aura.Core.AutomationDriver.IAutomationDriver" />
    public class DefaultChromeDriver : AutomationDriverBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultChromeDriver" /> class.
        /// </summary>
        /// <param name="driverPath">The driver path.</param>
        /// <param name="windowMode">The window mode.</param>
        /// <exception cref="ArgumentNullException">driverPath</exception>
        public DefaultChromeDriver(AutomationDriverOptions options)
            : base(options)
        {
            SeleniumWebDriver = new ChromeDriver(options.DriverPath);
            SeleniumWebDriver.Manage().Window.SetWindowMode(options.WindowMode);
        }

        /// <summary>
        /// Gets the selenium web driver.
        /// </summary>
        /// <value>The selenium web driver.</value>
        public override IWebDriver SeleniumWebDriver { get; protected set; }
    }
}