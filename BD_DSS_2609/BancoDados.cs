using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BD_DSS_2609
{
    public partial class BancoDados : Form
    {
        ClassBD bd = new ClassBD();
        MySqlDataReader objDados;
        StringBuilder strQuery = new StringBuilder();

        public BancoDados()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BancoDados_Load(object sender, EventArgs e)
        {
            btnLimpar_Click(sender, e);
            strQuery.Append("Select * from TabProd");
            objDados = bd.RetornaDataSet(strQuery.ToString());
            while (objDados.Read())
            {
                dataGridView1.Rows.Add(objDados["CodProd"].ToString(),
                                  objDados["NomeProd"].ToString(),
                                  objDados["DescProd"].ToString(),
                                  objDados["Valor"].ToString(),
                                  objDados["CodFor"].ToString());
            }
            if (!objDados.IsClosed)
            {
                objDados.Close();
                strQuery.Remove(0, strQuery.Length);
            }
        
    }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            BancoDados_Load(sender, e);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair da aplicação?",
                               "<<<< FINALIZANDO >>>>",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
