using Coypu;
using Coypu.Drivers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Features
{
    [Binding]
    class BeerStudioSteps : Steps
    {
        private BrowserSession _session = new BrowserSession(new SessionConfiguration()
        {
            Browser = Browser.Chrome,
            AppHost = "localhost",
            Port = 1974,

        });

        [When(@"I visit the home page")]
        public void WhenIVisitTheHomePage()
        {
            _session.Visit("");
        }

        [Then(@"I should see the following details")]
        public void ThenIShouldSeeTheFollowingDetails(Table table)
        {
            _session.RetryUntilTimeout(() =>
            {
                var list = _session.FindId("list-beers");

                foreach (var row in table.Rows)
                {
                    Assert.IsTrue(list.Text.Contains(row["Name"]));
                    Assert.IsTrue(list.Text.Contains(row["Abv"]));
                }
            });
        }

        [When(@"I click on ""(.*)""")]
        public void WhenIClickOn(string p0)
        {
            _session.FindId("list-beers").FindLink(p0).Click();
        }

        [Then(@"it should show the details")]
        public void ThenItShouldShowTheDetails()
        {
            Assert.IsFalse(string.IsNullOrEmpty(_session.FindId("description").Text));
        }

        [AfterScenario]
        public void DisposeBrowser()
        {
            if (_session != null)
                _session.Dispose();
        }
    }
}
