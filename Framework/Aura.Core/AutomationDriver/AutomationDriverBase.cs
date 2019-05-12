using Aura.Common.Extensions;
using Aura.Core.AutomationDriver.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;

namespace Aura.Core.AutomationDriver
{
    /// <summary>
    /// </summary>
    /// <seealso cref="Aura.Core.AutomationDriver.Interfaces.IAutomationDriver" />
    public abstract class AutomationDriverBase : IAutomationDriver
    {
        private readonly AutomationDriverOptions _driverOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutomationDriverBase" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public AutomationDriverBase(AutomationDriverOptions options)
        {
            if (options.IsNull())
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (!options.DriverPath.HasValue())
            {
                throw new ArgumentNullException(nameof(options.DriverPath));
            }

            if (!options.DriverPath.IsValidFolderPath())
            {
                throw new FileNotFoundException($"Driver was not found at path \"{options.DriverPath}\"");
            }

            if (!options.ScreenshotImagesPath.HasValue())
            {
                throw new ArgumentNullException(nameof(options.ScreenshotImagesPath));
            }

            if (!options.ScreenshotImagesPath.IsValidFolderPath())
            {
                throw new DirectoryNotFoundException($"Specifed folder was not found [{options.ScreenshotImagesPath}].");
            }

            _driverOptions = options;
        }

        /// <summary>
        /// Gets the driver options.
        /// </summary>
        /// <value>The driver options.</value>
        public AutomationDriverOptions DriverOptions { get { return _driverOptions; } }

        /// <summary>
        /// Gets the selenium web driver.
        /// </summary>
        /// <value>The selenium web driver.</value>
        public abstract IWebDriver SeleniumWebDriver { get; protected set; }

        /// <summary>
        /// Captures the screenshot to file.
        /// </summary>
        /// <returns></returns>
        public virtual string CaptureScreenshotToFile()
        {
            var screenshotDriver = (ITakesScreenshot)SeleniumWebDriver;
            var screenshot = screenshotDriver.GetScreenshot();
            var screenShotFileName = Guid.NewGuid().ToString("N");
            var screenShotFullPath = Path.Combine(_driverOptions.ScreenshotImagesPath, screenShotFileName + ".png");

            screenshot.SaveAsFile(screenShotFullPath);

            return screenShotFullPath;
        }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public virtual void Close()
        {
            SeleniumWebDriver.Quit();
        }
    }
}