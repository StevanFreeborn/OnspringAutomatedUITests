Feature: ResetPasswordLink

A user should be able to click on a forgot password link on the login page to go to a forgot password page.

Scenario: User navigates to the login page and clicks on the forgot password link.
	Given a user has navigated to the login page
	When the user clicks on the forgot password link
	Then the user will be taken to the forgot password page.

