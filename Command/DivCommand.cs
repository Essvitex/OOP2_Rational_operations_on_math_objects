using System;
using System.Collections.Generic;
using FirstLab;
using FirstLab.Commands;

namespace Secondlab
{
    public class DivCommand : ICommand
    {
        public string Name
        {
            get { return "div"; }
        }

        public string Help
        {
            get { return "Выполняет деление нескольких рациональных чисел."; }
        }

        public string[] Synonyms
        {
            get { return new[] { "division", "divis", "segmentation" }; }
        }

        public void Execute(List<string> param)
        {
            var rationalParamsHandler = new RationalParamsHandler();
            var rationals = rationalParamsHandler.Read(param);

            if (rationals != null)
            {
                var summ = rationalParamsHandler.Operate(rationals, (x, y) => x.DivideBy(y));
                if (summ.HasValue)
                {
                    Console.WriteLine(summ.Value.ToString());
                }
            }
        }
    }
}
