namespace IamIT.Tests.UI
{
    public class LoginedBase : Base
    {
        public LoginedBase()
        {
            Driver.FindElementById("signUpBtn").Click();
            var inputLogin = Driver.FindElementById("usernameInput");
            var passwordField = Driver.FindElementById("passwordInput");
            var loginBtn = Driver.FindElementById("loginBtn");
            inputLogin.SendKeys("userForTests");
            passwordField.SendKeys("testPassword1");
            loginBtn.Click();
            Driver.FindElementById("userMenu");
        }
    }
}