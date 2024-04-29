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
    public partial class ProductsUserControl : UserControl
    {
        //соединение с бд и работа с отображением данных
        public NpgsqlConnection conn;
        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();

        public ProductsUserControl(NpgsqlConnection conn)
        {
            /*
             Функция-конструктор
             */

            InitializeComponent();
            this.conn = conn;
        }

        private void ProductsUserControl_Load(object sender, EventArgs e)
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
            FROM Products";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView.DataSource = dt;
            dataGridView.Columns[0].HeaderText = "Номер";
            dataGridView.Columns[1].HeaderText = "Наименование";
            dataGridView.Columns[2].HeaderText = "Единицы измерения";
            dataGridView.Columns[3].HeaderText = "Стоимость";
            dataGridView.Sort(dataGridView.Columns["product_id"], ListSortDirection.Ascending);
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

            ProductsForm productsForm = new ProductsForm(conn);
            productsForm.ShowDialog();
            Update();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая вызывает форму для редактирования данных
             */

            int productId = (int)dataGridView.CurrentRow.Cells["product_id"].Value;
            string productName = (string)dataGridView.CurrentRow.Cells["product_name"].Value.ToString();
            string productMeasurementUnit = (string)dataGridView.CurrentRow.Cells["product_measurement_unit"].Value.ToString();
            int productPrice = (int)dataGridView.CurrentRow.Cells["product_price"].Value;
            ProductsForm productsForm = new ProductsForm(conn, productId, productName, productMeasurementUnit, productPrice);
            productsForm.ShowDialog();
            Update();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая удаляет данные без вызова формы
             */

            int productId = (int)dataGridView.CurrentRow.Cells["product_id"].Value;
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись с номером " + productId + "?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = @"
                DELETE 
                FROM Products 
                WHERE product_id = :product_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                command.Parameters.AddWithValue("product_id", productId);
                command.ExecuteNonQuery();
                Update();
            }
        }
    }
}
