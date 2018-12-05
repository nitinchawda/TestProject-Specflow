using Bunnings.Test.Pages;
using BunningsTest.Project.Hooks;
using BunningsTest.Project.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BunningsTest.Project
{
    [Binding]
    public class BunningsWishListSteps : WebDriverSupport
    {

        private readonly WebDriverSupport _wdsupport;
        public BunningsWishListSteps(WebDriverSupport wdsupport)
        {
            _wdsupport = wdsupport;
        }

        [Given(@"I have navigated to test site")]
        public void GivenIHaveNavigatedToTestSite()
        {

            PropertiesCollection.CurrentPage = new HomePage(driver);
        }

        [When(@"I have searched for ""(.*)"" in search box")]
        public void WhenIHaveSearchedForInSearchBox(string p0)
        {
            PropertiesCollection.CurrentPage = PropertiesCollection.CurrentPage.As<HomePage>().searchProduct(p0);
        }

        [When(@"I select the product from product details page")]
        public void WhenISelectTheProductFromProductDetailsPage()
        {
            var resultsPage = PropertiesCollection.CurrentPage.As<SearchResultPage>();
            var selectedProductText = resultsPage.SelectedProductName(2);
            PropertiesCollection.CurrentPage = PropertiesCollection.CurrentPage.As<SearchResultPage>().ProductDetailsInitialized(2);
        }

        [When(@"I add the product to wishlist")]
        public void WhenIAddTheProductToWishlist()
        {
            var productDetailsPage = PropertiesCollection.CurrentPage.As<ProductDetailsPage>();
            ScenarioContext.Current["SelectedProductName"] = productDetailsPage.GetProductDetails();
            productDetailsPage.AddToWishList().AddingToWishListSuccessMessage();
            PropertiesCollection.CurrentPage = productDetailsPage.WishListPageInitialized();
        }

        [Then(@"The product is added to wishlist")]
        public void ThenTheProductIsAddedToWishlist()
        {

            var wishListPage = PropertiesCollection.CurrentPage.As<WishListPage>();
            Assert.True(wishListPage.WishListPageLoaded());
            var productName = ScenarioContext.Current["SelectedProductName"];
            Assert.True(productName.Equals(wishListPage.AddedProductName()));
            
        }

    }
}
