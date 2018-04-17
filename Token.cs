using System.Collections.Generic;
using Secondlab;

namespace FirstLab
{
    /// <summary>
    /// Команда в удобном для исполнителя виде
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Название команды
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Параметры команды
        /// </summary>
        public List<string> Param { get; }

        public Token(string name, List<string> param)
        {
            Name = name;
            Param = param;
        }
    }
}
