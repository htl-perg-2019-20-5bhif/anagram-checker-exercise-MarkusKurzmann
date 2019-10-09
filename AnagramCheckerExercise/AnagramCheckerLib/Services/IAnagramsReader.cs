using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnagramCheckerLib.Services
{
    public interface IAnagramsReader
    {

        public Task<string> ReadFileAsync();

    }
}
