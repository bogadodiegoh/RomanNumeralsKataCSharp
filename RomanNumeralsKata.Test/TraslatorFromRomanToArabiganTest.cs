using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RomanNumeralsKata.Library;

namespace RomanNumeralsKata.Test
{
    [TestFixture]
    public class TraslatorFromRomanToArabiganTest
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
            Assert.AreEqual("1", _traslator.ConvertToArabiganNumber("I"));
            Assert.AreEqual("5", _traslator.ConvertToArabiganNumber("V"));
            Assert.AreEqual("10", _traslator.ConvertToArabiganNumber("X"));
            Assert.AreEqual("50", _traslator.ConvertToArabiganNumber("L"));
            Assert.AreEqual("100", _traslator.ConvertToArabiganNumber("C"));
            Assert.AreEqual("500", _traslator.ConvertToArabiganNumber("D"));
            Assert.AreEqual("1000", _traslator.ConvertToArabiganNumber("M"));
        }

        [Test]
        public void ShouldConvertFromTwoToFive()
        {
            Assert.AreEqual("2", _traslator.ConvertToRomanNumber("II"));
            Assert.AreEqual("3", _traslator.ConvertToRomanNumber("III"));
            Assert.AreEqual("4", _traslator.ConvertToRomanNumber("IV"));
            Assert.AreEqual("5", _traslator.ConvertToRomanNumber("V"));
        }

        //[Test]
        //public void ShouldConvertFromSixToTen()
        //{
        //    Assert.AreEqual("IX", _traslator.ConvertToRomanNumber("9"));
        //    Assert.AreEqual("VIII", _traslator.ConvertToRomanNumber("8"));
        //    Assert.AreEqual("VII", _traslator.ConvertToRomanNumber("7"));
        //    Assert.AreEqual("VI", _traslator.ConvertToRomanNumber("6"));
        //}

        //[Test]
        //public void ShouldConvertFromTenToFifty()
        //{
        //    Assert.AreEqual("XV", _traslator.ConvertToRomanNumber("15"));
        //    Assert.AreEqual("XXV", _traslator.ConvertToRomanNumber("25"));
        //    Assert.AreEqual("XL", _traslator.ConvertToRomanNumber("40"));            
        //}

        //[Test]
        //public void ShouldConvertFromFiftyToOneHundred()
        //{
        //    Assert.AreEqual("LV", _traslator.ConvertToRomanNumber("55"));
        //    Assert.AreEqual("LXXVIII", _traslator.ConvertToRomanNumber("78"));
        //    Assert.AreEqual("XC", _traslator.ConvertToRomanNumber("90"));
        //}

        //[Test]
        //public void ShouldConvertFromOneHundredToFiveHundred()
        //{
        //    Assert.AreEqual("CCLV", _traslator.ConvertToRomanNumber("255"));
        //    Assert.AreEqual("CCCLXXVIII", _traslator.ConvertToRomanNumber("378"));
        //    Assert.AreEqual("D", _traslator.ConvertToRomanNumber("500"));
        //}

        //[Test]
        //public void ShouldConvertFromFiveHundredToOneThousands()
        //{
        //    Assert.AreEqual("DXVII", _traslator.ConvertToRomanNumber("517"));
        //    Assert.AreEqual("DCCCXXXIX", _traslator.ConvertToRomanNumber("839"));
        //    Assert.AreEqual("M", _traslator.ConvertToRomanNumber("1000"));
        //}
    }
}
