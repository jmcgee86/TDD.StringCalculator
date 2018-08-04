using NUnit.Framework;
using System;
using Calculator.Services;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void IfEmptyString_ReturnZero()
        {
            CalculatorService _calculatorService = new CalculatorService();
            var str = String.Empty;
            var result = _calculatorService.StringCalculator(str);
            var expectedResult = 0;
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void IfSingleNumber_ReturnValue()
        {
            CalculatorService _calculatorService = new CalculatorService();
            var str = "9";
            var result = _calculatorService.StringCalculator(str);
            var expectedResult = 9;
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void IfTwoNumbersCommaDelimited_ReturnSum()
        {
            CalculatorService _calculatorService = new CalculatorService();
            var str = "9, 10";
            var result = _calculatorService.StringCalculator(str);
            var expectedResult = 19;
            Assert.AreEqual(expectedResult, result);   
        }

        [Test]
        public void IfTwoNumbersNewLineDelimited_ReturnSum()
        {
            CalculatorService _calculatorService = new CalculatorService();
            var str = "7 \r\n 10";
            var result = _calculatorService.StringCalculator(str);
            var expectedResult = 17;
            Assert.AreEqual(expectedResult, result);   
        }

        [Test]
        public void IfThreeNumbersDelimitedAnyWay_ReturnSum()
        {
            CalculatorService _calculatorService = new CalculatorService();
            var str1 = "4 \r\n 10, 10";
            var result = _calculatorService.StringCalculator(str1);
            var expectedResult = 24;
            Assert.AreEqual(expectedResult, result);  
        }

          [Test]
        public void NegativeNumberThrowsAnExceptions()
        {
            CalculatorService _calculatorService = new CalculatorService();
            var str1 = "-5";
            var ex = Assert.Throws<System.ArgumentException>(() => _calculatorService.StringCalculator(str1));

            Assert.IsTrue(ex.Message.Contains("Negative number"));
        }

        [Test]
        public void NumberGreaterThan1000_Ignore()
        {
            CalculatorService _calculatorService = new CalculatorService();
            var str1 = "1000, 7, 999";
            var result = _calculatorService.StringCalculator(str1);
            Assert.AreEqual(1006, result); 
        }
    }
}