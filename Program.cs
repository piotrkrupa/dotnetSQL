using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listtest
{
    class Program
    {
        static void Main()
        {
            List<string> list = new List<string>();

            int temp_halt = 0;
            do
            {
                Console.WriteLine("number of elements : {0}", list.Count);
                list.Add(Console.ReadLine());
                Console.WriteLine("CONTINUE TYPING? 0:YES 1:NO");
                var success = Int32.TryParse(Console.ReadLine(), out temp_halt); //to jest konwersja!!!
            } while (temp_halt == 0);

            /*foreach (int dana in list)
            {Console.WriteLine(dana);}*/

            Console.WriteLine("/nLIST:");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, list[i]);
            }
            Console.ReadLine();
        }
    }

    /*class WriteRead
    {
        string tekst;

        public void Wczytaj()
        {
            Console.WriteLine("Podaj napis: ");
            tekst = Console.ReadLine();
        }
        public void Napisz()
        {
            Console.WriteLine("Oto co napisales: ");
            Console.WriteLine(tekst);
        }
    }

    class Program
    {
        static void Main()
        {
            WriteRead obiekt_WR = new WriteRead();
            obiekt_WR.Wczytaj();
            obiekt_WR.Napisz();
            Console.ReadLine();

            
            List<int>
        }
    }*/
}
