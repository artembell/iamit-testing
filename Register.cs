using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Xunit;

namespace IamIT.Tests.UI
{
    public class Register : RegisterBase
    {
        [Fact]
        protected void RegisterUsernameExisting()
        {
            UsernameInput.SendKeys("artembell");
            MailInput.SendKeys("artembell333@gmail.com");
            PasswordInput.SendKeys("passfortest123");
            DuplicatedPasswordInput.SendKeys("passfortest123");
            DisplayNameInput.SendKeys("namefortest");

            Driver.FindElementByTagName("button").Click();

            if (Driver.FindElementByXPath("//div[contains(normalize-space(), 'уже занято')]") != null)
            {
                throw new Exception("Такое имя пользователя уже занято");
            }
        }

        [Fact]
        protected void RegisterEmailExisting()
        {
            UsernameInput.SendKeys("artembell231");
            MailInput.SendKeys("artembell305@gmail.com");
            PasswordInput.SendKeys("passfortest123");
            DuplicatedPasswordInput.SendKeys("passfortest123");
            DisplayNameInput.SendKeys("namefortest");

            Driver.FindElementByTagName("button").Click();

            if (Driver.FindElementByXPath("//div[contains(normalize-space(), 'уже зарегистрирован')]") != null)
            {
                throw new Exception("Пользователь с такой электронной почтой уже зарегистрирован");
            }
        }

        [Fact]
        protected void RegisterInvalidPassword()
        {
            UsernameInput.SendKeys("artembell231");
            MailInput.SendKeys("artembell305123@gmail.com");
            PasswordInput.SendKeys("passfortest");
            DuplicatedPasswordInput.SendKeys("passfortest");
            DisplayNameInput.SendKeys("namefortest");

            Driver.FindElementByTagName("button").Click();

            if (Driver.FindElementByXPath("//span[contains(normalize-space(), 'Пароль должен содержать хотя бы 1 цифру')]") != null)
            {
                throw new Exception("Пароль должен содержать хотя бы 1 цифру");
            }
        }

        [Fact]
        protected void RegisterWithNotRepeatingPassword()
        {
            UsernameInput.SendKeys("artembell231");
            MailInput.SendKeys("artembell305123@gmail.com");
            PasswordInput.SendKeys("passfortest");
            DuplicatedPasswordInput.SendKeys("passfortest1");
            DisplayNameInput.SendKeys("namefortest");

            Driver.FindElementByTagName("button").Click();

            if (Driver.FindElementByXPath("//span[contains(normalize-space(), 'Пароли не совпадают')]") != null)
            {
                throw new Exception("Пароли не совпадают");
            }
        }

        [Fact]
        protected void RegisterWithEmptyField()
        {
            MailInput.SendKeys("artembell305123@gmail.com");
            PasswordInput.SendKeys("passfortest");
            DuplicatedPasswordInput.SendKeys("passfortest1");
            DisplayNameInput.SendKeys("namefortest");

            Driver.FindElementByTagName("button").Click();

            if (Driver.FindElementByXPath("//span[contains(normalize-space(), 'Это поле не может быть пустым')]") != null)
            {
                throw new Exception("Это поле не может быть пустым");
            }
        }
    }
}