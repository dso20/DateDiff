using System;
using System.CodeDom;
using System.Linq.Expressions;
using NUnit;
using NUnit.Framework;
using DateDiffMVC;
using DateDiffMVC.Controllers;
using DateDiffMVC.Models;
using DateDiffMVC.Services;
using DateDiffMVC.ViewModels;
using NUnit.Framework.Internal;

namespace DateDiffMVCTest
{
    [TestFixture]
    public class HomeTests
    {
       private static Object[] testCorrect =
       {
           new Object[] { new Date() { Year = 2018, Month = 2, Day = 2 }, new Date() { Year = 2018, Month = 4, Day = 4}, new Tuple<int,int,int>(2,2,0) },
           new Object[] { new Date() { Year = 2018, Month = 3, Day = 6 }, new Date() { Year = 2018, Month = 4, Day = 4 }, new Tuple<int,int,int>(29,0,0) },
           new Object[] { new Date() { Year = 2017, Month = 6, Day = 6 }, new Date() { Year = 2018, Month = 4, Day = 4 }, new Tuple<int,int,int>(29,9,0) },
           new Object[] { new Date() { Year = 2017, Month = 2, Day = 2 }, new Date() { Year = 2018, Month = 4, Day = 4 }, new Tuple<int,int,int>(2,2,1) },
           new Object[] { new Date() { Year = 1750, Month = 2, Day = 2 }, new Date() { Year = 2018, Month = 4, Day = 4 }, new Tuple<int,int,int>(28,11,267) }

       };

        [TestCaseSource("testCorrect")]
        [Test]
        public void CalendarService_StartDateInPast_ValuesMatch(IDate start, IDate end, Tuple<int, int, int> expected)
        {
            var cal = new CalendarService();

            var result = cal.Result(start, end);

            Assert.AreEqual(expected, result);

        }


    }
}
