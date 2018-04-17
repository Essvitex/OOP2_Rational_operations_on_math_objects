using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using FirstLab.Commands;
using Secondlab;

namespace FirstLab
{
    /// <summary>
    /// Класс для обработки команды и ее поиска
    /// </summary>
    public class Processing
    {
        /// <summary>
        /// Словарь всех возможных команд с синонимами, реализующих интерфейс ICommand
        /// </summary>
        public static Dictionary<string, ICommand> AllComm { get; private set; }

        /// <summary>
        /// Флаг останавливает программу при значении false
        /// </summary>
        private bool isRunning = true;

        /// <summary>
        /// Список всех экземпляров классов команд
        /// </summary>
        public List<ICommand> Commands { get; set; }

        public Processing()
        {
            AllComm = new Dictionary<string, ICommand>();
            Commands = new List<ICommand>
            {
                new Clear(),
                new ExitCommand(this),
                new HelpCommand()
            };
        }

        public void AddCommands(List<ICommand> commands)
        {
            foreach (var command in commands)
            {
                Commands.Add(command);
            }
        }
        /// <summary>
        /// Добавление команд вместе с их синонимами в словарь команд
        /// </summary>
        public void AddCommands()
        {
            foreach (var currComm in Commands)
            {
                AllComm.Add(currComm.Name, currComm);
                foreach (var synonym in currComm.Synonyms)
                {
                    AllComm.Add(synonym, currComm);
                }
            }
        }

        /// <summary>
        /// Осановка программы
        /// </summary>
        public void Stop()
        {
            isRunning = false;
        }

        /// <summary>
        /// Запуск программы
        /// </summary>
        public void Run()
        {
            AddCommands();
            while (isRunning)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("> ");
                var currStr = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;

                if (string.IsNullOrWhiteSpace(currStr)) continue;
                var comParam = Tokenizer.GetToken(currStr);

                if (comParam != null)
                {
                    FindCommand(comParam.Name)?.Execute(comParam.Param);
                }
            }
        }

        /// <summary>
        /// Поиск команды в словаре среди имени и его синонимов
        /// </summary>
        /// <param name="currCommand">Имя команды, заданное пользователем</param>
        /// <returns>Возвращает экземпляр класса команды</returns>
        private ICommand FindCommand(string currCommand)
        {
            currCommand = currCommand.ToLower();
            try
            {
                // Проверка наличия в словаре по имени
                if (AllComm.ContainsKey(currCommand))
                {
                    return AllComm[currCommand];
                }
                throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Команда '{0}' не найдена", currCommand);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
    }
}
