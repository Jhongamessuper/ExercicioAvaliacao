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
    public partial class ContasReceber : Form
    {
        public ContasReceber()
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
                        string sql = "insert into Contas (Nome, Descricao, Valor, Pago_Recebido, DataVencimento, DataConclusao, Tipo) values ('" + txtNome.Text + "', '" + txtDescricao.Text + "', '" + txtValor.Text + "', '" + cbRecebido.Text + "','" + Globals.DataNova + "','" + Globals.DataNova + "','" + cbRecebido.Text + "','" + 1 + "')";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            mostrar();
            limpar();
        }

        private void dgwContasReceber_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pegaData();
            if (dgwContasReceber.CurrentRow.Index != -1)
            {
                txtIdContasReceber.Text = dgwContasReceber.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = dgwContasReceber.CurrentRow.Cells[1].Value.ToString();
                txtDescricao.Text = dgwContasReceber.CurrentRow.Cells[2].Value.ToString();
                txtValor.Text = dgwContasReceber.CurrentRow.Cells[3].Value.ToString();
                cbRecebido.Text = dgwContasReceber.CurrentRow.Cells[4].Value.ToString();
                dtpDataVencimento.Value = Convert.ToDateTime(dgwContasReceber.CurrentRow.Cells[5].Value.ToString());
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
                    string sql = "Select * from Contas";
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
        }

        void limpar()
        {
            txtIdContasReceber.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtValor.Text = "";
            cbRecebido.Text = "";
            dtpDataVencimento.Text = "";
            btnInserir.Text = "INSERIR";
            btnDeletar.Visible = false;
            btnAlterar.Visible = false;
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
                        string sql = "Delete from ContasReceber where idContasReceber = '" + txtIdContasReceber.Text + "'";
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
                        string sql = "Update ContasReceber set Nome='" + txtNome.Text + "', Descricao='" + txtDescricao.Text + "', Valor='" + txtValor.Text + "', Pago_Recebido='" + cbRecebido.Text + "', DataVencimento='" + Globals.DataNova + "' where idAgenda ='" + txtIdContasReceber.Text + "'";
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
}
