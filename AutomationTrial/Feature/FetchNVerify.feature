Feature: FetchNVerify
	In order to verify Users
	As available on Public API website
	I want to know the Title for a given Id

@api
Scenario Outline: Verify the Title for a given ID
	Given I want to know the Title for a given <Id>
	When I retrieve the title list for that season
	Then there should be Title <title>  in the list returned
	Examples:
	| Id  | title																		|
	| 1   | sunt aut facere repellat provident occaecati excepturi optio reprehenderit  |
	| 2   | qui est esse																|
	| 3   | ea molestias quasi exercitationem repellat qui ipsa sit aut					|
	| 4   | eum et est occaecati														|
	| 5   | nesciunt quas odio															|
	| 6   | dolorem eum magni eos aperiam quia											|