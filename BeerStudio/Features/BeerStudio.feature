Feature: BeerStudioFeatures
	In order to compare the beers
	As a beer enthusiast
	I want to be able to see them

Scenario: Compare beers
	When I visit the home page
	Then I should see the following details 
	| Name    | Abv  |
	| Imperial IPA 2 | 11.1 |
	| American Pale Ale | 15.1 |


Scenario: Check beer detail
	When I visit the home page
	Then I should see the following details 
	| Name    | Abv  |
	| Imperial IPA 2 | 11.1 |
	| American Pale Ale | 15.1 |
	When I click on "Imperial IPA 2" 
	Then it should show the details as
	| Description |
	|Hop Heads this one's for you! Checking in with 143 IBU's this ale punches you in the mouth with extreme bitterness then rounds out with toffee flavors and finishes with a citrus aroma. Made with tons of US 2 Row Barley to get this to ABV 11.1%. |