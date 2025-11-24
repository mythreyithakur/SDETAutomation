using System;
using Reqnroll;

namespace PlaywrightTests.ReqnrollProject.StepDefinitions
{
    [Binding]
    public class ParaBankCreateUserStepDefinitions
    {
        [Given("User Details")]
        public void GivenUserDetails(DataTable dataTable)
        {
            var userDetails = dataTable.CreateInstance<ParaBankUserDetails>();
            
        }

        [When("User Details Entered")]
        public void WhenUserDetailsEntered()
        {
            
        }

        [Then("Create New user")]
        public void ThenCreateNewUser()
        {
            
        }
    }
}
