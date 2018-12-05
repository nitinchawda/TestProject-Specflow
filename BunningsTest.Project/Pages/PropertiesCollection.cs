/// <summary>
/// Collecting PageObject types and get and set methods of PageObject type
/// </summary>
using Bunnings.Test.Pages;
using TechTalk.SpecFlow;

namespace BunningsTest.Project.Pages
{
    public class PropertiesCollection
    {
        private static PageObject pageObject;

        public static PageObject CurrentPage
        {
            get { return pageObject; }
            set
            {
                ScenarioContext.Current["class"] = value;
                pageObject = ScenarioContext.Current.Get<PageObject>("class");
            }
        }
    }
}
