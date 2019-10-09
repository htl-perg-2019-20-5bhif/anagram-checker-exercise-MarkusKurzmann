using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramCheckerLib.Services
{
    interface IAnagramConverter
    {

        public IEnumerable<IEnumerable<string>> transformToArray(string file);

    }
}
