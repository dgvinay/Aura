using Aura.Core.Enums;
using OpenQA.Selenium;

namespace Aura.Core.Extensions
{
    public static class WindowExtensions
    {
        public static void SetWindowMode(this IWindow window, BrowserWindowMode windowMode)
        {
            switch (windowMode)
            {
                case BrowserWindowMode.FullScreen:
                    window.FullScreen();
                    break;

                case BrowserWindowMode.Maximize:
                    window.Maximize();
                    break;

                case BrowserWindowMode.Minimize:
                    window.Minimize();
                    break;
            }
        }
    }
}