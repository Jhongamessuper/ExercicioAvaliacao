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
    public partial class ContasPagar : Form
    {
        public ContasPagar()
        {
            InitializeComponent();
            mostrar();
            btnDeletar.Visible = false;
            btnAlterar.Visible = false;
        }
            string continua = "yes";
        private void btnInserir_Click(object sender, EventArgs e)
        {
            verificaVazio();
            pegaData();

            if (btnInserir.Text == "INSERIR" && continua == "yes")
            {
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306;Convert Zero DateTime = true";
                        cnn.Open();
                        MessageBox.Show("Inserido com sucesso!");
                        string sql = "insert into Contas (Nome, Descricao, Valor, DataVencimento, Pago_Recebido, Tipo) values ('" + txtNome.Text + "', '" + txtDescricao.Text + "', '" + txtValor.Text + "', '" + Globals.DataNova + "','" + cbPago.Text + "','" + "Conta para pagar" + "')";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            cbPago.Checked = true;
            mostrar();
            limpar();
        }

        private void dgwContasPagar_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pegaData();
            if (dgwContasPagar.CurrentRow.Index != -1)
            {
                txtIdContasPagar.Text = dgwContasPagar.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgwContasPagar.CurrentRow.Cells[1].Value.ToString();
                txtDescricao.Text = dgwContasPagar.CurrentRow.Cells[2].Value.ToString();
                txtValor.Text = dgwContasPagar.CurrentRow.Cells[3].Value.ToString();
                dtpDataVencimento.Value = Convert.ToDateTime(dgwContasPagar.CurrentRow.Cells[4].Value.ToString());
                cbPago.Text = dgwContasPagar.CurrentRow.Cells[5].Value.ToString();
                btnDeletar.Visible = true;
                btnAlterar.Visible = true;
                btnInserir.Text = "Novo";
            }
        }
        void mostrar()
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void limpar()
        {
            txtIdContasPagar.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtValor.Text = "";
            dtpDataVencimento.Text = "";
            cbPago.Text = "pago";
            btnInserir.Text = "INSERIR";
            btnDeletar.Visible = false;
            btnAlterar.Visible = false;
            cbPago.Checked = false;
        }

        void verificaVazio()
        {
            if (txtNome.Text == "" || txtValor.Text == "" || dtpDataVencimento.Text == "")
            {
                continua = "no";
                MessageBox.Show("Preencha todos os campos");
            }
            else
            {
                continua = "yes";
            }
        }

        void pegaData()
        {
            /*Ele vai criar uma variável data da classe dateTime que vai receber o valor do dtpData
            e depois vai criar uma variável string dataCurta que vai receber a data abreviada, depois
            ele vai criar um vetor de strings que irá ter uma variável vetData que vai receber dataCurta com
            o split() parapegar a  "/" separando depois vai criar uma variável dataNova string que vai receber
            vetData no vetor 2,1 e 0 com um "-" para separar*/
            Globals.Data = dtpDataVencimento.Value;
            string dataCurta = Globals.Data.ToShortDateString();
            string[] vetData = dataCurta.Split('/');
            Globals.DataNova = vetData[2] + "-" + vetData[1] + "-" + vetData[0];
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja realmente excluir", "Confirmação", MessageBoxButtons.YesNo))
            {
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "Delete from Contas where idContasPagar = '" + txtIdContasPagar.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(" Deletado com sucesso! ");
                    }
                    limpar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            mostrar();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Deseja realmente alterar", "Confirmação", MessageBoxButtons.YesNo))
            {
                try
                {
                    using (MySqlConnection cnn = new MySqlConnection())
                    {
                        cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306;Convert Zero DateTime = true";
                        cnn.Open();
                        string sql = "Update Contas set Nome='" + txtNome.Text + "', Descricao='" + txtDescricao.Text + "', Valor='" + txtValor.Text + "', DataVencimento='" + Globals.DataNova + "', DataConsolidacao='" + Globals.DataNova + "', Pago_Recebido ='" + cbPago.Text + "', Tipo='" + "Conta para pagar" + "' where idContasPagar ='" + txtIdContasPagar.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Atualizado com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                mostrar();
                verificaVazio();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection cnn = new MySqlConnection())
                {
                    cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306;Convert Zero DateTime = true";
                    cnn.Open();
                    string sql;
                    sql = "Select * from Contas'" + btnPesquisar.Text + "%'";
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
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
