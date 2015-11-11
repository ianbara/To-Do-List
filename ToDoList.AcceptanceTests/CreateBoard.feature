Feature: CreateBoard
	In order to create notes I first need a board
	As a new user
	I want to be told to create a board if no board exists

@mytag
Scenario: No Boards exist
	Given that no boards exist
	And I have landed at the home page
	Then the result should be the welcome screen
