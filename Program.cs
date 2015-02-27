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

    class DBConnect
    {
        public MySqlConnection myConn;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string port;
        private string data;

        public DBConnect()
        {
            Init();
            //Connect();
        }

        public void Init()
        {
            server = "127.0.0.1";
            database = "test";
            port = "3306";
            uid = "root";
            password = "root";
            //string myConnection = "server=127.0.0.1;uid=root;" + "pwd=root;database=test2;";
            string myConnection = "datasource=" + server + ";" + "port=" + port + ";" + "username=" + uid + ";" + "password=" + password + ";" + "database=" + database + ";";
            myConn = new MySqlConnection(myConnection);

            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
            myDataAdapter.SelectCommand = new MySqlCommand(" select* database.edata ;", myConn);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
        }

        public bool Connect()
        {
            try
            {
                Console.WriteLine("Connecting to MySQL database...");
                myConn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Disconnect()
        {
            try
            {
                Console.WriteLine("Disconnecting from MySQL database...");
                myConn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public void AddMySQL()
        {
            //AUTO_INCREMENT!
            //...hmm tworzyc tutaj tabele, sprawdzac if not null? czy w workbenchu...
            Console.Write("Add:");
            data = Console.ReadLine();
            string query = "INSERT INTO test.lololo (data) VALUES('" + data + "')";

            if (this.Connect() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, myConn);
                Console.WriteLine("Add successful");
                cmd.ExecuteNonQuery();
                this.Disconnect();
            }
            
        }

        public void DelMySQL()
        {

            Console.Write("Del ... where id:");
            data = Console.ReadLine();
            string query = "DELETE FROM test.lololo WHERE id='" + data + "';";


            if (this.Connect() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, myConn);
                Console.WriteLine("DEL successful");
                cmd.ExecuteNonQuery();
                this.Disconnect();
            }
        }

        public void ShowMySQL()
        {
            string query = "select * from test.lololo;";

            if (this.Connect() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, myConn);

                Console.WriteLine("TEST KUUUUURCZAKI");
                cmd.ExecuteNonQuery();
                this.Disconnect();
            }
        }

    }

    class Menu
    {
        static void Main()
        {
            int n;
            Program Ob_Program = new Program();
            DBConnect Ob_DbConnect = new DBConnect();

            do
            {
                Console.Write("\nMENU\n1. Add\n2. Del\n3. Sort A-Z\n4. Show\n5. Insert After pos\n------MySQL------\n6. Connect to MySQL database\n7. Disconnect MySQL\n8. Add to MySQL\n9. Del from MySQL\n10. Show MySQL Database\nChoose: ");
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
                    case 6: Ob_DbConnect.Connect();
                        break;
                    case 7: Ob_DbConnect.Disconnect();
                        break;
                    case 8: Ob_DbConnect.AddMySQL();
                        break;
                    case 9: Ob_DbConnect.DelMySQL();
                        break;
                    case 10: Ob_DbConnect.ShowMySQL();
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
            this.Show();
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

    }

}
