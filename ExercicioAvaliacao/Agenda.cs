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
    public partial class Agenda : Form
    {
        public Agenda()
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
                        string sql = "insert into Agenda (Titulo, Hora, Data, Descricao) values ('" + txtTitulo.Text + "', '" + cmbHora.Text + "', '" + Globals.DataNova + "', '" + rtbDescricao.Text + "')";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            txtPesquisar.Clear();
            mostrar();
            limpar();
        }

        private void dgwAgenda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pegaData();
            if (dgwAgenda.CurrentRow.Index != -1)
            {
                txtIdAgenda.Text = dgwAgenda.CurrentRow.Cells[0].Value.ToString();
                txtTitulo.Text = dgwAgenda.CurrentRow.Cells[1].Value.ToString();
                cmbHora.Text = dgwAgenda.CurrentRow.Cells[2].Value.ToString();
                dtpData.Value = Convert.ToDateTime(dgwAgenda.CurrentRow.Cells[3].Value.ToString());
                rtbDescricao.Text = dgwAgenda.CurrentRow.Cells[4].Value.ToString();
                btnDeletar.Visible = true;
                btnAlterar.Visible = true;
                btnInserir.Text = "Novo";
                txtPesquisar.Clear();
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
                    string sql = "Select * from Agenda";
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(sql, cnn);
                    adpter.Fill(table);
                    dgwAgenda.DataSource = table;
                    dgwAgenda.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void limpar()
        {
            txtIdAgenda.Text = "";
            txtTitulo.Text = "";
            cmbHora.Text = "";
            dtpData.Text = "";
            rtbDescricao.Clear();
            btnInserir.Text = "INSERIR";
            btnDeletar.Visible = false;
            btnAlterar.Visible = false;
        }

        void verificaVazio()
        {
            if (txtTitulo.Text == "" || cmbHora.Text == "" || dtpData.Text == "")
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
            Globals.Data = dtpData.Value;
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
                        string sql = "Delete from agenda where idAgenda = '" + txtIdAgenda.Text + "'";
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
            txtPesquisar.Clear();
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
                        string sql = "Update Agenda set Titulo='" + txtTitulo.Text + "', Hora='" + cmbHora.Text + "', Data='" + Globals.DataNova + "', Descricao='" + rtbDescricao.Text + "' where idAgenda ='" + txtIdAgenda.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Atualizado com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                txtPesquisar.Clear();
                mostrar();
                verificaVazio();
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection cnn = new MySqlConnection())
                {
                    cnn.ConnectionString = "server=localhost;database=controle;uid=root;pwd=;port=3306;Convert Zero DateTime = true";
                    cnn.Open();
                    string sql;
                    sql = "Select * from Agenda where Titulo Like'" + txtPesquisar.Text + "%'";
                    MySqlCommand cmd = new MySqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    DataTable table = new DataTable();
                    MySqlDataAdapter adpter = new MySqlDataAdapter(sql, cnn);
                    adpter.Fill(table);
                    dgwAgenda.DataSource = table;
                    dgwAgenda.AutoGenerateColumns = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
