using System;
using System.Collections.Generic;
using System.Linq;
using Secondlab;

namespace FirstLab
{
    public static class Tokenizer
    {
        public static Token GetToken(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                    return null;
                var currListComm =
                    str.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
                var commandName = currListComm.First();
                currListComm.RemoveAt(0);
                
                return new Token(commandName, currListComm);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
    }
}