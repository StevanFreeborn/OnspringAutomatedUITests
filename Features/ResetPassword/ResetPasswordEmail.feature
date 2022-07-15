Feature: ResetPasswordEmail

When a user enters a valid username for an active user and clicks the reset via email button on the forgot password page they should receive an email with a link allowing them to reset their password.

@mailslurp
Scenario: User navigates to the forgot password page and requests to reset password
	Given a user has navigated to the forgot password page
	When the user enters their username on the forgot password page
	And the user clicks the reset via email button
	Then the user should receive a password reset email