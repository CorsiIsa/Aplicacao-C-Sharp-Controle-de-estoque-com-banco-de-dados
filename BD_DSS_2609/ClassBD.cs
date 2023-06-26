using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace BD_DSS_2609
{
    class ClassBD
    {
        string con = "server=127.0.0.1;" +
                    "user id=root;" +
                    "pwd='master';" +
                    "database=produto";

        private MySqlConnection AbreBanco()
        {
            MySqlConnection ocon = new MySqlConnection();
            ocon.ConnectionString = this.con;
            ocon.Open();
            return ocon;
        }

        private void FechaBanco(MySqlConnection ocon)
        {
            if (ocon.State == ConnectionState.Open)
            {
                ocon.Close();
            }
        }

        public MySqlDataReader RetornaDataSet(string strQuery)
        {
            MySqlConnection ocon = new MySqlConnection();
            MySqlCommand cmdComando = new MySqlCommand();
            try
            {
                ocon = AbreBanco();
                cmdComando.CommandText = strQuery;
                cmdComando.CommandType = CommandType.Text;
                cmdComando.Connection = ocon;
                return cmdComando.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }
    }
}
