using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIOperationsTestTask
{
    /// <summary>
    /// Class contains help methods for Selenium Web Driver
    /// </summary>
    public class SeleniumHelper
    {
        private static readonly TimeSpan _defaultTimeoutScript = TimeSpan.FromSeconds(30);
        public IWebDriver Selenium { get; private set; }
        public EventFiringWebDriver _eventFiringWebDriver { get; set; }

        public SeleniumHelper()
        {
            var options = new ChromeOptions();
            options.AddArgument("--disable-extensions");
            options.AddArgument("--no-sandbox");
            options.LeaveBrowserRunning = false;
            _eventFiringWebDriver = new EventFiringWebDriver
                (new ChromeDriver(options));
            _eventFiringWebDriver.Manage().Window.Maximize();


            Selenium = _eventFiringWebDriver;
            Selenium.Manage().Timeouts().AsynchronousJavaScript = _defaultTimeoutScript;
        }

        private bool IsStopped()
        {
            return Selenium == null;
        } 

        /// <summary>
        /// Stopping Web Driver
        /// </summary>
        public void Stop()
        {
            if (IsStopped())
            {
                return;
            }

            DisposeWebDriver(Selenium, nameof(Selenium));
            Selenium = null;
        }

        private void DisposeWebDriver(IWebDriver webDriver, string webDriverType)
        {
            try
            {
                webDriver?.Quit();
                webDriver?.Dispose();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex, $"{webDriverType} stop error");
            }
        }
    }
}
