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
            return AreThereNineVariationInValue(value,NumbersType.Hundreds) ? CalculateThousands(value,-1) : CalculateThousands(value,1);
        }

        private static int CalculateThousands(string value,int number)
        {
            return value.Substring(0, value.LastIndexOf('M') + number).ToCharArray().Count() * 1000;
        }
 
        public static int ConvertToArabiganNumber(string value)
        {           
            return GetThousands(value) + GetNumbers(value,NumbersType.Hundreds) + GetNumbers(value,NumbersType.Tens) + 
                        GetNumbers(value,NumbersType.Units);                        
        }

        private static int GetNumbers(string value,NumbersType type)
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
            return value.Contains("XC") || value.Contains("IX");
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
