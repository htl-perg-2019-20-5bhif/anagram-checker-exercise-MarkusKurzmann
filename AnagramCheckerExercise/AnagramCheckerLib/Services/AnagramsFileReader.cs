using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AnagramCheckerLib.Services
{
    class AnagramsFileReader : IAnagramsReader
    {
        //private ILogger<AnagramChecker> logger;

        public AnagramsFileReader()
        {
            //this.logger = null;
        }

        public async Task<string> ReadFileAsync()
        {
            string dictionaryContent = "";
            try
            {
                // Read dict from file
                var dictFilename = AnagramCheckerLib.Properties.Resources.anagramFileName;
                dictionaryContent = await System.IO.File.ReadAllTextAsync(dictFilename);
            }
            catch (FileNotFoundException ex)
            {
                //logger.LogCritical("Anagram-File not found\n"+ex);
                Console.Error.WriteLine("Anagram-File not found!");
                throw;
            }

            return dictionaryContent;
        }
    }
}
