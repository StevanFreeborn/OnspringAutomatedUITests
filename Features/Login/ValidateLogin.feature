Feature: ValidateLogin

A user should not be able to login if they enter an invalid username and password combination.

Scenario: Prevent user from logging in when password is invalid.
	Given a user has navigated to the login page
	When the user enters their username
	And the user enters an invalid password
	And the user clicks on the login button
	Then the user should not be logged in to the instance
	And the invalid username/password error message should be displayed to the user

Scenario: Prevent user from logging in when username is invalid.
	Given a user has navigated to the login page
	When the user enters an invalid username
	And the user enters their password
	And the user clicks on the login button
	Then the user should not be logged in to the instance
	And the invalid username/password error message should be displayed to the user
