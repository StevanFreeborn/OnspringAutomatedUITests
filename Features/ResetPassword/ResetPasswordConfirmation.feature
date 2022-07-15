Feature: ResetPasswordConfirmation

When a user enters their username into the field on the forgot password page and clicks the reset via email button a confirmation message should be displayed informing them of next steps.

Scenario: User navigates to the forgot password page and requests to reset password
	Given a user has navigated to the forgot password page
	When the user enters their username on the forgot password page
	And the user clicks the reset via email button
	Then the reset password message should be displayed
