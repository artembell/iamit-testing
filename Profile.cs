using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace IamIT.Tests.UI
{
    public class Profile : LoginedBase
    {
        [Fact]
        public void TestChangeProfile()
        {
            GoToSettings();
            var displayNameInput = Driver.FindElementById("displayNameInput");
            displayNameInput.Clear();
            displayNameInput.SendKeys("TestUser");

            // VirtualizeSelect is not <select> ... can't find element to select.
            //SelectElement selectTimezone = new SelectElement(Driver.FindElementByXPath("//*[@id=\"react-select-2--value\"]/div[1]"));
            //SelectElement selectCountry = new SelectElement(Driver.FindElementByXPath("//*[@id=\"react-select-3--value\"]/div[1]"));
            //SelectElement selectLanguage = new SelectElement(Driver.FindElementByXPath("//*[@id=\"react-select-4--value\"]/div[1]"));
            //SelectFirst(new List<SelectElement> { selectTimezone, selectCountry, selectLanguage });

            Driver.FindElementById("saveBtn").Click();
            CheckSuccessAlert();
        }

        [Fact]
        public void TestAddAndDeleteEmail()
        {
            GoToSettings();
            Driver.FindElementByXPath("//*[@id=\"content\"]/div/div[2]/div[1]/div/ul/li[2]/a").Click();
            Driver.FindElementById("showAddEmailBtn").Click();
            var emailInput = Driver.FindElementById("emailInput");
            emailInput.SendKeys("test@test.test");
            var initEmailRowsCount = Driver.FindElementsById("emailContainer").Count;
            Driver.FindElementById("addBtn").Click();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement newEmailSpan;
            try
            {
                newEmailSpan = wait.Until(x =>
                {
                    var spans = x.FindElements(By.Id("emailContainer"));
                    return spans.Count > initEmailRowsCount ? spans[spans.Count - 1] : null;
                });
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("email not add");
            }

            newEmailSpan.FindElement(By.Id("delete")).Click();
            wait.Until(ExpectedConditions.StalenessOf(newEmailSpan));
            Driver.FindElementById("cancelBtn").Click();
        }

        private void GoToSettings()
        {
            Driver.FindElementById("userMenu").Click();
            Driver.FindElementByXPath("//*[@id=\"userMenu\"]/div/ul/li[2]/a").Click();
        }

        private void SelectFirst(IEnumerable<SelectElement> listOfSelects)
        {
            foreach (var selectItem in listOfSelects)
            {
                selectItem.DeselectAll();
                selectItem.SelectByIndex(0);
            }
        }
    }
}