using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppBD.BDConns
{
    //Подключение к БД разными средствами
    [SupportedOSPlatform("windows")]
    class BD
    {
        protected OdbcConnection connection;
        protected OleDbConnection connection1;
        //Создание подключения ODBC
        public void CreateConnectODBC()
        {
            string MyConString = "DRIVER={MySQL ODBC 8.3 UNICODE Driver};" +
            "SERVER=localhost;" +
            "DATABASE=kurenkov;" +
            "User=root;" +
            "PASSWORD=SaraParker206;" +
            "OPTION=3";
            connection = new OdbcConnection(MyConString); 
        }
        //Создание подключения OleDB
        public void CreateConnectOleDB()
        {
            string MyConString = "Provider=sqloledb; Data Source=DESKTOP-K8K6ELV\\ROOT; Initial Catalog=KurenkovAlex;Integrated Security=SSPI;";
            connection1 = new OleDbConnection(MyConString);
        }
        //Открытие и Закрытие потоков запросов ODBD and OleDB
        protected void OpenODBC(){connection.Open();}
        protected void CloseODBC(){connection.Close();}
        protected void OpenOleDB(){connection1.Open();}
        protected void CloseOleDB(){connection1.Close();}
    }
}
