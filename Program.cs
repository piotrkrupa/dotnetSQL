using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace listtest
{
    public class Helper
    {
       public static List<string> list = new List<string>();   
    }

    class Menu
    {
        static void Main()
        {
            int n;
            Program Ob_Program = new Program();

            do
            {
                Console.Write("\nMENU\n1. Add\n2. Del\n3. Sort A-Z\n4. Show\n5. Insert After pos\n6. Connect to MySQL database\nChoose: ");
                var n_switch = Int32.TryParse(Console.ReadLine(), out n);
                Console.Write("\n");
                switch (n)
                {
                    case 1: Ob_Program.Add();
                        break;
                    case 2: Ob_Program.Del();
                        break;
                    case 3: Ob_Program.Sort();
                        break;
                    case 4: Ob_Program.Show();
                        break;
                    case 5: Ob_Program.Insert();
                        break;
                    case 6: Ob_Program.Connect();
                        break;
                    default:
                        break;
                }
            } while (n != 0);
 
        }
    }

    class Program
    {
        public void Add()
        {
            Console.Write("Add (List size: {0}): ", Helper.list.Count);
            Helper.list.Add(Console.ReadLine());
        }

        public void Del()
        {

            int deleteAtTemp = 0;
            Show();
            Console.Write("\nDelete at pos: ");
            var deleteAt = Int32.TryParse(Console.ReadLine(), out deleteAtTemp); //to jest konwersja!!!
            Console.WriteLine(deleteAtTemp);
            if (deleteAtTemp <= Helper.list.Count && deleteAtTemp > 0 )
            {
                Helper.list.RemoveAt(deleteAtTemp - 1);
            }else
            {
                Console.WriteLine("ty idioto...");
            }
        }

        public void Sort()
        {
            Console.WriteLine("\nAlphabetically sorting from A - Z ");
            Helper.list.Sort();
        }

        public void Show()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("LIST:");
            for (int i = 0; i < Helper.list.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, Helper.list[i]);
            }
            Console.WriteLine("-------------------\n");
            /*foreach (int dana in list)
            {Console.WriteLine(dana);}*/
        }

        public void Insert()
        {
            int insert;
            string insertString;
            Console.Write("\nInsert after pos: ");
            var insertAfter = Int32.TryParse(Console.ReadLine(), out insert);
            Console.Write("\nInsert: ");
            insertString = Console.ReadLine();
            Helper.list.Insert(insert, insertString);
        }

        public void Connect()
        {
            string myConnection = "datasource=localhost;port=3306;username=root;password=root";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
            myDataAdapter.SelectCommand = new MySqlCommand(" select * database.edata ;", myConn);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
            try
            {
                myConn.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //adsa
        }

    }

}
