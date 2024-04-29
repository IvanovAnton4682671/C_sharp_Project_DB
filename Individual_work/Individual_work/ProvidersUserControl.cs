using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Individual_work
{
    public partial class ProvidersUserControl : UserControl
    {
        //соединение с бд и работа с отображением данных
        public NpgsqlConnection conn;
        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();

        public ProvidersUserControl(NpgsqlConnection conn)
        {
            /*
             Функция-конструктор
             */

            InitializeComponent();
            this.conn = conn;
        }

        private void ProvidersUserControl_Load(object sender, EventArgs e)
        {
            /*
             Функция, которая отоюражает данные при загрузки панели
             */

            Update();
        }

        private void Update()
        {
            /*
             Функция, которая перезагружает и показывает данные
             */

            dt.Clear();
            string sql = @"
            SELECT * 
            FROM Providers";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView.DataSource = dt;
            dataGridView.Columns[0].HeaderText = "Номер";
            dataGridView.Columns[1].HeaderText = "Наименование";
            dataGridView.Sort(dataGridView.Columns["provider_id"], ListSortDirection.Ascending);
            dataGridView.Refresh();
            //делаем ширину колонок подходящей под содержимое
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая вызывает форму для вставки данных
             */

            ProvidersForm providersForm = new ProvidersForm(conn);
            providersForm.ShowDialog();
            Update();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая вызывает форму для редактирования данных
             */

            int providerId = (int)dataGridView.CurrentRow.Cells["provider_id"].Value;
            string providerName = (string)dataGridView.CurrentRow.Cells["provider_name"].Value.ToString();
            ProvidersForm providersForm = new ProvidersForm(conn, providerId, providerName);
            providersForm.ShowDialog();
            Update();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая удаляет данные без вызова формы
             */

            int providerId = (int)dataGridView.CurrentRow.Cells["provider_id"].Value;
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись с номером " + providerId + "?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = @"
                DELETE 
                FROM Providers 
                WHERE provider_id = :provider_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                command.Parameters.AddWithValue("provider_id", providerId);
                command.ExecuteNonQuery();
                Update();
            }
        }
    }
}
