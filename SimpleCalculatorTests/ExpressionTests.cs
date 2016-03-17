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
            int[] Expected = new int[3] { 5, 1, 1 };

            CollectionAssert.AreEqual(Expected, Actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void BadTermOneTermTest()
        {
            Expression my_terms = new Expression();

            int[] Actual = my_terms.ExtractTerms("5");
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void BadTermTooManyTermsTest()
        {
            Expression my_terms = new Expression();

            int[] Actual = my_terms.ExtractTerms("537");
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void BadTermNoTermsTest()
        {
            Expression my_terms = new Expression();

            string[] Actual = my_terms.ExtractOps("+++");
        }
    }
}