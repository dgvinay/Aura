using Aura.Core.Enums;
using Aura.Core.Extensions;
using Moq;
using OpenQA.Selenium;
using Xunit;

namespace Aura.Core.UnitTest.Extensions
{
    public class IWindowExtensionsTests
    {
        [Fact]
        public void SetWindowModeFullScreen()
        {
            var window = new Mock<IWindow>();
            WindowExtensions.SetWindowMode(window.Object, BrowserWindowMode.FullScreen);
        }

        [Fact]
        public void SetWindowModeMaximize()
        {
            var window = new Mock<IWindow>();
            WindowExtensions.SetWindowMode(window.Object, BrowserWindowMode.Maximize);
        }

        [Fact]
        public void SetWindowModeMinimize()
        {
            var window = new Mock<IWindow>();
            WindowExtensions.SetWindowMode(window.Object, BrowserWindowMode.Minimize);
        }
    }
}