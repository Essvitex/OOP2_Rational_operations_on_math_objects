using System;
using System.Collections.Generic;
using FirstLab;
using FirstLab.Commands;

namespace Secondlab
{
    public class SubCommand : ICommand
    {
        public string Name
        {
            get { return "sub"; }
        }

        public string Help
        {
            get { return "Выполняет вычитание нескольких рациональных чисел."; }
        }

        public string[] Synonyms
        {
            get { return new[] { "subtraction", "subtrac", "deduction", "deduct" }; }
        }

        public void Execute(List<string> param)
        {
            var rationalParamsHandler = new RationalParamsHandler();
            var rationals = rationalParamsHandler.Read(param);
            if (rationals != null)
            {
                Console.WriteLine(rationalParamsHandler.Operate(rationals, (x, y) => x.Sub(y))?.ToString());
            }
        }
    }
}
