using System;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Process = KTPM.Process;


namespace KTPMTest
{
    [TestFixture]
    public class Tests
    {
        public static string[] GetDataSearchSource()
        {
            string path = @"/home/minh-nguyen/RiderProjects/KTPM/KTPMTest/dataSearchTest.csv";
            if (File.Exists(path))
            {
                string[] dataSource = File.ReadAllLines(path).Skip(1).ToArray();
                return dataSource;
            }

            return new string[] { };
        }
        
        public static string[] GetDataLoginSource()
        {
            string path = @"/home/minh-nguyen/RiderProjects/KTPM/KTPMTest/dataLoginTest.csv";
            if (File.Exists(path))
            {
                string[] dataSource = File.ReadAllLines(path).Skip(1).ToArray();
                return dataSource;
            }

            return new string[] { };
        }
        
        [Test, TestCaseSource("GetDataSearchSource")]
        public void TestSearch(string dataSearchTest)
        {
                string[] Data = dataSearchTest.Split(',');
                Process p = new Process();
                p.Text = Data[0];
                bool actual = p.Search(Data[1]);
                Assert.AreEqual(Data[2] == "1" ? true : false, actual);
        }

        [Test, TestCaseSource("GetDataLoginSource")]
        public void TestLogin(string dataLoginTest)
        {
            Process p = new Process();
            string[] data = dataLoginTest.Split(',');
            // user must be register before
            bool hasRegister = p.Register(data[0], data[1]);
            bool actual = hasRegister ? p.Login(data[0], data[1]) : false;
            Assert.AreEqual(data[2] == "1" ? true : false, actual);
        }

        [Test]
        public void testSuccessLoginAndLogout()
        {
            string geckoDriver = "/home/minh-nguyen/PycharmProjects/scraping/geckodriver";
            string url = "https://practicetestautomation.com/practice-test-login/";
            IWebDriver driver = new ChromeDriver(); 
            
            driver.Navigate().GoToUrl(url);
        
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        
            string username = driver.FindElement(By.CssSelector("#login > ul:nth-child(2) > li:nth-child(2) > b:nth-child(2)"))
                .Text.Trim();
            string password = driver.FindElement(By.CssSelector("#login > ul:nth-child(2) > li:nth-child(2) > b:nth-child(4)"))
                .Text.Trim();
            IWebElement title = driver.FindElement(By.CssSelector("#login > h5:nth-child(6)"));
            Actions action = new Actions(driver);
            action.MoveToElement(title);
            
            
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.Id("submit")).Click();
            
            IWebElement loginButton = driver.FindElement(By.CssSelector(".post-title"));
            Assert.IsTrue(loginButton.Displayed);
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.CssSelector(".wp-block-button__link")).Click();
        } 
        [Test]
        public void testFailUsernameLogin()
        {
            string geckoDriver = "/home/minh-nguyen/PycharmProjects/scraping/geckodriver";
            string url = "https://practicetestautomation.com/practice-test-login/";
            IWebDriver driver = new ChromeDriver(); 
            
            driver.Navigate().GoToUrl(url);
        
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        
            string username = driver.FindElement(By.CssSelector("#login > ul:nth-child(2) > li:nth-child(2) > b:nth-child(2)"))
                .Text.Trim();
            string password = driver.FindElement(By.CssSelector("#login > ul:nth-child(2) > li:nth-child(2) > b:nth-child(4)"))
                .Text.Trim();
            IWebElement title = driver.FindElement(By.CssSelector("#login > h5:nth-child(6)"));
            Actions action = new Actions(driver);
            action.MoveToElement(title);
            
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).SendKeys("empty");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.Id("submit")).Click();
            
            IWebElement loginButton = driver.FindElement(By.CssSelector(".post-title"));
            Assert.IsTrue(loginButton.Displayed);
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.CssSelector(".wp-block-button__link")).Click();
        } 
        [Test]
        public void testFailPasswordLogin()
        {
            string geckoDriver = "/home/minh-nguyen/PycharmProjects/scraping/geckodriver";
            string url = "https://practicetestautomation.com/practice-test-login/";
            IWebDriver driver = new ChromeDriver(); 
            
            driver.Navigate().GoToUrl(url);
        
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        
            string username = driver.FindElement(By.CssSelector("#login > ul:nth-child(2) > li:nth-child(2) > b:nth-child(2)"))
                .Text.Trim();
            string password = driver.FindElement(By.CssSelector("#login > ul:nth-child(2) > li:nth-child(2) > b:nth-child(4)"))
                .Text.Trim();
            IWebElement title = driver.FindElement(By.CssSelector("#login > h5:nth-child(6)"));
            Actions action = new Actions(driver);
            action.MoveToElement(title);
            
                
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).SendKeys("empty");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.FindElement(By.Id("submit")).Click();
            
            IWebElement loginButton = driver.FindElement(By.CssSelector(".post-title"));
            Assert.IsTrue(loginButton.Displayed);
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.CssSelector(".wp-block-button__link")).Click();
        }

        [Test]
        public void testTourPayment()
        {
            string url = "https://www.phptravels.net/";
        
            IWebDriver driver = new ChromeDriver();
        
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.FullScreen();
        
            driver.FindElement(By.XPath("//*[@id=\"tab\"]/li[2]/button")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cars-search\"]/div/div[1]/div[1]/div[2]/span/span[1]/span")).Click();
            driver.FindElement(By.XPath("//*[@id=\"fadein\"]/span/span/span[1]/input")).SendKeys("Berlin");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//*[@id=\"select2--results\"]/li[3]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"cars-search\"]/div/div[4]/button")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//*[@id=\"fadein\"]/div[5]/div/div/div[1]/div/div[2]/form/button")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("/html/body/div[3]/form/section/div/div/div[1]/div[1]/div[2]/div/div/div[1]/div/input")).SendKeys("Minh");
            driver.FindElement(By.XPath("/html/body/div[3]/form/section/div/div/div[1]/div[1]/div[2]/div/div/div[2]/div/input")).SendKeys("Nguyen");
            driver.FindElement(By.XPath("/html/body/div[3]/form/section/div/div/div[1]/div[1]/div[2]/div/div/div[3]/div/input")).SendKeys("2051052080minh@ou.edu.vn");
            driver.FindElement(By.XPath("/html/body/div[3]/form/section/div/div/div[1]/div[1]/div[2]/div/div/div[4]/div/input")).SendKeys("0396796034");
            driver.FindElement(By.XPath("/html/body/div[3]/form/section/div/div/div[1]/div[1]/div[2]/div/div/div[5]/div/input")).SendKeys("Nha be, HCMC");
            driver.FindElement(By.XPath("/html/body/div[3]/form/section/div/div/div[1]/div[1]/div[2]/div/div/div[6]/div/div/button")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.XPath("/html/body/div[3]/form/section/div/div/div[1]/div[1]/div[2]/div/div/div[6]/div/div/div/div[1]/input")).SendKeys("Viet Nam");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.XPath("/html/body/div[3]/form/section/div/div/div[1]/div[1]/div[2]/div/div/div[6]/div/div/div/div[2]/ul/li")).Click();
            driver.FindElement(By.XPath("/html/body/div[3]/form/section/div/div/div[1]/div[1]/div[2]/div/div/div[7]/div/div/button")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.XPath("/html/body/div[3]/form/section/div/div/div[1]/div[1]/div[2]/div/div/div[7]/div/div/div/div[1]/input")).SendKeys("Viet Nam");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.FindElement(By.XPath("/html/body/div[3]/form/section/div/div/div[1]/div[1]/div[2]/div/div/div[7]/div/div/div/div[2]/ul/li")).Click();
            driver.FindElement(By.XPath("/html/body/div[3]/form/section/div/div/div[1]/div[2]/div[2]/div[1]/div[2]/div/div[2]/div/input")).SendKeys("Minh");
            driver.FindElement(By.XPath("/html/body/div[3]/form/section/div/div/div[1]/div[2]/div[2]/div[1]/div[2]/div/div[3]/div/input")).SendKeys("Nguyen");
            IWebElement checkbox = driver.FindElement(By.CssSelector("#agreechb"));
            IWebElement title2ScrollTo =  driver.FindElement(By.XPath("//*[@id=\"fadein\"]/div[3]/form/section/div/div/div[2]/div/div[1]"));
        
            new Actions(driver)
                .ScrollToElement(title2ScrollTo)
                .Perform();
            checkbox.Click();
            driver.FindElement(By.XPath("//*[@id=\"booking\"]")).Click();
            
        
            IWebElement button =  driver.FindElement(By.XPath(".btn-lg"));
            button.Click();
        
        }
        
        [Test]
        public void testFlightPayment()
        {
            string url = "https://www.phptravels.net/";
        
            IWebDriver driver = new ChromeDriver();
        
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.FullScreen();
        }
    }
}