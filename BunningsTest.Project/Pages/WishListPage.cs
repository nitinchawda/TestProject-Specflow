/// <summary>
///  This page is about initializing Wish List page
///  It is inheriting from PageObject
///  It has methods to verify if page is loaded and return the added product to wish list details (name)/// 
/// </summary>
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace Bunnings.Test.Pages
{
    public class WishListPage : PageObject
    {
        public WishListPage(ChromeDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.CssSelector, Using = "table.table-product-list")]
        public IList<IWebElement> _productTable;

        [FindsBy(How = How.CssSelector, Using = "h2.primaryh2")]
        public IWebElement _wishListTitle;

        public By ProductName => By.CssSelector("a.GAEvent");

        //Returning Boolean method of page is displayed
        public bool WishListPageLoaded()
        {
            return _wishListTitle.Displayed;
        }

        //Get the product added name
        public string AddedProductName()
        {
            return _productTable[0].FindElement(ProductName).Text;
        }
    }
}