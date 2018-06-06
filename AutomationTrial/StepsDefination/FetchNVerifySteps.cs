using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutomationTrial.Global;
using AventStack.ExtentReports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using Microsoft.CSharp;
using AutomationTrial.Helpers;

namespace AutomationTrial.StepsDefination
{
    [Binding]
    public sealed class FetchNVerifySteps
    {
        
        private RestClient restClient;
        private RestRequest restRequest;
        private IRestResponse restResponse;
        private ExtentTest test = ScenarioContext.Current.Get<ExtentTest>();
        

        [Given(@"I want to know the Title for a given (.*)")]
        public void GivenIWantToKnowTheTitleForAGiven(int id)
        {
            restClient = new RestClient(Constants.ApiBaseUrl); //https://jsonplaceholder.typicode.com/posts

            restRequest = new RestRequest("{Id}", Method.GET);
            restRequest.RequestFormat = DataFormat.Json; 
            restRequest.AddUrlSegment("Id", id);
            
        }

        [When(@"I retrieve the title list for that season")]
        public void WhenIRetrieveTheTitleListForThatSeason()
        {
            restResponse = restClient.Execute(restRequest);
        }

        [Then(@"there should be Title (.*) in the list returned")]
        public void ThenThereShouldBeTitleToProvideOrToRejectTheBlindAreWelcomeOptionToFindInTheListReturned(string title)
        {
            dynamic jsonResponse = JsonConvert.DeserializeObject(restResponse.Content);
            try
            {
                Assert.AreEqual(Convert.ToString(jsonResponse.title), title.Trim());
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
