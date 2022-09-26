using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioAvaliacao
{
    public partial class ControleContas : Form
    {
        public ControleContas()
        {
            InitializeComponent();
            mostrar();
        }

        private void btnContasPagar_Click(object sender, EventArgs e)
        {
            ContasPagar contasPagar = new ContasPagar();
            //contasPagar.MdiParent = this;
            contasPagar.Show();
        }

        private void btnContasReceber_Click(object sender, EventArgs e)
        {
            ContasReceber contasreceber = new ContasReceber();
            //contasreceber.MdiParent = this;
            contasreceber.Show();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "Select idContas, Nome, Descricao, Valor, DataVencimento, Pago_Recebido, Tipo from Contas ";
                        DataTable table = new DataTable();
                        MySqlDataAdapter adpter = new MySqlDataAdapter(sql, cnn);
                        adpter.Fill(table);
                        dgwContasPagar.DataSource = table;
                        dgwContasPagar.AutoGenerateColumns = false;
                        dgwContasReceber.DataSource = table;
                        dgwContasReceber.AutoGenerateColumns = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "Update Contas set Tipo='" + 1 + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Atualizado com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                mostrarPagar();
            }
        }

        private void btnReceber_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection cnn = new MySqlConnection())
                {
                    cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306;Convert Zero DateTime = true";
                    cnn.Open();
                    string sql = "update contas set pago_recebido = 1 where tipo = 'Conta_a_Receber'";
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            mostrarReceber();
        }

        void mostrarReceber()
        {
            try
            {
                using (MySqlConnection cnn = new MySqlConnection())
                {
                    cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306;Convert Zero DateTime = true";
                    cnn.Open();
                    string sql = "Select idContas, Nome, Descricao, Valor, DataVencimento, Pago_Recebido, Tipo from Contas where pago_recebido = 0 and tipo = 'Conta para receber'";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(sql, cnn);
                    adpter.Fill(table);
                    dgwContasReceber.DataSource = table;
                    dgwContasReceber.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            void mostrarPagar()
            {
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "Select idContas, Nome, Descricao, Valor, DataVencimento, Pago_Recebido, Tipo from Contas where pago_recebido = 0 and tipo = 'Conta para pagar'";
                        DataTable table = new DataTable();
                        MySqlDataAdapter adpter = new MySqlDataAdapter(sql, cnn);
                        adpter.Fill(table);
                        dgwContasPagar.DataSource = table;
                        dgwContasPagar.AutoGenerateColumns = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
