using System;
using System.CodeDom;
using System.Linq.Expressions;
using NUnit;
using NUnit.Framework;
using DateDiffMVC;
using DateDiffMVC.Controllers;
using DateDiffMVC.Models;
using DateDiffMVC.ViewModels;
using NUnit.Framework.Internal;

namespace DateDiffMVCTest
{
    [TestFixture]
    public class HomeTests
    {
       private static Object[] test =
       {
           new Object[] {112, new Date() {Year = 2018,Month = 2,Day =2}, new Tuple<int,int,int>(23,3,0) },
           new Object[] {15679, new Date() {Year = 1957,Month = 3,Day =30}, new Tuple<int,int,int>(2,11,42) },
           new Object[] {27832, new Date() {Year = 1904,Month = 8,Day =20}, new Tuple<int,int,int>(13,2,76) },
           new Object[] {24859, new Date() {Year = 1908,Month = 2,Day =29}, new Tuple<int,int,int>(23,0,68) },
           new Object[] {50843, new Date() {Year = 1784,Month = 5,Day =2}, new Tuple<int,int,int>(14,2,139) }

       };

        //[TestCaseSource("test")]
        //[Test]
        //public void IndexPost_result(int diff,IDate start, Tuple<int,int,int> expected)
        //{
        //    //need to change
        //    var result = Date.Diff(diff, start);
            
        //    Assert.AreEqual(expected ,result);

        //}
     
    }
}
