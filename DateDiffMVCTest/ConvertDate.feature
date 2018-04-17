Feature: ConvertDate

Scenario Outline: I enter valid dates to convert
			Given I enter a valid start date of <startday>/<startmonth>/<startyear>
			And I enter a vaild end date of <endday>/<endmonth>/<endyear>
			When I submit
			Then I get back the difference betweent he dates <diff>
			Examples:
			| startday | startmonth | startyear | endday | endmonth | endyear | diff    |
			| 1        | 4          | 1999      | 5      | 7        | 2010    | There are 11 Years 3 Months and 2 Days between these dates. |
			| 1        | 7          | 1999      | 4      | 4        | 2100    | There are 100 Years 8 Months and 10 Days between these dates. |
			| 27        | 4          | 1850      | 5      | 7        | 2010    | There are 160 Years 1 Months and 1 Days between these dates. |
			| 20        | 11          | 1999      | 2      | 7        | 2007    | There are 7 Years 8 Months and 11 Days between these dates. |