using Aura.Core.Enums;

namespace Aura.Core.AutomationDriver
{
    /// <summary>
    /// </summary>
    public class AutomationDriverOptions
    {
        /// <summary>
        /// Gets or sets the driver path.
        /// </summary>
        /// <value>The driver path.</value>
        public string DriverPath { get; set; }

        /// <summary>
        /// Gets or sets the screenshot images path.
        /// </summary>
        /// <value>The screenshot images path.</value>
        public string ScreenshotImagesPath { get; set; }

        /// <summary>
        /// Gets or sets the window mode.
        /// </summary>
        /// <value>The window mode.</value>
        public BrowserWindowMode WindowMode { get; set; }
    }
}