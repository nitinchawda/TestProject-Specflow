///<summary>
/// This is Home Page having search options and initializing SearchResults page
/// This is inheriting from PageObject
/// </summary>
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace Bunnings.Test.Pages
{
    public class HomePage : PageObject
    {
        public HomePage(ChromeDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.CssSelector, Using = "input.search-container_term")]
        public IWebElement _searchbox;

        [FindsBy(How = How.CssSelector, Using = ".search-container_btn-submit")]
        public IWebElement _searchButton;

        public bool pageInitilaized()
        {
            return _searchbox.Enabled;
        }

        public SearchResultPage searchProduct(string product)
        {
            _searchbox.Clear();
            _searchbox.SendKeys(product);
            _searchButton.Click();
            return new SearchResultPage(driver);
        }
    }
}