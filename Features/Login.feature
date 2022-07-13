Feature: Login

A user should be able to login to the instance using their username and passowrd.

Scenario: Login user with valid username and password.
	Given a user has navigated to the login page
	When the user clicks on the username field
	And the user enters their username
	And the user clicks on the password field
	And the user enters their password
	And the user clicks on the login button
	Then the user should be logged in to the instance
