Feature: Login
	As a new user
	I want to login to my account
	So that I can access articles

Scenario: Sign In to new account
	Given User Login with correct details successfully
	Then the Home page is displayed

Scenario: Sign Out of Account
	Given User Login with correct details successfully
	When the User Logs Out
	Then the Conduit Web Page is displayed

@UnsuccessfulRegistration
Scenario Outline: Unsuccessful Registration
	Given the User navigates to Sign up page
	When the User enters the Username '<username>' and the Email '<email>' and the Password '<password>'
	Then the Error Message '<errorMsg>' is displayed

Examples: 
| name                | username              | email        | password   | errorMsg                                        |
| Username Registered | Duke42                | dave@bt.com  | Password01 | username has already been taken                 |
| Email Registered    | Duke12                | bobis@bt.com | Password01 | email has already been taken                    |
| Blank Email         | Duke50                |              | Password01 | email can't be blank                            |
| Blank Username      |                       | bill@bt.com  | Password01 | username can't be blank                         |
| Blank Password      | Duke22                | steve@bt.com |            | password can't be blank                         |
| Password too short  | Duke78                | jez@bt.com   | w          | password is too short (minimum is 8 characters) |
| Username too long   | Duke123456Duke1234567 | tony@bt.com  | Password01 | username is too long (maximum is 20 characters) |