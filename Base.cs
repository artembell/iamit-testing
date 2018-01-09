using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
namespace IamIT.Tests.UI
{
    public class Base : IDisposable
    {
        protected const string BaseUrl = "https://iamit.gq/";
        //protected const string BaseUrl = "http://192.168.0.53:8080/";
        //protected const string BaseUrl = "http://localhost:8080/";

        protected readonly RemoteWebDriver Driver;

        public Base()
        {
            Driver = new ChromeDriver(".");
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Navigate().GoToUrl(BaseUrl);
        }

        protected void CheckSuccessAlert()
        {
            var alertClassAttribute = Driver.FindElementByXPath("//*[@id=\"content\"]/div/div[1]/div/div/div")
                .GetAttribute("class");
            if (!alertClassAttribute.Contains("alert-success"))
            {
                throw new Exception("No success alert");
            }
        }

        protected void SelectNewTaskVersion()
        {
            Driver.FindElementById("Primary").Click();
            var versions = Driver.FindElementsByCssSelector("li[role=presentation]");
            versions[0].Click();
        }

        public void Dispose() => Driver.Quit();
    }
}