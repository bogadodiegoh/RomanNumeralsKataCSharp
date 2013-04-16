using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RomanNumeralsKata.Library
{
    public class Traslator
    {
        #region Properties

        private readonly IList<string> _hundreds;
        private readonly IDictionary<string, string> _oneSymbolDictionary;
        private readonly IList<string> _tens;
        private readonly IList<string> _units;
        private string Result { get; set; }

        #endregion        

        public Traslator()
        {
            _oneSymbolDictionary = new Dictionary<string, string>
                {
                    {"1", "I"},
                    {"4","IV"},
                    {"5", "V"},
                    {"9","IX"},
                    {"10", "X"},
                    {"40","XL"},
                    {"50", "L"},
                    {"90","XC"},
                    {"100", "C"},
                    {"400","CD"},
                    {"500", "D"},
                    {"900","CM"},
                    {"1000", "M"}                    
                };
            _units = new List<string> {"V", "IV", "IX", "I"};
            _tens = new List<string> {"L", "XL", "XC", "X"};
            _hundreds = new List<string> {"D", "CD", "CM", "C"};
        }

        #region Public Methods

        public string ConvertToRomanNumber(string value)
        {
            Result = string.Empty;
            if (IsOnlyOneLetter(value))
                GetOneLetter(value);
            else
            {
                if (value.Length > 2) GetCorrectSymbols(value.Substring(value.Length - 3, 1), _hundreds);
                if (value.Length > 1) GetCorrectSymbols(value.Substring(value.Length - 2, 1), _tens);
                if (value.Length > 0) GetCorrectSymbols(value.Substring(value.Length - 1), _units);
            }
            return Result;
        }     

        #endregion       

        #region Arabigan to Roman Private Methods

        private void GetCorrectSymbols(string value, IList<string> symbols)
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
                    int num = Convert.ToInt32(value);
                    if (num > 5)
                    {
                        Result += symbols[0];
                        num -= 5;
                    }
                    AddFromOneToThreeToEnd(num, symbols[3]);
                    break;
            }
        }

        private void AddFromOneToThreeToEnd(int number, string unit)
        {
            for (int i = 1; i <= number; i++)
                Result += unit;
        }

        private void GetOneLetter(string number)
        {
            Result = _oneSymbolDictionary[number];
        }

        private bool IsOnlyOneLetter(string value)
        {
            int result;
            return Int32.TryParse(value, out result) ? _oneSymbolDictionary.ContainsKey(value) : _oneSymbolDictionary.Any(dictionaryValue => value == dictionaryValue.Value);
        }    

        #endregion                               
    }
}