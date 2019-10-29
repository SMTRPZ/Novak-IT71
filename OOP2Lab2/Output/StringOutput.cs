using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIL.Output
{
    public class StringOutput:IOutput
    {

        public void Print(string str)
        {
            Console.WriteLine(str);
        }
    }
}
