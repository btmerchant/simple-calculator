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

        [TestMethod]
        public void TermsProveICanAddTerms()
        {
            Expression my_adder = new Expression();
            int[] x = my_adder.ExtractTerms("5+5");
            Calc my_calc = new Calc();

            int Actual = my_calc.add(x);
            int Expected = 10;

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void TermsProveICanSubtractTerms()
        {
            Expression my_adder = new Expression();
            int[] x = my_adder.ExtractTerms("5-2");
            Calc my_calc = new Calc();

            int Actual = my_calc.sub(x);
            int Expected = 3;

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void TermsProveICanMultiplyTerms()
        {
            Expression my_adder = new Expression();
            int[] x = my_adder.ExtractTerms("3*5");
            Calc my_calc = new Calc();

            int Actual = my_calc.mult(x);
            int Expected = 15;

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void TermsProveICanDevideTerms()
        {
            Expression my_adder = new Expression();
            int[] x = my_adder.ExtractTerms("4/2");
            Calc my_calc = new Calc();

            int Actual = my_calc.div(x);
            int Expected = 2;

            Assert.AreEqual(Expected, Actual);
        }

        [TestMethod]
        public void TermsProveICanGetRemainderFromTerms()
        {
            Expression my_adder = new Expression();
            int[] x = my_adder.ExtractTerms("7%5");
            Calc my_calc = new Calc();

            int Actual = my_calc.mod(x);
            int Expected = 2;

            Assert.AreEqual(Expected, Actual);
        }
        [TestMethod]
        public void MyTestMethod()
        {

        }
    }
}