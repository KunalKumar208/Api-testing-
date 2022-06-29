Feature: APITesting
         To check  Api is working Fine 

@Complete 
Scenario: Get All Employee data
 	When user send Get request 
	Then  user should able to verify the result sucessfully

@Complete 
Scenario: Get Single employee data
When  user send a Get request 
Then  user should able to  see  employee details sucessfully

@complete
Scenario: Create a new employee request 
When user send post request 
Then  user should able to Create Id & details & See success 

@complete
Scenario: Upadte a  employee  record
When user send put request 
Then user should able to verify update details & see Success


@complete
Scenario: Delete a employee record 
When user send delete request 
Then user should able to verify the result sucessfully