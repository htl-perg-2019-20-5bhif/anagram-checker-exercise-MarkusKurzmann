using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnagramCheckerLib.Services
{
    class AnagramConverter : IAnagramConverter
    {
        public IEnumerable<IEnumerable<string>> transformToArray(string file)
        {
            List<List<string>> anagramList = new List<List<string>>();

            var anagrams = file.Replace("\r", string.Empty).Split("\n");

            foreach(var anagram in anagrams)
            {
                if (anagram != null)
                {
                    IEnumerable<string> words = anagram.Split(";");
                    anagramList.Add(words.ToList());
                }
                
            }
            return anagramList;
        }
    }
}
