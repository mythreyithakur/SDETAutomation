Feature: ParaBankCreateUser

A short summary of the feature

@RegressionTesting
Scenario: Create New User
	Given User Details
	| FirstName  | LastName   | Address                           | City     | ZipCode     | Phone       | SSN    | Username | Password     | Confirm
	| TestUserFN | TestUserLN | TestAddressTestAddressTestAddress | TestCity | TestZipCode | 12345678974 | 123456 | TestUser | TestPassword |TestPassword
	When User Details Entered
	Then Create New user 
