using System;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                driver.Navigate().GoToUrl("https://localhost:5001/");
                var welcomeTitleSelector = By.ClassName("display-4");
                var welcomeTitle = driver.FindElement(welcomeTitleSelector);
                Assert.Equal("Welcome", welcomeTitle.Text);
            }
        }
    }
}
