using System;
using System.Collections.Generic;
using FirstLab;
using FirstLab.Commands;

namespace Secondlab
{
    public class AddCommand : ICommand
    {
        public string Name
        {
            get { return "add"; }
        }

        public string Help
        {
            get { return "Выполняет сложение нескольких рациональных чисел."; }
        }

        public string[] Synonyms
        {
            get { return new[] { "addition", "addit", "sum", "amount" }; }
        }

        public void Execute(List<string> param)
        {
            var rationalParamsHandler = new RationalParamsHandler();
            var rationals = rationalParamsHandler.Read(param);
            if (rationals != null)
            {
                Console.WriteLine(rationalParamsHandler.Operate(rationals, (x, y) => x.Add(y))?.ToString());
            }
        }
    }
}