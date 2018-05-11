using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateKlucz()
        {
            var driver = new ChromeDriver();
            var url = "http://localhost:1888/Klucz/Create";

            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);
                var nameField = driver.FindElement(By.Id("Name"));
                nameField.Click();
                nameField.SendKeys("jou");

                var typeField = driver.FindElement(By.Id("Type"));
                typeField.Click();
                typeField.SendKeys("12");

                var button = driver.FindElement(By.XPath("/html/body/div/div[1]/div/form/div[3]/input"));
                button.Click();

                var indexText = driver.FindElement(By.XPath("/html/body/div/table")).Text;

                // Assert
                StringAssert.Contains(indexText, "jou");
            }   
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
        [TestMethod]
        public void TestCreateGornik()
        {
            var driver = new ChromeDriver();
            var url = "http://localhost:1888/Gornik/Create";

            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);
                var firstNameField = driver.FindElement(By.Id("FirstName"));
                firstNameField.Click();
                firstNameField.SendKeys("Jhony");

                var lastNameField = driver.FindElement(By.Id("LastName"));
                lastNameField.Click();
                lastNameField.SendKeys("Bravo");

                var button = driver.FindElement(By.XPath("/html/body/div/div[1]/div/form/div[4]/input"));
                button.Click();

                var indexText = driver.FindElement(By.XPath("/html/body/div/table")).Text;

                // Assert
                StringAssert.Contains(indexText, "Jhony");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
        [TestMethod]
        public void TestDeleteGornik()
        {
            var driver = new ChromeDriver();
            var url = "http://localhost:1888/Gornik";

            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);
                var goToCreate = driver.FindElement(By.XPath("/html/body/div/p/a"));
                goToCreate.Click();

                var firstNameField = driver.FindElement(By.Id("FirstName"));
                firstNameField.Click();
                firstNameField.SendKeys("Dot");

                var lastNameField = driver.FindElement(By.Id("LastName"));
                lastNameField.Click();
                lastNameField.SendKeys("Delete");

                var crButton = driver.FindElement(By.XPath("/html/body/div/div[1]/div/form/div[4]/input"));
                crButton.Click();

                var goToDelete = driver.FindElement(By.XPath("/html/body/div/table/tbody/tr[contains(.,'Dot')]/td[4]/a[3]"));
                goToDelete.Click();

                var deleteButton = driver.FindElement(By.XPath("/html/body/div/div/form/input[2]"));
                deleteButton.Click();

                var indexText = driver.FindElement(By.XPath("/html/body/div/table")).Text;

                bool contain = indexText.Contains("Dot");
                Assert.IsFalse(contain);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
        [TestMethod]
        public void TestEditKlucz()
        {
            var driver = new ChromeDriver();
            var url = "http://localhost:1888/Klucz/Index";

            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);

                var goToEdit = driver.FindElement(By.XPath("/html/body/div/table/tbody/tr[3]/td[3]/a[1]"));
                goToEdit.Click();

                var typeField = driver.FindElement(By.Id("Name"));
                typeField.Clear();
                typeField.Click();
                typeField.SendKeys("EDIT");

                var button = driver.FindElement(By.XPath("/html/body/div/div[1]/div/form/div[3]/input"));
                button.Click();

                var indexText = driver.FindElement(By.XPath("/html/body/div/table")).Text;

                // Assert
                StringAssert.Contains(indexText, "EDIT");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
        [TestMethod]
        public void TestDeleteKlucz()
        {
            var driver = new ChromeDriver();
            var url = "http://localhost:1888/Klucz/Index";

            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);

                var goToDelete = driver.FindElement(By.XPath("/html/body/div/table/tbody/tr[contains(.,'EDIT')]/td[3]/a[3]"));
                goToDelete.Click();

                var confDelete = driver.FindElement(By.XPath("/html/body/div/div/form/input[2]"));
                confDelete.Click();

                var indexText = driver.FindElement(By.XPath("/html/body/div/table")).Text;

                bool contain = indexText.Contains("EDIT");
                Assert.IsFalse(contain);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
