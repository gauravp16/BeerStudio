Feature: BeerStudioFeatures
	In order to compare the beers
	As a beer enthusiast
	I want to be able to see them

Scenario: Compare beers
	When I visit the home page
	Then I should see the following details 
	| Name    | Abv  |
	| Organic | 11.1 |
	| Not Organic | 15.1 |


Scenario: Check beer detail
	When I visit the home page
	Then I should see the following details 
	| Name    | Abv  |
	| Organic | 11.1 |
	| Not Organic | 15.1 |
	When I click on "Organic" 
	Then it should show the details