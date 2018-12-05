/// <summary>
///  This page is about initializing Search Results page
///  It is inheriting from PageObject
///  It has methods to verify if page is initialized and it calls Product Details page 
/// </summary>
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace Bunnings.Test.Pages
{
    public class SearchResultPage : PageObject
    {
        public SearchResultPage(ChromeDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.CssSelector, Using = "article.product-list__item")]
        public IList<IWebElement> _productListItems;

        [FindsBy(How = How.CssSelector, Using = "div.product-list-group")]
        public IWebElement _productList;

        [FindsBy(How = How.CssSelector, Using = "h1.search-result_header")]
        public IWebElement _resultsHeaderText;

        private By ProductName => By.CssSelector("article.product-list__item * div.product-list__prodname");

        //Verify is SearchResultsPage is intialized
        public bool SearchResultsPageInitialized()
        {
            return _resultsHeaderText.Displayed;
        }
        
        //Initialize ProductDetailsPage
        public ProductDetailsPage ProductDetailsInitialized(int index)
        {
            _productListItems[index].Click();
            return new ProductDetailsPage(driver);
        }

        //Get the selected product name
        public string SelectedProductName(int index)
        {
            string _productName = _productListItems[index].FindElement(ProductName).Text;
            return _productName;
        }
    }
}