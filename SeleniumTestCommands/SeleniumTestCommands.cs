using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace LabExercise
{
    [TestClass]
   
    public class SeleniumTestCommands
    {
        IWebDriver driver;

        [TestInitialize]

        public void Initialize(){
        driver = new ChromeDriver(@"C:\Root Folder\WebDriver");
        driver.Manage().Window.Maximize(); 
        driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);   
        }

        [DataTestMethod]
        [DataRow("https://demoqa.com/automation-practice-form")]

        public void ButtoncountMethod(string url)
        { 
          
            driver.Navigate().GoToUrl(url);
            string exptitle =  driver.Title;
            string actualtitle = "ToolsQA";
             Assert.AreEqual(exptitle,actualtitle,"title is not matched");
            IList<IWebElement> btns = driver.FindElements(By.TagName("button"));
            int expcbtns = btns.Count;
            int actualbtns = 2;
            Assert.AreEqual(expcbtns,actualbtns,"btns is not matched");
        
        }  

        
        [DataTestMethod]
        [DataRow("https://demoqa.com/automation-practice-form")]

        public void AttributevalueMethod(string url)
        { 
       
          driver.Navigate().GoToUrl(url);
          IWebElement email= driver.FindElement(By.XPath("//input[@id='userEmail']"));
          string expectedemail = email.GetAttribute("placeholder");
          string actualemail = "name@example.com";
          Assert.AreEqual(expectedemail,actualemail,"email is not matched");
          Thread.Sleep(3000);

        }
        [DataTestMethod]
        [DataRow("http://automationpractice.com","Webmaster")]

        public void DropdownMethod(string url,string subhead)
        { 
          
            SelectElement dropDown;
        
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(2000);
            IWebElement Contact= driver.FindElement(By.PartialLinkText("Contact"));
            Contact.Click();
            Thread.Sleep(2000);
            IWebElement subject =driver.FindElement(By.XPath("//select[@id='id_contact']"));
             Thread.Sleep(2000);
            ((IJavaScriptExecutor)driver) .ExecuteScript("arguments[0].scrollIntoView(true);", subject);
            dropDown = new SelectElement(subject);
            dropDown.SelectByText(subhead);
            System.Diagnostics.Debug.WriteLine("selected dropdown");
            Thread.Sleep(2000); 
        
        }

        [DataTestMethod]
        [DataRow("https://www.wikipedia.org/")]

        public void wikipediaMethod(string url)
        { 
          driver.Navigate().GoToUrl(url);
          IWebElement searchbox= driver.FindElement(By.XPath("//input[@id='searchInput']"));
          searchbox.SendKeys("Anna University"+Keys.Return);
          IWebElement othername =  driver.FindElement(By.XPath("//td[@class='infobox-data nickname']"));
          Assert.IsTrue(othername.Text.Contains("AU"));
          
        }

        [TestCleanup]

        public void cleanup()
        {
          driver.Quit();
        }
        
    }

}