using System;
using System.Collections.Generic;
using Secondlab;
using SecondLab;

namespace FirstLab
{
    public class RationalParamsHandler
    {
        public List<Rational> Read(List<string> param)
        {
            try
            {
                var result = new List<Rational>();
                if (param.Count <= 0)
                    throw new ArgumentException("Не хватает параметров.");
                foreach (var currentParam in param)
                {
                    if (!Rational.TryParse(currentParam, out var rational))
                    {
                        Console.WriteLine("Не удалось получить число. " +
                                          "Возможно оно некорректно введено или знаменатель равен нулю.");
                        return null;
                    }
                    result.Add(rational);
                }
                return result;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public Rational? Operate(List<Rational> rationals, Func<Rational, Rational, Rational> operation)
        {
            try
            {
                var summ = new Rational();
                for (var index = 0; index < rationals.Count; index++)
                {
                    summ = index > 0 ? operation(summ, rationals[index]) : rationals[index];
                }
                return summ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}