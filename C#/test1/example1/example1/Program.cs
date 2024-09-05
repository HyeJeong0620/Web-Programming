using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "-al")
            {
                Console.WriteLine("-al을 검색합니다");
            }
            else if (args[0] == "-a")
            {
                Console.WriteLine("-a을 검색합니다");
            }
        }
    }
}
