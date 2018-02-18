The following solution contains 3 projects: one for each test task
The solution was created in Visual Studio 2015 and can be opened in Visual Studio or Visual Code

1. PublicAPITestTask is the project for the following test: Demonstrate GET and POST request testing of any open REST service available on net.
https://jsonplaceholder.typicode.com/ was used for the example
Project contains Post class which represents user posts and PublicApiTestTask unit test class with sample tests 
for GetAll, GetById and Post new post. Project can be compiled and tests can be run from the test explorer
in the solution or from command line

2. UIOperationTestTask is the project for the following test: Demonstrate launching a web page in browser and doing basic operations like sending text, clicking on an element etc.
It contains multiple classes. Task2UITests is a unit test class, which can be run from the test explorer or command line.
It launches chrome web browser and navigates to Microsoft login page, where user name is entered, next button is clicked 
and invalid password is provided for the password field.

3. MarsRoverTestTask project is a project for the second test task. It's a console application, which expects multiple line input followed by the empty line to indicate end of input. The project can be set as startup project and can be run from Visual studio 



Known issues: 
All of the tests above are just a sample tests and do not provide a comprehensive coverage for all possible test scenarios
Not all methods and public variables have comments
It would be better to use XUnit instead of MS testing tools for unit tests