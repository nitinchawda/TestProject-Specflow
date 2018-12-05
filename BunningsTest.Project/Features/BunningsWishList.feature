Feature: Bunnings Wish List
	In order to test the "Wish list" functionality
	As a developer
	I want to search the item and add it to wish list

@mytag
Scenario: User can search for any product
	Given I have navigated to test site
	When I have searched for "Paint" in search box
	And I select the product from product details page
	And I add the product to wishlist
	Then The product is added to wishlist
