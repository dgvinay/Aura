using Aura.Core.AutomationDriver;
using Aura.Core.AutomationDriver.Interfaces;

namespace Aura.Core.UnitTest.Common
{
    public class Driver
    {
        public static IAutomationDriver GetChromeDriver()
        {
            return new DefaultChromeDriver(new AutomationDriverOptions
            {
                DriverPath = Constants.CHROME_DRIVER_PATH,
                ScreenshotImagesPath = Constants.SCREENSHOT_IMAGES_PATH,
                WindowMode = Enums.BrowserWindowMode.Maximize
            });
        }
    }
}