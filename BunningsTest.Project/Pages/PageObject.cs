///<summary>
/// This is base page object to initialize driver and pass on to other pages
/// </summary>
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Bunnings.Test.Pages
{
    public class PageObject
    {
        public T As<T>() where T : PageObject
        {
            return (T)this;
        }
        protected ChromeDriver driver;
        protected WebDriverWait wait;

        public PageObject(ChromeDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            PageFactory.InitElements(driver, this);
        }
    }
}
