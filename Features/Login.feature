Feature: Login

A user should be able to login to the instance using their valid username and passowrd. 
A user should not be able to login if they enter an invalid username and password combination.
A user should be locked out for 1 minute if they make 5 failed login attempts.

Scenario: Login user with valid username and password.
	Given a user has navigated to the login page
	When the user enters their username
	And the user enters their password
	And the user clicks on the login button
	Then the user should be logged in to the instance

Scenario: Prevent user from logging in when password is invalid.
	Given a user has navigated to the login page
	When the user enters their username
	And the user enters an invalid password
	And the user clicks on the login button
	Then the user should not be logged in to the instance
	And the invalid username/password error message should be displayed to the user