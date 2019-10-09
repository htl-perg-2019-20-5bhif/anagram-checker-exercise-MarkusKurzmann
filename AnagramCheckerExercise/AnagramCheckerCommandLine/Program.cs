using AnagramCheckerLib;
using System;

namespace AnagramCheckerCommandLine
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            AnagramChecker acl = new AnagramChecker();
            acl.initiateAnagramChecker();

            if(args.Length == 3 && args[0].Equals("check"))
            {
                string word1 = args[1];
                string word2 = args[2];
                Console.WriteLine(acl.compareAnagrams(word1, word2));
            }
            else if(args[0].Equals("getKnown")){
                string word = args[1];
                Console.WriteLine(acl.getKnownAnagrams(word));
            }

            
        }
    }
}
