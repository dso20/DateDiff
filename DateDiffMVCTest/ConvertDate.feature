Feature: ConvertDate

Scenario Outline: I enter valid dates to convert
			Given I enter a valid start date of <startday>/<startmonth>/<startyear>
			And I enter a vaild end date of <endday>/<endmonth>/<endyear>
			When I submit
			Then I get back the difference between the dates <diff>
			Examples:
			| startday | startmonth | startyear | endday | endmonth | endyear | diff    |
			| 1        | 4          | 1999      | 5      | 7        | 2010    | There are 11 Years 3 Months and 2 Days between these dates. |
			| 1        | 7          | 1999      | 4      | 4        | 2100    | There are 100 Years 8 Months and 10 Days between these dates. |
			| 27        | 4          | 1850      | 5      | 7        | 2010    | There are 160 Years 1 Months and 1 Days between these dates. |
			| 20        | 11          | 1999      | 2      | 7        | 2007    | There are 7 Years 8 Months and 11 Days between these dates. |

Scenario Outline: I enter invalid dates
		Given I enter a valid start date of <startday>/<startmonth>/<startyear>
		 And I enter a vaild end date of <endday>/<endmonth>/<endyear>
		 When I submit
		Then I get error message back <error>
		Examples:
			| startday | startmonth | startyear | endday | endmonth | endyear | error    |
			| 1        | 4          | 2020      | 5      | 7        | 2010    | Start year is in the past |
			| 1        | 7          | 2100      | 4      | 4        | 2100    | Start date is in the past |
			