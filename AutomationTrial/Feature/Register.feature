Feature: Register
	In order to navigate to NopCommerce page
	As I never have registered on the page
	I want to Register on NopCommerce website

@browser
Scenario: Register on NopCommerce website
	Given I have navigated to url for NopCommerce
	And I have clicked on Register
	And I have been navigated to Register page 
	And I enter my Credentials to register
	When I click on Register
	Then my account should be registerd on NopCommerce website
