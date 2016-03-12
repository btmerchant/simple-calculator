using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;
using System.Collections.Generic;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void TermsEnsureICanCreateAnInstance()
        {
            Expression my_terms = new Expression();
            Assert.IsNotNull(my_terms);
        }

        [TestMethod]
        public void TermsProveICanExtractTerms()
        {
           Expression my_terms = new Expression();

           int[] Actual = my_terms.ExtractTerms("5 + 1");
           int[] Expected = new int[2] { 5, 1 };

           Assert.AreSame(Expected, Actual);
        }
    }
}
