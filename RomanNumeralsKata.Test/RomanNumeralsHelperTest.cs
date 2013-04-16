using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RomanNumeralsKata.Library;

namespace RomanNumeralsKata.Test
{
    public class RomanNumeralsHelperTest
    {
        [Test]
        public void ShouldConvertThousands()
        {
            Assert.AreEqual(1000, RomanNumeralsHelper.ConvertToArabiganNumber("M"));
            Assert.AreEqual(2000, RomanNumeralsHelper.ConvertToArabiganNumber("MM"));
            Assert.AreEqual(3000, RomanNumeralsHelper.ConvertToArabiganNumber("MMM"));
        }

        [Test]
        public void ShouldConvertHundreds()
        {
            Assert.AreEqual(900, RomanNumeralsHelper.ConvertToArabiganNumber("CM"));
            Assert.AreEqual(400, RomanNumeralsHelper.ConvertToArabiganNumber("CD"));
            Assert.AreEqual(500, RomanNumeralsHelper.ConvertToArabiganNumber("D"));
            Assert.AreEqual(700, RomanNumeralsHelper.ConvertToArabiganNumber("DCC"));
            Assert.AreEqual(800, RomanNumeralsHelper.ConvertToArabiganNumber("DCCC"));
            Assert.AreEqual(300, RomanNumeralsHelper.ConvertToArabiganNumber("CCC"));
            Assert.AreEqual(100, RomanNumeralsHelper.ConvertToArabiganNumber("C"));    
        }

        [Test]
        public void ShouldConvertTens()
        {
            Assert.AreEqual(90, RomanNumeralsHelper.ConvertToArabiganNumber("XC"));
            Assert.AreEqual(40, RomanNumeralsHelper.ConvertToArabiganNumber("XL"));
            Assert.AreEqual(50, RomanNumeralsHelper.ConvertToArabiganNumber("L"));
            Assert.AreEqual(70, RomanNumeralsHelper.ConvertToArabiganNumber("LXX"));
            Assert.AreEqual(80, RomanNumeralsHelper.ConvertToArabiganNumber("LXXX"));
            Assert.AreEqual(30, RomanNumeralsHelper.ConvertToArabiganNumber("XXX"));
            Assert.AreEqual(10, RomanNumeralsHelper.ConvertToArabiganNumber("X"));
        }

        [Test]
        public void ShouldConvertUnits()
        {
            Assert.AreEqual(9, RomanNumeralsHelper.GetNumbers("IX",NumbersType.Units));
            Assert.AreEqual(4, RomanNumeralsHelper.GetNumbers("IV", NumbersType.Units));
            Assert.AreEqual(5, RomanNumeralsHelper.GetNumbers("V", NumbersType.Units));
            Assert.AreEqual(7, RomanNumeralsHelper.GetNumbers("VII", NumbersType.Units));
            Assert.AreEqual(8, RomanNumeralsHelper.GetNumbers("VIII", NumbersType.Units));
            Assert.AreEqual(3, RomanNumeralsHelper.GetNumbers("III", NumbersType.Units));           
        }

        [Test]
        public void ShouldConvertGeneralNumbers()
        {
            var romanNumber = "MMCCCXLVII";
            var result = RomanNumeralsHelper.ConvertToArabiganNumber(romanNumber);
            var expected = 2347;

            Assert.AreEqual(expected, result);

            romanNumber = "CMXCIX";
            result = RomanNumeralsHelper.ConvertToArabiganNumber(romanNumber);
            expected = 999;

            Assert.AreEqual(expected, result);

            romanNumber = "CDXLIV";
            result = RomanNumeralsHelper.ConvertToArabiganNumber(romanNumber);
            expected = 444;

            Assert.AreEqual(expected, result);
        }
    }
}
