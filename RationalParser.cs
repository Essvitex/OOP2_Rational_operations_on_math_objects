using System;
using SecondLab;

namespace FirstLab
{
    public class RationalParser
    {
        public Rational Parse(string rationalInString)
        {
                var result = default(Rational);
                var splitedString = rationalInString.Split(new[] {'.', ':'}, StringSplitOptions.RemoveEmptyEntries);

            if(splitedString.Length == 0 || splitedString.Length > 3 || !int.TryParse(splitedString[0], out var _))
                throw new ArgumentException($"Неверное число '{rationalInString}'.");

            switch (splitedString.Length)
            {
                case 1:
                {
                    int.TryParse(splitedString[0], out var basePart);
                    result = GetRational(basePart, 0, 1);
                    break;
                }
                case 2:
                {
                    int.TryParse(splitedString[0], out var numerator);
                    int.TryParse(splitedString[1], out var denominator);
                    result = GetRational(0, numerator, denominator);
                    break;
                }
                case 3:
                {
                    int.TryParse(splitedString[0], out var basePart);
                    int.TryParse(splitedString[1], out var numerator);
                    int.TryParse(splitedString[2], out var denominator);
                    result = GetRational(basePart, numerator, denominator);
                    break;
                }
            }

                return result;
        }

        private Rational GetRational(int rationalBase, int rationalNumerator, int rationalDenominator)
        {
                return new Rational(rationalBase * rationalDenominator + 
                    rationalNumerator, rationalDenominator);
        }
    }
}