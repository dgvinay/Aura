using OpenQA.Selenium;

namespace Aura.Core.AutomationDriver.Interfaces
{
    /// <summary>
    /// </summary>
    public interface IAutomationDriver
    {
        /// <summary>
        /// Gets the driver options.
        /// </summary>
        /// <value>The driver options.</value>
        AutomationDriverOptions DriverOptions { get; }

        /// <summary>
        /// Gets the selenium web driver.
        /// </summary>
        /// <value>The selenium web driver.</value>
        IWebDriver SeleniumWebDriver { get; }

        /// <summary>
        /// Captures the screen shot.
        /// </summary>
        /// <returns></returns>
        string CaptureScreenshotToFile();

        /// <summary>
        /// Closes this instance.
        /// </summary>
        void Close();
    }
}