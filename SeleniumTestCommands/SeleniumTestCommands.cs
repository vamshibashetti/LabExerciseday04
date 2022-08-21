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
          
        [DataTestMethod]
        [DataRow("Ch","https://demoqa.com/automation-practice-form")]

        public void ButtoncountMethod(string browser,string url)
        { 
          IWebDriver driver;

          if(browser == "FF")
          {
          driver = new FirefoxDriver(@"C:\Root Folder\WebDriver");
          
          } else
          { 
            driver = new ChromeDriver(@"C:\Root Folder\WebDriver");
          
          }
            driver.Navigate().GoToUrl(url);
    
            IList<IWebElement> btns = driver.FindElements(By.TagName("button"));
            int expcbtns = btns.Count;
            int actualbtns = 2;
            Assert.AreEqual(expcbtns,actualbtns,"btns is not matched");
            driver.Quit();
            

        }  

        
        [DataTestMethod]
        [DataRow("Ch","https://demoqa.com/automation-practice-form")]

        public void AttributevalueMethod(string browser,string url)
        { 
          IWebDriver driver;
        
          if(browser == "FF")
          {
          driver = new FirefoxDriver(@"C:\Root Folder\WebDriver");
          
          } else
          { 
            driver = new ChromeDriver(@"C:\Root Folder\WebDriver");
          
          }
            driver.Navigate().GoToUrl(url);
            
           IWebElement email= driver.FindElement(By.XPath("//input[@id='userEmail']"));
            string expectedemail = email.GetAttribute("placeholder");
            string actualemail = "name@example.com";
            Assert.AreEqual(expectedemail,actualemail,"email is not matched");
            Thread.Sleep(3000);
            driver.Quit();
        }
        [DataTestMethod]
        [DataRow("Ch","http://automationpractice.com","Webmaster")]

        public void DropdownMethod(string browser,string url,string subhead)
        { 
          IWebDriver driver;
          SelectElement dropDown;
        
          if(browser == "FF")
          {
          driver = new FirefoxDriver(@"C:\Root Folder\WebDriver");
          
          } else
          { 
            driver = new ChromeDriver(@"C:\Root Folder\WebDriver");
          
          }
             driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
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
            driver.Quit();
        }

          [DataTestMethod]
       
        [DataRow("Ch","https://www.wikipedia.org/")]

        public void wikipediaMethod(string browser,string url)
        { 
          IWebDriver driver;
        
          if(browser == "FF")
          {
          driver = new FirefoxDriver(@"C:\Root Folder\WebDriver");
          
          } else
          { 
            driver = new ChromeDriver(@"C:\Root Folder\WebDriver");
          
          }
            driver.Navigate().GoToUrl(url);
            
          IWebElement searchbox= driver.FindElement(By.XPath("//input[@id='searchInput']"));
          searchbox.SendKeys("Anna University"+Keys.Return);
          IWebElement othername =  driver.FindElement(By.XPath("//td[@class='infobox-data nickname']"));
          Assert.IsTrue(othername.Text.Contains("AU"));
          driver.Quit();

        }
        
    }

}