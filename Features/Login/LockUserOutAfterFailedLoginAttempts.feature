Feature: LockUserOutAfterFailedLoginAttempts

A user should be locked out for 1 minute if they make 5 failed login attempts.

Scenario: Prevent user from logging in for 1 minute after 5 failed login attempts.
	Given a user has navigated to the login page
	And the user has attempted to login 5 times unsuccessfully
	When the user enters their username
	And the user enters their password
	Then the user should not be logged in to the instance
	And the invalid username/password error message should be displayed to the user
	Given the user waited 1 minutes
	When the user enters their username
	And the user enters their password
	And the user clicks on the login button
	Then the user should be logged in to the instance
