using NUnit.Framework;
using OpenQA.Selenium;
using Project_Mars.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Mars.Pages
{
    //public class EducationPage
    //{


    //    public void CreateEducationRecord(IWebDriver driver, string collegeUniversityName, string countryOfCollegeUniversity, string title, string degree, string yearOfGraduation)
    //    {
    //        IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
    //        addNewButton.Click();

    //        IWebElement collegeUniversityNameTextbox = driver.FindElement(By.XPath("//input[@placeholder='College/University Name']"));
    //        collegeUniversityNameTextbox.Click();
    //        collegeUniversityNameTextbox.SendKeys(collegeUniversityName);

    //        IWebElement countryOfCollegeUniversityDropdownbox = driver.FindElement(By.XPath("//select[@name='country']"));
    //        countryOfCollegeUniversityDropdownbox.SendKeys(countryOfCollegeUniversity);

    //        //IWebElement indiaOption = driver.FindElement(By.XPath("//option[@value='India']"));
    //        //indiaOption.Click();

    //        IWebElement titleDropdownbox = driver.FindElement(By.XPath("//select[@name='title']"));
    //        titleDropdownbox.SendKeys(title);

    //        //IWebElement phdOption = driver.FindElement(By.XPath("//option[@value='PHD']"));
    //        //phdOption.Click();

    //        IWebElement degreeTextbox = driver.FindElement(By.XPath("//input[@placeholder=\"Degree\"]"));
    //        degreeTextbox.Click();
    //        degreeTextbox.SendKeys(degree);

    //        IWebElement yearOfGraduationDropdownbox = driver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));
    //        yearOfGraduationDropdownbox.SendKeys(yearOfGraduation);

    //        //IWebElement yearOption = driver.FindElement(By.XPath("//option[@value='2007']"));
    //        //yearOption.Click();


    //            IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
    //            addButton.Click();
    //        Thread.Sleep(5000);

    //    }

    //    public void CheckTitleDropdownButton(IWebDriver driver)
    //    {
    //        IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
    //        addNewButton.Click();

    //        IWebElement collegeUniversityNameTextbox = driver.FindElement(By.XPath("//input[@placeholder='College/University Name']"));
    //        collegeUniversityNameTextbox.Click();
    //        collegeUniversityNameTextbox.SendKeys("Mumbai University");

    //        IWebElement countryOfCollegeUniversityDropdownbox = driver.FindElement(By.XPath("//select[@name='country']"));
    //        countryOfCollegeUniversityDropdownbox.SendKeys("Australia");

    //        //IWebElement indiaOption = driver.FindElement(By.XPath("//option[@value='India']"));
    //        //indiaOption.Click();

    //        IWebElement titleDropdownbox = driver.FindElement(By.XPath("//select[@name='title']"));
    //        titleDropdownbox.SendKeys("PHD");

    //        //IWebElement phdOption = driver.FindElement(By.XPath("//option[@value='PHD']"));
    //        //phdOption.Click();

    //        IWebElement degreeTextbox = driver.FindElement(By.XPath("//input[@placeholder=\"Degree\"]"));
    //        degreeTextbox.Click();
    //        degreeTextbox.SendKeys("Arts");

    //        IWebElement yearOfGraduationDropdownbox = driver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));
    //        yearOfGraduationDropdownbox.SendKeys("2007");

    //        //IWebElement yearOption = driver.FindElement(By.XPath("//option[@value='2007']"));
    //        //yearOption.Click();
    //        IWebElement titleeDropdownbox = driver.FindElement(By.XPath("//select[@name='title']"));
    //        titleeDropdownbox.SendKeys("Title");


    //        IWebElement addButton = driver.FindElement(By.XPath("//input[@value='Add']"));
    //        addButton.Click();
    //        Thread.Sleep(3000);

    //    }

    //    public string BlankField(IWebDriver driver)
    //    {
    //        IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
    //        return popupAlert.Text;
    //    }





    //    public void EditEducationRecord(IWebDriver driver, string newcollegeUniversityName, string newcountryOfCollegeUniversity, string newtitle, string newdegree, string newyearOfGraduation)
    //    {
    //        IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[1]/i"));
    //        editButton.Click();

    //        IWebElement collegeUniversityNameTextbox = driver.FindElement(By.XPath("//input[@placeholder='College/University Name']"));
    //        collegeUniversityNameTextbox.Clear();
    //        collegeUniversityNameTextbox.SendKeys(newcollegeUniversityName);

    //        IWebElement countryOfCollegeUniversityDropdownbox = driver.FindElement(By.XPath("//select[@name='country']"));
    //        countryOfCollegeUniversityDropdownbox.SendKeys(newcountryOfCollegeUniversity);

    //        //IWebElement indiaOption = driver.FindElement(By.XPath("//option[@value='India']"));
    //        //indiaOption.Click();

    //        IWebElement titleDropdownbox = driver.FindElement(By.XPath("//select[@name='title']"));
    //        titleDropdownbox.SendKeys(newtitle);

    //        //IWebElement phdOption = driver.FindElement(By.XPath("//option[@value='PHD']"));
    //        //phdOption.Click();

    //        IWebElement degreeTextbox = driver.FindElement(By.XPath("//input[@placeholder=\"Degree\"]"));
    //        degreeTextbox.Clear();
    //        degreeTextbox.SendKeys(newdegree);

    //        IWebElement yearOfGraduationDropdownbox = driver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));
    //        yearOfGraduationDropdownbox.SendKeys(newyearOfGraduation);
    //        //IWebElement yearOfGraduationDropdownbox = driver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));
    //        //yearOfGraduationDropdownbox.Click();

    //        //IWebElement yearOption = driver.FindElement(By.XPath("//option[@value='2007']"));
    //        //yearOption.Click();

    //        IWebElement updateButton = driver.FindElement(By.XPath("//input[@value='Update']"));
    //        updateButton.Click();
    //        Thread.Sleep(5000);


    //    }

    //    public void CancelEditOperation(IWebDriver driver, string newtitle)
    //    {
    //        Thread.Sleep(3000);
    //        IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[1]/i"));
    //        editButton.Click();
    //        Thread.Sleep(3000);
    //        IWebElement titleDropdownbox = driver.FindElement(By.XPath("//select[@name='title']"));
    //        titleDropdownbox.Click();
    //        titleDropdownbox.SendKeys(newtitle);
    //        Thread.Sleep(2000);
    //        IWebElement cancelButton = driver.FindElement(By.XPath("//input[@value='Cancel']"));
    //        cancelButton.Click();
    //        Thread.Sleep(2000);
    //        IWebElement eeditButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[1]/i"));
    //        eeditButton.Click();

    //        IWebElement updateButton = driver.FindElement(By.XPath("//input[@value='Update']"));
    //        updateButton.Click();
    //        Thread.Sleep(2000);

    //    }

    //    public void DeleteEducationRecord(IWebDriver driver)
    //    {
    //        Thread.Sleep(5000);
    //        IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i"));
    //        deleteButton.Click();

    //    }

    //}
    public class EducationPage
    {
        private IWebDriver driver;

        private IWebElement AddNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));

        private IWebElement CollegeUniversityNameTextbox => driver.FindElement(By.XPath("//input[@placeholder='College/University Name']"));

        private IWebElement CountryOfCollegeUniversityDropdownbox => driver.FindElement(By.XPath("//select[@name='country']"));

        private IWebElement TitleDropdownbox => driver.FindElement(By.XPath("//select[@name='title']"));

        private IWebElement DegreeTextbox => driver.FindElement(By.XPath("//input[@placeholder=\"Degree\"]"));

        private IWebElement YearOfGraduationDropdownbox => driver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));

        private IWebElement AddButton => driver.FindElement(By.XPath("//input[@value='Add']"));

        private IWebElement EditButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[1]/i"));

        private IWebElement UpdateButton => driver.FindElement(By.XPath("//input[@value='Update']"));

        private IWebElement CancelButton => driver.FindElement(By.XPath("//input[@value='Cancel']"));

        private IWebElement DeleteButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i"));

        

        public void CreateEducationRecord(IWebDriver driver,string collegeUniversityName, string countryOfCollegeUniversity, string title, string degree, string yearOfGraduation)
        {
            this.driver = driver;
            AddNewButton.Click();
            Thread.Sleep(2000);
            CollegeUniversityNameTextbox.SendKeys(collegeUniversityName);
            CountryOfCollegeUniversityDropdownbox.SendKeys(countryOfCollegeUniversity);
            Thread.Sleep(2000);
            TitleDropdownbox.SendKeys(title);
            DegreeTextbox.SendKeys(degree);
            YearOfGraduationDropdownbox.SendKeys(yearOfGraduation);
            AddButton.Click();
            Thread.Sleep(5000);
        }

        public void CheckTitleDropdownButton(IWebDriver driver)
        {
            this.driver = driver;
            AddNewButton.Click();
            CollegeUniversityNameTextbox.SendKeys("Mumbai University");
            CountryOfCollegeUniversityDropdownbox.SendKeys("Australia");
            TitleDropdownbox.SendKeys("PHD");
            DegreeTextbox.SendKeys("Arts");
            YearOfGraduationDropdownbox.SendKeys("2007");
            TitleDropdownbox.SendKeys("Title");
            AddButton.Click();
            Thread.Sleep(3000);
        }

        public string GetBlankField(IWebDriver driver)
        {
            IWebElement popupAlert = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']"));
            return popupAlert.Text;
        }

        public void EditEducationRecord(IWebDriver driver,string newCollegeUniversityName, string newCountryOfCollegeUniversity, string newTitle, string newDegree, string newYearOfGraduation)
        {
            this.driver = driver;
            EditButton.Click();
            Thread.Sleep(2000);
            CollegeUniversityNameTextbox.Clear();
            CollegeUniversityNameTextbox.SendKeys(newCollegeUniversityName);
            CountryOfCollegeUniversityDropdownbox.SendKeys(newCountryOfCollegeUniversity);
            TitleDropdownbox.SendKeys(newTitle);
            Thread.Sleep(2000);
            DegreeTextbox.Clear();
            DegreeTextbox.SendKeys(newDegree);
            Thread.Sleep(2000);
            YearOfGraduationDropdownbox.SendKeys(newYearOfGraduation);
            UpdateButton.Click();
            Thread.Sleep(5000);
        }

        public void CancelEditOperation(IWebDriver driver, string newTitle)
        {
            EditButton.Click();
            TitleDropdownbox.SendKeys(newTitle);
            CancelButton.Click();
            EditButton.Click();
            UpdateButton.Click();
            Thread.Sleep(2000);
        }

        public void DeleteEducationRecord(IWebDriver driver)
        {
            DeleteButton.Click();
        }
    }
}
