using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium2
{
    class Program
    {

        static void Main(string[] args)
        {
        }

        [SetUp]
        public void Initialize()
        {
            Driver.driver = new ChromeDriver();
            Driver.driver.Navigate().GoToUrl("http://www.plusplaner.com");
        }

        [Test]
        public void Test()
        {
            LoginPageObjects loginPage = new LoginPageObjects();
            loginPage.CheckIfLoginPage();
            loginPage.UserNameTextboxCheck();
            loginPage.PasswordTextboxCheck();
            loginPage.LoginButtonCheck();
            loginPage.EmptyFieldsMessageCheck();
            loginPage.TryLogin();
            loginPage.Login("user21", "Pass21");

            string urlSchedule = "http://www.plusplaner.com/raspored";
            if(Driver.driver.Url == urlSchedule)
            {
                Console.WriteLine("Schedule page successfully initialized");
            }
            else
            {
                Console.WriteLine("Schedule page NOT initialized");
            }

        }

        [TearDown]
        public void Close()
        {
            Driver.driver.Close();
        }
    }
}
