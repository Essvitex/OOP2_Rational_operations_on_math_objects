using System;
using System.Collections.Generic;
using System.IO;
using FirstLab.Commands;
using SecondLab;
using Secondlab;
/* Лабораторная работа №2: Операции над рациональными числами.
 * Исполнители: Зотов Антон, Сергеев Виктор.
 */
namespace FirstLab
{
    class Program
    {
        private static void Main(string[] args)
        {
            var robot = new Processing();
            robot.AddCommands(
                new List<ICommand>
            {
                new AddCommand(),
                new DivCommand(),
                new MulCommand(),
                new SubCommand()
            });
            robot.Run();

        }
    }
}
