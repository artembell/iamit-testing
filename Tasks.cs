using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace IamIT.Tests.UI
{
    public class Tasks : LoginedBase
    {
        private const String CourseId = "3de554d8-4a3a-4a25-923b-0653bf3ec2fb";

        [Fact]
        public void TestTextTask()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}course/{CourseId}/ru/lesson/lesson-1/part/b1/t1/");
            var inputTextTask = Driver.FindElementById("textTaskInput");
            inputTextTask.Clear();
            inputTextTask.SendKeys("42");
            Driver.FindElementById("validateBtn").Click();
            CheckSuccessAlert();
        }

        [Fact]
        public void TestSelectTaskSingleMode() => SelectTaskTest(true);

        [Fact]
        public void TestSelectTaskMultipleMode() => SelectTaskTest(false);

        [Fact]
        public void TestHtmlTask()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}course/{CourseId}/ru/lesson/lesson-4/part/b1/t1/");
            Driver.SwitchTo().Frame(Driver.FindElementById("iframe"));

            var a = Driver.FindElementById("a");
            var b = Driver.FindElementById("b");
            var input = Driver.FindElementById("input");
            input.Clear();
            input.SendKeys((int.Parse(a.Text) + int.Parse(b.Text)).ToString());

            Driver.SwitchTo().DefaultContent();
            Driver.FindElementById("validateBtn").Click();
            CheckSuccessAlert();
        }

        [Fact]
        public void TestFormTask()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}course/{CourseId}/ru/lesson/lesson-3/part/b1/t1/");
            var inputVariable = Driver.FindElementByName("variable");
            var operatorSelect = Driver.FindElementByName("operator");

            inputVariable.Clear();
            inputVariable.SendKeys("b");
            var selectElement = new SelectElement(operatorSelect);
            selectElement.SelectByText("*");
            Driver.FindElementById("validateBtn").Click();
            CheckSuccessAlert();
        }

        [Fact]
        public void TestDragAndDropTask()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}course/{CourseId}/ru/lesson/lesson-3/part/b1/t2/");
            SelectNewTaskVersion();
            Move(Driver.FindElementsByCssSelector(".order-item.markdown")[3], Driver.FindElementsByCssSelector(".order-item.markdown")[0]);
            Move(Driver.FindElementsByCssSelector(".order-item.markdown")[3], Driver.FindElementsByCssSelector(".order-item.markdown")[2]);
            Move(Driver.FindElementsByCssSelector(".order-item.markdown")[4], Driver.FindElementsByCssSelector(".order-item.markdown")[3]);
            Driver.FindElementById("validateBtn").Click();
            CheckSuccessAlert();
        }



        [Fact]
        public void TestProgramTask()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}course/{CourseId}/ru/lesson/lesson-3/part/b1/t3/");
            SelectNewTaskVersion();
            Driver.FindElementsById("Primary")[1].Click();
            Driver.FindElementByCssSelector(".workspace ul[role=menu]").FindElements(By.CssSelector("li"))[2].Click();

            Driver.FindElementById("aceEditor-1");
            var textInput = Driver.FindElementByCssSelector("textarea[class=ace_text-input]");
            textInput.Clear();
            textInput.SendKeys(GetCodeForProgramTask());

            Driver.FindElementById("validateBtn").Click();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until((d) =>
            {
                var element = d.FindElement(By.XPath("//*[@id=\"content\"]/div/div[1]/div/div/div"));
                return !element.GetAttribute("class").Contains("alert-info") ? element : null;
            });

            CheckSuccessAlert();
        }

        #region help methods
        private void Move(IWebElement element, IWebElement place) => new Actions(Driver).ClickAndHold(element)
            .MoveToElement(place)
            .Release()
            .Build()
            .Perform();

        private string GetCodeForProgramTask()
        {
            return
                "using System;\r\nusing System.Globalization;\r\nusing System.IO;\r\nusing System.Linq;\r\n\r\nnamespace Solution\r\n{\r\nclass Program\r\n{\r\nstatic void Main(string[] args)\r\n{\r\nlong sum = 0;\r\nstring line;\r\n\r\nwhile ((line = Console.ReadLine()) != null)\r\n{\r\nsum += line.Split(new[] { \' \' }, StringSplitOptions.RemoveEmptyEntries).Sum(x => long.Parse(x));\r\n\r\n\r\nConsole.WriteLine(sum);\r\n\r\n\r\n";
        }

        private void SelectTaskTest(bool singleMode)
        {
            var url = $"{BaseUrl}course/{CourseId}/ru/lesson/lesson-1/part/b1/" + (singleMode ? "t2" : "t3");
            Driver.Navigate().GoToUrl(url);
            var taskRows = Driver.FindElementsById("selectTaskInput");
            taskRows[1].Click();
            Driver.FindElementById("validateBtn").Click();
            CheckSuccessAlert();
        }
        #endregion
    }
}