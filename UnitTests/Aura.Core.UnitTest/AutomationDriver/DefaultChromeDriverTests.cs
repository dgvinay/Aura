using Aura.Core.AutomationDriver;
using Aura.Core.UnitTest.Common;
using System;
using System.IO;
using Xunit;

namespace Aura.Core.UnitTest.AutomationDriver
{
    public class DefaultChromeDriverTests
    {
        [Fact]
        public void InitializationEmptyDriverPath()
        {
            Assert.Throws<ArgumentNullException>(() => new DefaultChromeDriver(new AutomationDriverOptions
            {
                DriverPath = ""
            }));
        }

        [Fact]
        public void InitializationEmptyImagesPath()
        {
            Assert.Throws<ArgumentNullException>(() => new DefaultChromeDriver(new AutomationDriverOptions
            {
                DriverPath = Constants.CHROME_DRIVER_PATH,
                ScreenshotImagesPath = ""
            }));
        }

        [Fact]
        public void InitializationIncorrectDriverPath()
        {
            Assert.Throws<FileNotFoundException>(() => new DefaultChromeDriver(new AutomationDriverOptions
            {
                DriverPath = "abc"
            }));
        }

        [Fact]
        public void InitializationIncorrectImagesPath()
        {
            Assert.Throws<DirectoryNotFoundException>(() => new DefaultChromeDriver(new AutomationDriverOptions
            {
                DriverPath = Constants.CHROME_DRIVER_PATH,
                ScreenshotImagesPath = "abc"
            }));
        }

        [Fact]
        public void InitializationMustPass()
        {
            var result = new DefaultChromeDriver(new AutomationDriverOptions
            {
                DriverPath = Constants.CHROME_DRIVER_PATH,
                ScreenshotImagesPath = Constants.SCREENSHOT_IMAGES_PATH
            });
            Assert.NotNull(result);
            result.Close();
        }

        [Fact]
        public void InitializationWithBrowserModeMustPass()
        {
            var result = new DefaultChromeDriver(new AutomationDriverOptions
            {
                DriverPath = Constants.CHROME_DRIVER_PATH,
                ScreenshotImagesPath = Constants.SCREENSHOT_IMAGES_PATH,
                WindowMode = Enums.BrowserWindowMode.FullScreen
            });
            Assert.NotNull(result);
            result.Close();
        }

        [Fact]
        public void InitializationWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => new DefaultChromeDriver(null));
        }
    }
}