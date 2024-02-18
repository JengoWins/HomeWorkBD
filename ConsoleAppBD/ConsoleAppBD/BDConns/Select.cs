using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Runtime.Versioning;


namespace ConsoleAppBD.BDConns
{
    [SupportedOSPlatform("windows")]
    class Select:BD
    {
        private string command;
        private DataSet dataSet;
        private DataTable table;

        //При создании генерируется запрос на вывод всей таблицы
        public Select()
        {
            command = "Select * from player";
        }
        //Вывод данных через подключение ODBC
        public void JodODBC()
        {
            Console.WriteLine("Start ODBD запрос");
            dataSet = new DataSet();
            table = new DataTable();
            
            
            OpenODBC();
            OdbcCommand commands = new OdbcCommand();
            commands.Connection = connection;
            commands.CommandText = command;
            OdbcDataAdapter adapter = new OdbcDataAdapter(command,connection);
            adapter.Fill(dataSet,"Table1");
            table = dataSet.Tables[0];
            ToPrints(table);
            CloseODBC();
        }
        //Вывод данных через подключение OleDB
        //В конце генерируется список строк, которые передаются к следующему методу, для обработки информации
        public void JobOleDB()
        {
            Console.WriteLine("Start OleBD запрос");
            dataSet = new DataSet();
            table = new DataTable();

            OpenOleDB();
            OleDbCommand commands = new OleDbCommand(command);
            commands.Connection = connection1;
            commands.CommandText = command;
            OleDbDataAdapter adapter = new OleDbDataAdapter(command, connection1);
            adapter.Fill(dataSet, "Table2");
            table = dataSet.Tables[0];
            ToPrints(table);
            CloseOleDB();
            //Переход на LINQ
            List <DataRow> list = table.AsEnumerable().ToList();
            JobLINQ(list);
        }
        //Работа с данными при помощи LINQ
        public void JobLINQ(List<DataRow> list)
        {
            //Вывод строки с Джонни
            var selection = from s in list where s.Field<string>("name") == "Jonny" select s.ItemArray;
            ToPrintLIQN(selection);
            //Вывод строки с Галактической мощи выше или равно 7 млн
            selection = from s in list where s.Field<Int32>("GP") >=7000000 select s.ItemArray;
            ToPrintLIQN(selection);
        }
        //Вывод данных запросов через OLeDB,LINQ,ODBC
        private void ToPrints(DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    Console.Write(table.Rows[i][j].ToString() + " ");
                }
                Console.WriteLine();
            }
        }
        private void ToPrintLIQN(IEnumerable<object[]> select)
        {
            Console.WriteLine();
            Console.WriteLine("Result LINQ");
            foreach (var s in select)
            {
                Console.WriteLine(s[0].ToString() + " " + s[1].ToString() + " " + s[2].ToString() + " ");
            }
            Console.WriteLine();
        }
        }
}
