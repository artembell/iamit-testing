using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace IamIT.Tests.UI
{
    public class RegisterBase : Base
    {
        public IWebElement Link, UsernameInput, MailInput, PasswordInput, DuplicatedPasswordInput, DisplayNameInput;
        public RegisterBase()
        {
            Link = Driver.FindElementByLinkText("Регистрация");
            Link.Click();

            UsernameInput = Driver.FindElementsByTagName("input")[0];//FindElementByXPath("//input[@placeholder=\"Username\"]");
            MailInput = Driver.FindElementsByTagName("input")[1];//Driver.FindElementByXPath("//input[@placeholder=\"Email\"]");
            PasswordInput = Driver.FindElementsByTagName("input")[2];//Driver.FindElementByXPath("//input[@placeholder=\"Password\"]");
            DuplicatedPasswordInput = Driver.FindElementsByTagName("input")[3];//Driver.FindElementByXPath("//input[@placeholder=\"Password again\"]");
            DisplayNameInput = Driver.FindElementsByTagName("input")[4];//Driver.FindElementByXPath("//input[@placeholder=\"DisplayName\"]");
        }
    }
}
