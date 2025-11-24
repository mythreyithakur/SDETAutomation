Feature: ParaBankCreateUser

A short summary of the feature

@RegressionTesting
Scenario: Create New User
	Given User Details
	| FirstName  | LastName
	| TestUserFN | TestUserLN
	When User Details Entered
	Then Create New user 
