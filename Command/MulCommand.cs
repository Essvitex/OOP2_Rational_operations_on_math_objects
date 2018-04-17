using System;
using System.Collections.Generic;
using FirstLab;
using FirstLab.Commands;

namespace Secondlab
{
    public class MulCommand : ICommand
    {
        public string Name
        {
            get { return "mul"; }
        }

        public string Help
        {
            get { return "Выполняет умножение нескольких рациональных чисел."; }
        }

        public string[] Synonyms
        {
            get { return new[] { "multiplication", "multi", "multiplic", "generation" }; }
        }

        public void Execute(List<string> param)
        {
            var rationalParamsHandler = new RationalParamsHandler();
            var rationals = rationalParamsHandler.Read(param);
            if (rationals != null)
            {
                Console.WriteLine(rationalParamsHandler.Operate(rationals, (x, y) => x.Multiply(y))?.ToString());
            }
        }
    }
}
