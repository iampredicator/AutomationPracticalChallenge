@GetCountry
Feature: GetCountryUsingZipCode

@PositiveScenario @API
Scenario Outline: Get Country name based on zip codes API
	When I get country name using zipcodes '<ZipCode>' while executing scenaio '<ScenarioName>'
	Then Country name 'United States' should be returned with status 'OK'.

	Examples:
		| ScenarioName | ZipCode |
		| ValidCode    | 90210   |
		| ValidCode    | 79201   |

@NegativeScenario @API
Scenario Outline: Try to get Country name based on invalid zip codes API
	When I try to get country name using invalid zipcodes '<ZipCode>' while executing scenaio '<ScenarioName>'
	Then API should throw status code 'NotFound'.

	Examples:
		| ScenarioName | ZipCode |
		| InvalidCode  | 123456  |
		| InvalidCode  | -1      |