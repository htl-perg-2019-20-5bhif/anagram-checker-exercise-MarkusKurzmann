using AnagramCheckerLib.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnagramCheckerLib
{
    public class AnagramChecker
    {
        private readonly AnagramsFileReader reader;
        private readonly AnagramConverter converter;
        private IEnumerable<IEnumerable<string>> anagrams;

        public AnagramChecker()
        {
            this.reader = new AnagramsFileReader();
            this.converter = new AnagramConverter();
        }

        public async void initiateAnagramChecker() {

            string filecontent = await reader.ReadFileAsync();

            this.anagrams = this.converter.transformToArray(filecontent);


        }

        public string compareAnagrams(string word1, string word2)
        {
            bool retVal = false;
            foreach(List<string> anagramWords in this.anagrams)
            {
                int hits = 0;
                foreach(string singleWord in anagramWords)
                {
                    if (singleWord.Equals(word1) || singleWord.Equals(word2)) {
                        hits++;
                    };
                }

                if(hits == 2) {
                    retVal = true;
                }
                else
                {
                    hits = 0;
                    continue;
                }
            }
            if (retVal)
            {
                return "\"" + word1 + "\"" + " and " + "\"" + word2 + "\"" + " are anagrams";
            }
            else
            {
                return "\"" + word1 + "\"" + " and " + "\"" + word2 + "\"" + " are no anagrams";
            }
        }

        public string getKnownAnagrams(string word)
        {
            
            foreach (List<string> anagramWords in this.anagrams)
            {
                string retString = "";
                foreach (string singleWord in anagramWords)
                {
                    if (singleWord.Equals(word))
                    {
                        string ret = "";
                        foreach(string w in anagramWords)
                        {
                            ret += w + "\n";
                        }
                        ret.TrimEnd('\n');
                        return ret;
                    };
                }

            }
            return "No known anagrams found";
        }
    }
}
