using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IamIT.Tests.UI
{
    public class Login : LoginBase
    {
        [Fact]
        protected void LoginIncorrectUsernameOrPassword()
        {
            UserInput.SendKeys("artembell");
            PasswordInput.SendKeys("123asdfa");

            Driver.FindElementById("loginBtn").Click();

            if (Driver.FindElementByXPath("//div[contains(normalize-space(), 'Неверное имя пользователя или пароль')]") != null)
            {
                throw new Exception("Неверное имя пользователя или пароль");
            }
        }

        [Fact]
        protected void LoginWithEmptyUsernameField()
        {
            PasswordInput.SendKeys("123asdfa");

            Driver.FindElementById("loginBtn").Click();

            if (Driver.FindElementByXPath("//span[contains(normalize-space(), 'Это поле не может быть пустым')]") != null)
            {
                throw new Exception("Поле ввода имени пользователя не может быть пустым");
            }
        }

        [Fact]
        protected void LoginWithEmptyPasswordField()
        {
            UserInput.SendKeys("artembell");

            Driver.FindElementById("loginBtn").Click();

            if (Driver.FindElementByXPath("//span[contains(normalize-space(), 'Это поле не может быть пустым')]") != null)
            {
                throw new Exception("Поле ввода пароля не может быть пустым");
            }
        }

        [Fact]
        protected void LoginValid()
        {
            UserInput.SendKeys("artembell");
            PasswordInput.SendKeys("123qweqwe");

            if (Driver.FindElementByClassName("myCoursesTitle") == null)
            {
                throw new Exception("По непонятным причинам не удалось войти");
            }
        }
    }
}
