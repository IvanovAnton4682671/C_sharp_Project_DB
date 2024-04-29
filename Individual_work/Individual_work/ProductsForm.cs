using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Individual_work
{
    public partial class ProductsForm : Form
    {
        //соединение с бд и поля записей
        public NpgsqlConnection conn;
        public int productId = -1;
        public string productName;
        public string productMeasurementUnit;
        public int productPrice;

        public ProductsForm(NpgsqlConnection conn)
        {
            /*
             Функция-конструктор для вставки данных
             */

            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.conn = conn;
        }

        public ProductsForm(NpgsqlConnection conn, int productId, string productName, string productMeasurementUnit, int productPrice)
        {
            /*
             Функция-конструктор для изменения данных
             */

            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.conn = conn;
            this.productId = productId;
            this.productName = productName;
            this.productMeasurementUnit = productMeasurementUnit;
            this.productPrice = productPrice;
            textBoxName.Text = productName;
            textBoxMeasurementUnit.Text = productMeasurementUnit;
            textBoxPrice.Text = productPrice.ToString();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая подтверждает вставку/изменение данных
             */

            //для вставки
            if (this.productId == -1)
            {
                int res;
                if (textBoxName.Text != "" && textBoxMeasurementUnit.Text != "" && int.TryParse(textBoxPrice.Text, out res)) //интересный синтаксис проверки на int
                {
                    DialogResult result = MessageBox.Show("Вы действительно хотите добавить новые данные?", "Подтверждение добавления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string sql = @"
                    INSERT 
                    INTO Products (product_name, product_measurement_unit, product_price) 
                    VALUES (:product_name, :product_measurement_unit, :product_price)";
                        NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                        command.Parameters.AddWithValue("product_name", textBoxName.Text);
                        command.Parameters.AddWithValue("product_measurement_unit", textBoxMeasurementUnit.Text);
                        command.Parameters.AddWithValue("product_price", int.Parse(textBoxPrice.Text));
                        command.ExecuteNonQuery();
                        Close();
                    }
                }
                else
                    MessageBox.Show("Не удалось добавить запись!\nУбедитесь, что вы ввели все данные корректно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //для изменения
            else
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите изменить данные в записи с номером " + this.productId + "?", "Подтверждение изменения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string sql = @"
                    UPDATE Products 
                    SET product_name = :product_name, product_measurement_unit = :product_measurement_unit, product_price = :product_price 
                    WHERE product_id = :product_id";
                    NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                    command.Parameters.AddWithValue("product_id", this.productId);
                    command.Parameters.AddWithValue("product_name", textBoxName.Text);
                    command.Parameters.AddWithValue("product_measurement_unit", textBoxMeasurementUnit.Text);
                    command.Parameters.AddWithValue("product_price", int.Parse(textBoxPrice.Text));
                    command.ExecuteNonQuery();
                    Close();
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая корректно закрывает форму
             */

            DialogResult result = MessageBox.Show("Вы действительно хотите закрыть окно?", "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
