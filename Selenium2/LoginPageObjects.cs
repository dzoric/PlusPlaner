using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium2
{
    class LoginPageObjects
    {
        public LoginPageObjects()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        [FindsBy(How = How.XPath,Using = ".//h5[contains(text(),'Prijava')]")]
        public IWebElement LoginForm { get; set; }

        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Name, Using = "action")]
        public IWebElement btnLogin { get; set; }

        [FindsBy(How = How.XPath, Using = ".//ul/li[contains(text(),'Korisničko ime je obvezno.')]")]
        public IWebElement userNameRequired { get; set; }

        [FindsBy(How = How.XPath, Using = ".//ul/li[contains(text(),'Lozinka je obvezna.')]")]
        public IWebElement passwordRequired { get; set; }

        [FindsBy(How = How.XPath, Using = ".//ul/li[contains(text(),'Neispravno korisničko ime ili lozinka.')]")]
        public IWebElement invalidUserPassword { get; set; }

        public void CheckIfLoginPage()
        {
            bool LoginFormDisplayed = LoginForm.Displayed;
            if(LoginFormDisplayed==true)
            {
                Console.WriteLine("Login page is initialized");
            }
            else
            {
                Console.WriteLine("Login page is NOT initialized");
            }
        }

        public void UserNameTextboxCheck()
        {
            bool UserNameTxtDisplayed = txtUserName.Displayed;
            if (UserNameTxtDisplayed == true)
            {
                Console.WriteLine("Username field is displayed");
                bool UserNameTxtEnabled = txtUserName.Enabled;
                if (UserNameTxtEnabled == true)
                {
                    Console.WriteLine("Username field is enabled");
                    string UserNameTxtValue = txtUserName.GetAttribute("value");
                    if (string.IsNullOrEmpty(UserNameTxtValue))
                    {
                        Console.WriteLine("Username field is empty");
                    }
                    else
                    {
                        Console.WriteLine("Username field is NOT empty");
                    }
                }
                else
                {
                    Console.WriteLine("Username field is NOT enabled");
                }
            }
            else
            {
                Console.WriteLine("Username field is NOT displayed");
            }
        }

        public void PasswordTextboxCheck()
        {
            bool PasswordTxtDisplayed = txtPassword.Displayed;
            if (PasswordTxtDisplayed == true)
            {
                Console.WriteLine("Password field is displayed");
                bool PasswordTxtEnabled = txtPassword.Enabled;
                if (PasswordTxtEnabled == true)
                {
                    Console.WriteLine("Password field is enabled");
                    string PasswordTxtValue = txtPassword.GetAttribute("value");
                    if (string.IsNullOrEmpty(PasswordTxtValue))
                    {
                        Console.WriteLine("Password field is empty");
                    }
                    else
                    {
                        Console.WriteLine("Password field is not empty");
                    }
                }
                else
                {
                    Console.WriteLine("Password field is not enabled");
                }
            }
            else
            {
                Console.WriteLine("Password field is not displayed");
            }
        }

        public void LoginButtonCheck()
        {
            bool LoginButtonDisplayed = btnLogin.Displayed;
            if (LoginButtonDisplayed == true)
            {
                Console.WriteLine("Login button is displayed");
                bool LoginButtonEnabled = btnLogin.Enabled;
                if (LoginButtonEnabled == true)
                {
                    Console.WriteLine("Login button is enabled");
                }
                else
                {
                    Console.WriteLine("Login button is not enabled");
                }
            }
            else
            {
                Console.WriteLine("Login button is not displayed");
            }
        }

        public void EmptyFieldsMessageCheck()
        {
            btnLogin.Click();
            bool UserRequired = userNameRequired.Displayed;
            bool PasswordRequired = passwordRequired.Displayed;
            if (UserRequired == true && PasswordRequired == true)
            {
                Console.WriteLine("Username and password required is displayed when textboxes are empty");
            }
            else
            {
                Console.WriteLine("Username and password required is not displayed when textboxes are empty");
            }
        }

        public void TryLogin()
        {
            txtUserName.SendKeys("sdasd");
            btnLogin.Click();
            Thread.Sleep(300);
            bool PasswordRequired = passwordRequired.Displayed;
            if (PasswordRequired == true)
            {
                Console.WriteLine("Password required displayed when username contains value and button clicked");
                txtUserName.Clear();
                txtPassword.SendKeys("Asdfg123!");
                btnLogin.Click();
                Thread.Sleep(300);
                bool UserRequired = userNameRequired.Displayed;
                if (UserRequired == true)
                {
                    Console.WriteLine("Username required displayed when password contains value and button clicked");
                    txtUserName.SendKeys("dsaksodkap");
                    txtPassword.SendKeys("Asdfg123!");
                    btnLogin.Click();
                    Thread.Sleep(300);
                    bool InvalidUserAndPassword = invalidUserPassword.Displayed;
                    if(InvalidUserAndPassword == true)
                    {
                        Console.WriteLine("Invalid username or password displayed when incorrect values are entered and button clicked");
                        txtUserName.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password IS NOT displayed when incorrect values are entered and button clicked");
                        txtUserName.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("User required NOT displayed when password contains value and button clicked");
                    txtUserName.SendKeys("dsaksodkap");
                    txtPassword.SendKeys("Asdfg123!");
                    btnLogin.Click();
                    Thread.Sleep(300);
                    bool InvalidUserAndPassword = invalidUserPassword.Displayed;
                    if (InvalidUserAndPassword == true)
                    {
                        Console.WriteLine("Invalid username or password displayed when incorrect values are entered and button clicked");
                        txtUserName.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password IS NOT displayed when incorrect values are entered and button clicked");
                        txtUserName.Clear();
                    }
                }
            }
            else
            {
                Console.WriteLine("Password required NOT displayed when username contains value and button clicked");
                txtUserName.Clear();
                txtPassword.SendKeys("Asdfg123!");
                btnLogin.Click();
                Thread.Sleep(300);
                bool UserRequired = userNameRequired.Displayed;
                if (UserRequired == true)
                {
                    Console.WriteLine("Username required displayed when password contains value and button clicked");
                    txtUserName.SendKeys("dsaksodkap");
                    txtPassword.SendKeys("Asdfg123!");
                    btnLogin.Click();
                    Thread.Sleep(300);
                    bool InvalidUserAndPassword = invalidUserPassword.Displayed;
                    if (InvalidUserAndPassword == true)
                    {
                        Console.WriteLine("Invalid username or password displayed when incorrect values are entered and button clicked");
                        txtUserName.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password IS NOT displayed when incorrect values are entered and button clicked");
                        txtUserName.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("User required NOT displayed when password contains value and button clicked");
                    txtUserName.SendKeys("dsaksodkap");
                    txtPassword.SendKeys("Asdfg123!");
                    btnLogin.Click();
                    Thread.Sleep(300);
                    bool InvalidUserAndPassword = invalidUserPassword.Displayed;
                    if (InvalidUserAndPassword == true)
                    {
                        Console.WriteLine("Invalid username or password displayed when incorrect values are entered and button clicked");
                        txtUserName.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password IS NOT displayed when incorrect values are entered and button clicked");
                        txtUserName.Clear();
                    }
                }
            }
        }

        public void Login(string userName, string password)
        {
            txtUserName.SendKeys(userName);
            txtPassword.SendKeys(password);
            btnLogin.Click();
        }
    }
}
