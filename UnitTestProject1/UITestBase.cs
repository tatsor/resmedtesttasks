using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UIOperationsTestTask
{
    /// <summary>
    /// Class contains interactions witgh UI controls
    /// </summary>
    public class UITestBase
    {
        public enum Selectors
        {
            Id,
            ClassName,
            TagName,
            Name,
            LinkText,
            PartialLinkText,
            CSS,
            XPath
        }

        public SeleniumHelper DriverHelper = new SeleniumHelper();
        private IWebDriver _webDriver
        {
            get
            {
                return DriverHelper.Selenium;
            }
        }

        protected string GetCurrentUrl()
        {
            try
            {
                return _webDriver.Url;
            }
            catch
            {
                return "";
            }
        }

        protected void NavigateToFullUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        protected bool DoesElementExist(Selectors availableSelectors, string selector)
        {
            By by;

            switch (availableSelectors)
            {
                case Selectors.Id:
                    {
                        by = By.Id(selector);
                        break;
                    }
                case Selectors.ClassName:
                    {
                        by = By.ClassName(selector);
                        break;
                    }
                case Selectors.TagName:
                    {
                        by = By.TagName(selector);
                        break;
                    }
                case Selectors.CSS:
                    {
                        by = By.CssSelector(selector);
                        break;
                    }
                case Selectors.XPath:
                    {
                        by = By.XPath(selector);
                        break;
                    }

                default:
                    throw new NotSupportedException("The Key [" + availableSelectors + "] is not supported");
            }

            try
            {
                var result = _webDriver.FindElement(by);
                if (result == null)
                {
                    return false;
                }
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }

        protected void Click(string id)
        {
            var control = _webDriver.FindElement(By.Id(id));
            control.Click();
        }

        protected void WaitUntilElementExists(Selectors availableSelectors, string selector)
        {
            By by;

            switch (availableSelectors)
            {
                case Selectors.Id:
                    {
                        by = By.Id(selector);
                        break;
                    }
                case Selectors.ClassName:
                    {
                        by = By.ClassName(selector);
                        break;
                    }
                case Selectors.TagName:
                    {
                        by = By.TagName(selector);
                        break;
                    }
                case Selectors.CSS:
                    {
                        by = By.CssSelector(selector);
                        break;
                    }
                case Selectors.XPath:
                    {
                        by = By.XPath(selector);
                        break;
                    }

                default:
                    throw new NotSupportedException("The Key [" + availableSelectors + "] is not supported");
            }

            var wait = GetDefaultWait();
            wait.Until(drv => drv.FindElement(by));
        }

        private WebDriverWait GetDefaultWait()
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
        }

        protected void SetTextBoxValue(string id, string value)
        {
            var control = _webDriver.FindElement(By.Id(id));
            control.SendKeys(value);
        }
    }
}
