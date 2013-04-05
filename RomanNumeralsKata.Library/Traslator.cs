using System;
using System.Collections.Generic;

namespace RomanNumeralsKata.Library
{
    public class Traslator
    {
        private string Result { get; set; }

        private readonly IDictionary<string, string> _oneSymbolDictionary;
        private readonly IList<string> _units;
        private readonly IList<string> _tens;
        private readonly IList<string> _hundreds;

        public Traslator()
        {
            _oneSymbolDictionary = new Dictionary<string, string>
                                    {{"1","I"},{"5","V"},
                                    {"10","X"},{"50","L"},
                                    {"100","C"},{"500","D"},
                                    {"1000","M"}};
            _units = new List<string> { "V", "IV", "IX", "I" };
            _tens = new List<string> { "L", "XL", "XC", "X" };
            _hundreds = new List<string> { "D", "CD", "CM", "C" };
        }

        public string ConvertToRomanNumber(string value)
        {            
            Result = string.Empty;
            if (IsOnlyOneLetter(value))
                GetOneLetter(value);
            else
            {
                if(value.Length>2)GetCorrectSymbols(value.Substring(value.Length - 3,1),_hundreds);
                if (value.Length > 1)GetCorrectSymbols(value.Substring(value.Length - 2, 1), _tens);
                if (value.Length > 0)GetCorrectSymbols(value.Substring(value.Length - 1), _units);
            }
            return Result;
        }

        private void GetCorrectSymbols(string value,IList<string> symbols)
        {           
            switch (value)
            {
                case "5":
                    Result += symbols[0];
                    break;
                case "4":
                    Result += symbols[1];
                    break;
                case "9":
                    Result += symbols[2];
                    break;
                default:
                    var num = Convert.ToInt32(value);
                    if (num > 5)
                    {
                        Result += symbols[0];
                        num -= 5;
                    }                    
                    AddFromOneToThreeToEnd(num,symbols[3]);
                    break;
            }            
        }

        private void AddFromOneToThreeToEnd(int number, string unit)
        {
            for (var i = 1; i <= number; i++)
                Result += unit;
        }  
 
        private void GetOneLetter(string number)
        {                      
            Result = _oneSymbolDictionary[number];                       
        }

        private bool IsOnlyOneLetter(string number)
        {
           return _oneSymbolDictionary.ContainsKey(number);
        }         
    }
}