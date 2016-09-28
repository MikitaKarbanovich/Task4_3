using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix();
            matrix.ReadFromFile();
            matrix.Multiplay();
            matrix.ReusltOutput();
            Console.ReadKey();
        }

    }
}
