using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPatronesCoyotas.Singleton
{
    public class ConexionSingleton
    {
        //public string conexion, mensaje;
        //protected MySqlCommand command;
        //protected MySqlDataReader datareader;
        //protected MySqlDataAdapter dataadapter;

        protected static MySqlConnection connection;
        private ConexionSingleton(){}
        public static MySqlConnection GetConnection() 
        {
            if (connection == null) 
            {
                connection = new MySqlConnection("server=localhost; database=Test; Uid=root; pwd=Grafografito8");
            }
            return connection;
        }

    }
}
