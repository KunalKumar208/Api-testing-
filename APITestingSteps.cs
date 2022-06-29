using ComprehensiveAssesmentApiTesting_RestSharp_.CommonObjecMethodsFile;
using System;
using TechTalk.SpecFlow;

namespace ComprehensiveAssesmentApiTesting_RestSharp_.StepDefinition
{
    [Binding]
    public class APITestingSteps
    {

        ApiTestingObject ApiObj = new ApiTestingObject();

        [When(@"user send Get request")]
        public void WhenUserSendGetRequest()
        {
            ApiObj.GetAllEmployeeData();
            
        }

        [When(@"user send a Get request")]
        public void WhenUserSendAGetRequest()
        {
            ApiObj.GetASingleEmployeeData();
        }


        [When(@"user send post request")]
        public void WhenUserSendPostRequest()
        {
            ApiObj.Post();

        }

      

        [Then(@"user should able to  see  employee details sucessfully")]
        public void ThenUserShouldAbleToSeeEmployeeDetailsSucessfully()
        {
            ApiObj.VerifySinglerequest();
        }

        [Then(@"user should able to Create Id & details & See success")]
        public void ThenUserShouldAbleToCreateIdDetailsSeeSuccess()
        {
            ApiObj.VerifyPost();

        }

        [Then(@"user should able to verify update details & see Success")]
        public void ThenUserShouldAbleToVerifyUpdateDetailsSeeSuccess()
        {
            ApiObj.VerifyPut();
        }


        [When(@"user send put request")]
        public void WhenUserSendPutRequest()
        {
            ApiObj.PUT();

        }

        
        [When(@"user send delete request")]
        public void WhenUserSendDeleteRequest()
        {
            ApiObj.DELETE();
        }
        
        [Then(@"user should able to verify the result sucessfully")]
        public void ThenUserShouldAbleToVerifyTheResultSucessfully()
        {
            ApiObj.VerifyGetrequest();
        }
    }
}
