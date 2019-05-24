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
            // Puede que sea por ser una URL externa
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.BinaryLocation = "/opt/google/chrome/chrome";
            ChromeDriverService service = ChromeDriverService.CreateDefaultService("/opt/selenium", "chromedriver");
            using (var driver = new ChromeDriver(service, options))
            {
                driver.Navigate().GoToUrl("http://webapp/");
                var welcomeTitleSelector = By.ClassName("display-4");
                var welcomeTitle = driver.FindElement(welcomeTitleSelector);
                Assert.Equal("Welcome", welcomeTitle.Text);
            }
        }
    }
}
