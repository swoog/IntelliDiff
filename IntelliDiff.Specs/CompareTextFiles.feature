Feature: Compare Text Files
	In order to avoid comparison tool.
	As a user
	I want to compare text file

Scenario: Compare same file
	Given I have the first file:
	"""
Line 1
	"""
	And I have the seconde file :
	"""
Line 1
	"""
	When I press compare
	Then the result is equal

Scenario: Compare different file
	Given I have the first file:
	"""
Line 1
	"""
	And I have the seconde file :
	"""
Line 2
	"""
	When I press compare
	Then the result is not equal

Scenario: Compare file with add line
	Given I have the first file:
	"""
Line 1
	"""
	And I have the seconde file :
	"""
Line 1
Line 2
	"""
	When I press compare
	Then the result is :
	| Line | Type | Value  |
	| 2    | Add  | Line 2 |

Scenario: Compare file with del line
	Given I have the first file:
	"""
Line 1
Line 2
	"""
	And I have the seconde file :
	"""
Line 1
	"""
	When I press compare
	Then the result is :
	| Line | Type | Value  |
	| 2    | Del  | Line 2 |

Scenario: Compare file with del line into others
	Given I have the first file:
	"""
Line 1
Line 2
Line 3
Line 4
	"""
	And I have the seconde file :
	"""
Line 1
Line 3
Line 4
	"""
	When I press compare
	Then the result is :
	| Line | Type | Value  |
	| 2    | Del  | Line 2 |