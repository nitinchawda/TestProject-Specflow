///<summary>
///  This page is about initializing Product Details page
///  It is inheriting from PageObject
///  It has methods to verify if page is loaded and it has methods to get the product details of selected product
///  It has method to add the selected product to wish list
///  It has method to call Wish List Page
/// </summary>
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace Bunnings.Test.Pages
{
    public class ProductDetailsPage : PageObject
    {
        public ProductDetailsPage(ChromeDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.CssSelector, Using = "div.page-title>h1[itemprop = name]")]
        public IWebElement _productDetailsName;

        [FindsBy(How = How.CssSelector, Using = "button[data-action = add-to-wish-list]")]
        public IWebElement _wishListButton;

        [FindsBy(How = How.CssSelector, Using = "button[data-action = add-to-wish-list]>span")]
        public IWebElement _successMessage;

        [FindsBy(How = How.CssSelector, Using = "a[title = 'Wish List']")]
        public IWebElement _wishListLink;

        public bool ProductDetailsPageLoaded()
        {
            return _wishListButton.Enabled;
        }

        public string GetProductDetails()
        {
            return _productDetailsName.Text;
        }

        public ProductDetailsPage AddToWishList()
        {
            _wishListButton.Click();
            return this;
        }

        public string AddingToWishListSuccessMessage()
        {
            return _successMessage.Text;
        }

        public WishListPage WishListPageInitialized()
        {
            _wishListLink.Click();
            return new WishListPage(driver);
        }
    }
}