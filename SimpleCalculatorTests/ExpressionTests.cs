using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator.Properties;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void TermsEnsureICanCreateAnInstance()
        {
            ExtractTerms my_terms = new ExtractTerms();
            Assert.IsNotNull(my_terms);
        }

        [TestMethod]
        public void TermsProveICanExtractTerms()
        {
            //ParseInput my_terms = new ParseInput();

            //int Actual = my_terms.EvaluateExpression("5 + 10");
            int Expected = 15;

           // Assert.AreEqual(Expected, Actual);
        }
    }
}
