using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TechTalk.SpecFlow;
using ToDoList.Service;

namespace ToDoList.AcceptanceTests.Steps
{
    [Binding]
    public class CreateBoardSteps
    {

        Mock<IBoardService> _boardService = new Mock<IBoardService>();

        //No matching step definition found for the step. Use the following code to create one:
        [Given(@"that no boards exist")]
        public void GivenThatNoBoardsExist()
        {
            ScenarioContext.Current.Pending();
        }

        //And I have landed at the home page
        //-> No matching step definition found for the step. Use the following code to create one:
        [Given(@"I have landed at the home page")]
        public void GivenIHaveLandedAtTheHomePage()
        {
            ScenarioContext.Current.Pending();
        }

        //Then the result should be the welcome screen
        //-> No matching step definition found for the step. Use the following code to create one:
        [Then(@"the result should be the welcome screen")]
        public void ThenTheResultShouldBeTheWelcomeScreen()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
