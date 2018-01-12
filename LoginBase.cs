using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace IamIT.Tests.UI
{
    public class LoginBase : Base
    {
        public IWebElement UserInput, PasswordInput;
        public LoginBase()
        {
            Driver.FindElementById("signUpBtn").Click();
            UserInput = Driver.FindElementById("usernameInput");
            PasswordInput = Driver.FindElementById("passwordInput");
        }
    }
}
