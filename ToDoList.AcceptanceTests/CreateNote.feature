Feature: CreateBoard
	When I visit the home page
	As a user
	I want to be told to create a note if no notes exists

@mytag
Scenario: No Boards exist
	Given that no boards exist
	And I have landed at the home page
	Then the result should be the welcome screen
