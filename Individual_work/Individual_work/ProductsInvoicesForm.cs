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
    public partial class ProductsInvoicesForm : Form
    {
        //соединение с бд и поля записей
        public NpgsqlConnection conn;
        public int productInvoiceId = -1;
        public string productName;
        public string providerName;
        public int productQuantity;
        public List<String> productsNames;
        public List<String> providersNames;

        public ProductsInvoicesForm(NpgsqlConnection conn, List<String> productsNames, List<String> providersNames)
        {
            /*
             Функция-конструктор для вставки данных
             */

            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.conn = conn;
            this.productsNames = productsNames;
            this.providersNames = providersNames;
            this.comboBoxProductsNames.DataSource = productsNames;
            this.comboBoxProvidersNames.DataSource = providersNames;
        }

        public ProductsInvoicesForm(NpgsqlConnection conn, int productInvoiceId, string productName, string providerName, int productQuantity, List<String> productsNames, List<String> providersNames)
        {
            /*
             Функция-конструктор для изменения данных
             */

            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.conn = conn;
            this.productInvoiceId = productInvoiceId;
            this.productName = productName;
            this.providerName = providerName;
            this.productQuantity = productQuantity;
            this.productsNames = productsNames;
            this.providersNames = providersNames;
            this.comboBoxProductsNames.DataSource = productsNames;
            this.comboBoxProvidersNames.DataSource = providersNames;
            this.textBoxProductQuantity.Text = productQuantity.ToString();
        }

        private void ProductsInvoicesForm_Load(object sender, EventArgs e)
        {
            /*
             Функция, которая загружает содержимое в комбоБоксы при загрузки формы
             */

            this.comboBoxProductsNames.SelectedItem = productName;
            this.comboBoxProvidersNames.SelectedItem = providerName;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая подтверждает вставку/изменение данных
             */

            //для вставки
            if (this.productInvoiceId == -1)
            {
                int res;
                if (comboBoxProductsNames.SelectedItem != null && comboBoxProvidersNames.SelectedItem != null && int.TryParse(textBoxProductQuantity.Text, out res))
                {
                    DialogResult result = MessageBox.Show("Вы действительно хотите добавить новые данные? Это приведёт к автоматическому созданию соответствующей записи в таблице транспортных накладных!", "Подтверждение добавления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string sql = @"
                    SELECT product_id 
                    FROM Products 
                    WHERE product_name = :product_name";
                        NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                        command.Parameters.AddWithValue("product_name", comboBoxProductsNames.SelectedItem.ToString());
                        object productIdObj = command.ExecuteScalar();
                        int productId = Convert.ToInt32(productIdObj);

                        sql = @"
                    SELECT provider_id 
                    FROM Providers 
                    WHERE provider_name = :provider_name";
                        command = new NpgsqlCommand(sql, conn);
                        command.Parameters.AddWithValue("provider_name", comboBoxProvidersNames.SelectedItem.ToString());
                        object providerIdObj = command.ExecuteScalar();
                        int providerId = Convert.ToInt32(providerIdObj);

                        sql = @"
                    INSERT 
                    INTO Products_invoices (product_id, provider_id, product_quantity) 
                    VALUES (:product_id, :provider_id, :product_quantity)";
                        command = new NpgsqlCommand(sql, conn);
                        command.Parameters.AddWithValue("product_id", productId);
                        command.Parameters.AddWithValue("provider_id", providerId);
                        command.Parameters.AddWithValue("product_quantity", int.Parse(this.textBoxProductQuantity.Text));
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
                DialogResult result = MessageBox.Show("Вы действительно хотите изменить данные в записи с номером " + this.productInvoiceId + "? Это приведёт к автоматическому изменению соответствующей записи в таблице транспортных накладных!", "Подтверждение добавления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string sql = @"
                    SELECT product_id 
                    FROM Products 
                    WHERE product_name = :product_name";
                    NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                    command.Parameters.AddWithValue("product_name", comboBoxProductsNames.SelectedItem.ToString());
                    object productIdObj = command.ExecuteScalar();
                    int productId = Convert.ToInt32(productIdObj);

                    sql = @"
                    SELECT provider_id 
                    FROM Providers 
                    WHERE provider_name = :provider_name";
                    command = new NpgsqlCommand(sql, conn);
                    command.Parameters.AddWithValue("provider_name", comboBoxProvidersNames.SelectedItem.ToString());
                    object providerIdObj = command.ExecuteScalar();
                    int providerId = Convert.ToInt32(providerIdObj);

                    sql = @"
                    UPDATE Products_invoices 
                    SET product_id = :product_id, provider_id = :provider_id, product_quantity = :product_quantity 
                    WHERE product_invoice_id = :product_invoice_id";
                    command = new NpgsqlCommand(sql, conn);
                    command.Parameters.AddWithValue("product_invoice_id", this.productInvoiceId);
                    command.Parameters.AddWithValue("product_id", productId);
                    command.Parameters.AddWithValue("provider_id", providerId);
                    command.Parameters.AddWithValue("product_quantity", int.Parse(this.textBoxProductQuantity.Text));
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
