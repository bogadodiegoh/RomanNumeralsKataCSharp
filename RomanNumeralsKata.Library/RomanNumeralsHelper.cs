using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumeralsKata.Library
{
    public class RomanNumeralsHelper
    {
        public static int GetThousands(string value)
        {
            return AreThereNineVariationInValue(value,NumbersType.Hundreds) ? CalculateThousandsWithoutNineHundreds(value) : CalculateThousands(value);
        }

        private static int CalculateThousands(string value)
        {
            return value.Substring(0, value.LastIndexOf('M') + 1).ToCharArray().Count() * 1000;
        }

        private static int CalculateThousandsWithoutNineHundreds(string value)
        {
            return value.Substring(0, value.LastIndexOf('M') - 1).ToCharArray().Count() * 1000;
        }

        public static int ConvertToArabiganNumber(string value)
        {           
            return GetThousands(value) + GetNumbers(value,NumbersType.Hundreds) + GetNumbers(value,NumbersType.Tens) + 
                        GetNumbers(value,NumbersType.Units);                        
        }

        public static int GetNumbers(string value,NumbersType type)
        {
            var numbers = 0;
            var numberHelper = GetNumberHelper(type);

            if (AreThereNineVariationInValue(value, type))      
                numbers = CalculateFiveVariations(type) + (numberHelper * 4);
            if (AreThereFourVariationInValue(value, type) && numbers == 0)            
                numbers = CalculateFiveVariations(type) - (numberHelper * 1);
            if (AreThereFiveVariationInValue(value, type) && numbers == 0)        
                numbers = CalculateFiveVariations(type);
            if (AreThereOneVariationInValue(value, type) && (numbers == 0 || numbers == (numberHelper * 5)))
                numbers += CalculateOneVariations(value, type);
            return numbers;   
        }

        private static int GetNumberHelper(NumbersType type)
        {
            var number = 0;

            switch (type)
            {                     
                case NumbersType.Hundreds:                    
                    number = 100;
                    break;
                case NumbersType.Tens:                    
                    number = 10;
                    break;
                case NumbersType.Units:                    
                    number = 1;
                    break;
            }
            return number;
        }

        public static int GetHundreds(string value)
        {            
            var hundreds = 0;
            var type = NumbersType.Hundreds;
            
            if (AreThereNineVariationInValue(value,type))//CM        
                hundreds = CalculateFiveVariations(type) + 400;
            if (AreThereFourVariationInValue(value,type) && hundreds == 0)//CD            
                hundreds = CalculateFiveVariations(type) - 100;
            if (AreThereFiveVariationInValue(value,type) && hundreds == 0)//D        
                hundreds = CalculateFiveVariations(type);
            if (AreThereOneVariationInValue(value,type) && (hundreds == 0 || hundreds == 500))            
                hundreds += CalculateOneVariations(value,type);            
            return hundreds;         
        }

        public static int GetTens(string value)
        {
            var tens = 0;
            var type = NumbersType.Tens;

            if (AreThereNineVariationInValue(value,type))//XC        
                tens = CalculateFiveVariations(type) + 40;
            if (AreThereFourVariationInValue(value,type) && tens == 0)//XL            
                tens = CalculateFiveVariations(type) - 10;
            if (AreThereFiveVariationInValue(value,type) && tens == 0)//L       
                tens = CalculateFiveVariations(type);
            if (AreThereOneVariationInValue(value, type) && (tens == 0 || tens == 50))
                tens += CalculateOneVariations(value,type);

            return tens;
        }

        public static int GetUnits(string value)
        {
            var units = 0;
            var type = NumbersType.Units;

            if (AreThereNineVariationInValue(value,type))//IX        
                units = CalculateFiveVariations(type) + 4;
            if (AreThereFourVariationInValue(value,type) && units == 0)//IV            
                units = CalculateFiveVariations(type) - 1;
            if (AreThereFiveVariationInValue(value,type) && units == 0)//V       
                units = CalculateFiveVariations(type);
            if (AreThereOneVariationInValue(value, type) && (units == 0 || units == 5))
                units += CalculateOneVariations(value,type);

            return units;
        }

        private static int CalculateFiveVariations(NumbersType type)
        {
            var number = 0;

            switch (type)
            {
                case NumbersType.Hundreds:                    
                    number = 500;
                    break;
                case NumbersType.Tens:                    
                    number = 50;
                    break;
                case NumbersType.Units:                    
                    number = 5;
                    break;
            }
            return number;
        }

        private static int CalculateOneVariations(string value,NumbersType type)
        {
            var letter = ' ';
            var number = 0;

            switch (type)
            {
                case NumbersType.Hundreds:
                    letter = 'C';
                    number = 100;
                    break;
                case NumbersType.Tens:
                    letter = 'X';
                    number = 10;
                    break;
                case NumbersType.Units:
                    letter = 'I';
                    number = 1;
                    break;
            }

            return value.ToCharArray().Where(x => x == letter).Count()*number;
        }                     

        private static bool AreThereNineVariationInValue(string value, NumbersType type)
        {
            var firstLetter = ' ';
            var secondLetter = ' ';

            switch (type)
            {
                case NumbersType.Hundreds:
                    firstLetter = 'M';
                    secondLetter = 'C';
                    break;
                case NumbersType.Tens:
                    firstLetter = 'C';
                    secondLetter = 'X';
                    break;
                case NumbersType.Units:
                    firstLetter = 'X';
                    secondLetter = 'I';
                    break;
            }

            if ((value.LastIndexOf(firstLetter) + 1) - 2 >= 0)
                return value[(value.LastIndexOf(firstLetter) + 1) - 2] == secondLetter;
            return false;
        }

        private static bool AreThereFiveVariationInValue(string value, NumbersType type)
        {
            var letter = string.Empty;

            switch (type)
            {
                case NumbersType.Hundreds:
                    letter = "D";
                    break;
                case NumbersType.Tens:
                    letter = "L";
                    break;
                case NumbersType.Units:
                    letter = "V";
                    break;
            }
            return value.Contains(letter) && !AreThereFourVariationInValue(value, type);
        }

        private static bool AreThereFourVariationInValue(string value, NumbersType type)
        {
            var letter = string.Empty;            

            switch (type)
            {
                case NumbersType.Hundreds:
                    letter = "CD";                  
                    break;
                case NumbersType.Tens:
                    letter = "XL";                    
                    break;
                case NumbersType.Units:
                    letter = "IV";                    
                    break;
            }
            return value.Contains(letter);
        }

        private static bool AreThereOneVariationInValue(string value,NumbersType type)
        {
            var letter = ' ';           

            switch (type)
            {                
                case NumbersType.Hundreds:
                    letter = 'C';                 
                    break;
                case NumbersType.Tens:
                    letter = 'X';                   
                    break;
                case NumbersType.Units:
                    letter = 'I';
                    break;            
            }
            
            return value.Contains(letter) && !AreThereFourVariationInValue(value, type) && !ContainsSpecialCases(value);
        }

        private static bool ContainsSpecialCases(string value)
        {
            return value.Contains("XC");
        }
    }

    public enum NumbersType
    {
        Thounsands,
        Hundreds,
        Tens,
        Units
    }
}
