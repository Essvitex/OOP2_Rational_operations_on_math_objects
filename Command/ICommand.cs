using System.Collections.Generic;
using Secondlab;

namespace FirstLab.Commands
{
    public interface ICommand
    {
        /// <summary>
        /// Название команды
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Информация о команде и ее использовании
        /// </summary>
        string Help { get; }

        /// <summary>
        /// Синонимы команды
        /// </summary>
        string[] Synonyms { get; }

        /// <summary>
        /// Исполнение команды
        /// </summary>
        /// <param name="param">Возможные параметры команды</param>
        void Execute(List<string> param);
    }
}
