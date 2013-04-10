using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RomanNumeralsKata.Library;

namespace RomanNumeralsKata.Test
{
    [TestFixture]
    public class TraslatorFromArabiganToRomanTest
    {
        private Traslator _traslator;

        [SetUp]
        public void Setup()
        {
            _traslator = new Traslator();
        }

        [Test]
        public void ShouldConvertSingleNumbers()
        {            
            Assert.AreEqual("I", _traslator.ConvertToRomanNumber("1"));
            Assert.AreEqual("V", _traslator.ConvertToRomanNumber("5"));
            Assert.AreEqual("X", _traslator.ConvertToRomanNumber("10"));
            Assert.AreEqual("L", _traslator.ConvertToRomanNumber("50"));
            Assert.AreEqual("C", _traslator.ConvertToRomanNumber("100"));
            Assert.AreEqual("D", _traslator.ConvertToRomanNumber("500"));
            Assert.AreEqual("M", _traslator.ConvertToRomanNumber("1000"));
        }

        [Test]
        public void ShouldConvertFromTwoToFive()
        {
            Assert.AreEqual("II", _traslator.ConvertToRomanNumber("2"));
            Assert.AreEqual("III", _traslator.ConvertToRomanNumber("3"));
            Assert.AreEqual("IV", _traslator.ConvertToRomanNumber("4"));
            Assert.AreEqual("V", _traslator.ConvertToRomanNumber("5"));          
        }

        [Test]
        public void ShouldConvertFromSixToTen()
        {
            Assert.AreEqual("IX", _traslator.ConvertToRomanNumber("9"));
            Assert.AreEqual("VIII", _traslator.ConvertToRomanNumber("8"));
            Assert.AreEqual("VII", _traslator.ConvertToRomanNumber("7"));
            Assert.AreEqual("VI", _traslator.ConvertToRomanNumber("6"));
        }

        [Test]
        public void ShouldConvertFromTenToFifty()
        {
            Assert.AreEqual("XV", _traslator.ConvertToRomanNumber("15"));
            Assert.AreEqual("XXV", _traslator.ConvertToRomanNumber("25"));
            Assert.AreEqual("XL", _traslator.ConvertToRomanNumber("40"));            
        }

        [Test]
        public void ShouldConvertFromFiftyToOneHundred()
        {
            Assert.AreEqual("LV", _traslator.ConvertToRomanNumber("55"));
            Assert.AreEqual("LXXVIII", _traslator.ConvertToRomanNumber("78"));
            Assert.AreEqual("XC", _traslator.ConvertToRomanNumber("90"));
        }

        [Test]
        public void ShouldConvertFromOneHundredToFiveHundred()
        {
            Assert.AreEqual("CCLV", _traslator.ConvertToRomanNumber("255"));
            Assert.AreEqual("CCCLXXVIII", _traslator.ConvertToRomanNumber("378"));
            Assert.AreEqual("D", _traslator.ConvertToRomanNumber("500"));
        }

        [Test]
        public void ShouldConvertFromFiveHundredToOneThousands()
        {
            Assert.AreEqual("DXVII", _traslator.ConvertToRomanNumber("517"));
            Assert.AreEqual("DCCCXXXIX", _traslator.ConvertToRomanNumber("839"));
            Assert.AreEqual("M", _traslator.ConvertToRomanNumber("1000"));
        }
    }
}
