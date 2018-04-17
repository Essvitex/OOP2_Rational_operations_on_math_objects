using System;
using FirstLab;

namespace SecondLab
{
    public struct Rational
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public int Base => Numerator / Denominator;
        public int Fraction => Numerator % Denominator;

        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю.");
            }

            Numerator = numerator;
            Denominator = denominator;
            Even();

            if (Denominator < 0)
            {
                Numerator *= -1;
                Denominator *= -1;
            }
        }

        public Rational Add(Rational c)
        {
            return this + c;
        }

        public Rational Sub(Rational c)
        {
            return this - c;
        }

        public Rational Negate()
        {
            return 0 - this;
        }

        public Rational Multiply(Rational r)
        {
            return this * r;
        }

        public Rational DivideBy(Rational r)
        {
            if (r.Numerator == 0)
                throw new DivideByZeroException("Деление на ноль невозможно.");
            return this / r;
        }

        public override string ToString()
        {
            if (Fraction == 0)
            {
                return Base.ToString();
            }
            if (Base == 0)
            {
                return $"{Numerator}:{Denominator}";
            }
            return $"{Base}.{Math.Abs(Fraction)}:{Denominator}";
        }

        /// <summary>
        /// Пытается преобразовать строку в рациональное число,
        /// распознает следующие строки:
        /// int - целое число
        /// int:int - обыкновенная дробь
        /// int.int:int - обыкновенная дробь с целой частью
        /// </summary>
        /// <param name="input">входная строка</param>
        /// <param name="result">полученное из строки рациональное число</param>
        /// <returns>Если получилось преобразовать строку в рациональное число, то вернет true, иначе - false.</returns>
        public static bool TryParse(string input, out Rational result)
        {
            result = default(Rational);
            try
            {
                result = new RationalParser().Parse(input);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void Even()
        {
            int divisor = GreatestCommonDivisor(Numerator, Denominator);
            Numerator /= divisor;
            Denominator /= divisor;
        }

        private static int LeastCommonMultiple(int val1, int val2)
        {
            var multiple = val1 * val1;
            for (int i = 0; i < (val1 * val2 + 1); i++)
            {
                if (i % val1 == 0 && i % val2 == 0)
                {
                    multiple = i;
                }
            }
            return multiple;
        }

        private static int GreatestCommonDivisor(int val1, int val2)
        {
            while (val2 != 0)
            {
                var temp = val2;
                val2 = val1 % val2;
                val1 = temp;
            }
            return val1;
        }

        public static explicit operator int(Rational r)
        {
            return r.Base;
        }

        public static implicit operator Rational(int num)
        {
            return new Rational(num, 1);
        }

        public static Rational operator + (Rational r1, Rational r2)
        {
            var denominator = LeastCommonMultiple(r1.Denominator, r2.Denominator);
            var numerator = r1.Numerator * denominator / r1.Denominator + r2.Numerator * denominator / r2.Denominator;

            return new Rational(numerator, denominator);
        }

        public static Rational operator + (Rational r1, int num)
        {
            return new Rational(r1.Numerator + num * r1.Denominator, r1.Denominator);
        }

        public static Rational operator + (int num, Rational r1)
        {
            return new Rational(r1.Numerator + num * r1.Denominator, r1.Denominator);
        }

        public static Rational operator - (Rational r1, Rational r2)
        {
            var denominator = LeastCommonMultiple(r1.Denominator, r2.Denominator);
            var numerator = r1.Numerator * denominator / r1.Denominator - r2.Numerator * denominator / r2.Denominator;
            return new Rational(numerator, denominator);
        }

        public static Rational operator - (Rational r1, int num)
        {
            return new Rational(r1.Numerator - num * r1.Denominator, r1.Denominator);
        }

        public static Rational operator - (int num, Rational r1)
        {
            return new Rational(num * r1.Denominator - r1.Numerator, r1.Denominator);
        }

        public static Rational operator * (Rational r1, Rational r2)
        {
            var denominator = r1.Denominator * r2.Denominator;
            var numerator = r1.Numerator * r2.Numerator;
            return new Rational(numerator, denominator);
        }

        public static Rational operator * (Rational r1, int num)
        {
            return new Rational(r1.Numerator * num, r1.Denominator);
        }

        public static Rational operator * (int num, Rational r1)
        {
            return new Rational(r1.Numerator * num, r1.Denominator);
        }

        public static Rational operator /(Rational r1, Rational r2)
        {
            var denominator = r1.Denominator * r2.Numerator;
            var numerator = r1.Numerator * r2.Denominator;
            return new Rational(numerator, denominator);
        }

        public static Rational operator / (Rational r1, int num)
        {
            return new Rational(r1.Numerator, r1.Denominator * num);
        }

        public static Rational operator / (int num, Rational r1)
        {
            return new Rational(r1.Denominator * num, r1.Numerator);
        }
    }
}