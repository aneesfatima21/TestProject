using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class TestProjectUnitTests
    {
        [TestMethod]
        public void Test_ValidateDate()
        {
            // Arrange
            string validDate1 = "15/08/2024";
            string validDate2 = "29/02/2024";

            // Act & Assert
            Assert.IsTrue(Program.ValidateDate(validDate1, out int day1, out int month1, out int year1));
            Assert.AreEqual(15, day1);
            Assert.AreEqual(8, month1);
            Assert.AreEqual(2024, year1);

            Assert.IsTrue(Program.ValidateDate(validDate2, out int day2, out int month2, out int year2));
            Assert.AreEqual(29, day2);
            Assert.AreEqual(2, month2);
            Assert.AreEqual(2024, year2);
        }

        [TestMethod]
        public void Test_ValidateDate_InvalidDates()
        {
            // Arrange
            string invalidDate1 = "31/04/2024"; 
            string invalidDate2 = "30/02/2024";
            string invalidDate3 = "15/13/2024"; 

            // Act & Assert
            Assert.IsFalse(Program.ValidateDate(invalidDate1, out _, out _, out _));
            Assert.IsFalse(Program.ValidateDate(invalidDate2, out _, out _, out _));
            Assert.IsFalse(Program.ValidateDate(invalidDate3, out _, out _, out _));
        }

        [TestMethod]
        public void Test_AddNoOfDays_SingleMonth()
        {
            // Arrange
            int day = 15;
            int month = 8;
            int year = 2024;
            int daysToAdd = 10;

            // Act
            var result = Program.AddNoOfDays(day, month, year, daysToAdd);

            // Assert
            Assert.AreEqual((25, 8, 2024), result);
        }

        [TestMethod]
        public void Test_AddNoOfDays_ChnangeOfMonth()
        {
            // Arrange
            int day = 28;
            int month = 2;
            int year = 2024; 
            int daysToAdd = 5;

            // Act
            var result = Program.AddNoOfDays(day, month, year, daysToAdd);

            // Assert
            Assert.AreEqual((4, 3, 2024), result);
        }

        [TestMethod]
        public void Test_AddNoOfDays_ChangeOfYEar()
        {
            // Arrange
            int day = 30;
            int month = 12;
            int year = 2023;
            int daysToAdd = 5;

            // Act
            var result = Program.AddNoOfDays(day, month, year, daysToAdd);

            // Assert
            Assert.AreEqual((4, 1, 2024), result);
        }

        [TestMethod]
        public void Test_DaysInMonth()
        {
            // Arrange
            int month1 = 1; 
            int year1 = 2024;
            int month2 = 2; 
            int year2 = 2024;
            int month3 = 2; 
            int year3 = 2023;
            int month4 = 4; 
            int year4 = 2024;

            // Act & Assert
            Assert.AreEqual(31, Program.NoOfDaysInMonth(month1, year1));
            Assert.AreEqual(29, Program.NoOfDaysInMonth(month2, year2));
            Assert.AreEqual(28, Program.NoOfDaysInMonth(month3, year3));
            Assert.AreEqual(30, Program.NoOfDaysInMonth(month4, year4));
        }
    }
}
