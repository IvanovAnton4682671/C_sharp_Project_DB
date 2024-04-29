using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Individual_work
{
    public partial class PIABOLUserControl : UserControl
    {
        //соединение с бд и работа с отображением данных
        public NpgsqlConnection conn;
        public System.Data.DataTable dtProductsInvoices = new System.Data.DataTable();
        public DataSet dsProductsInvoices = new DataSet();
        public System.Data.DataTable dtBillOfLanding = new System.Data.DataTable();
        public DataSet dsBillOfLanding = new DataSet();

        public PIABOLUserControl(NpgsqlConnection conn)
        {
            /*
             Функция-конструктор
             */

            InitializeComponent();
            this.conn = conn;
        }

        private void PIABOLUserControl_Load(object sender, EventArgs e)
        {
            /*
             Функция, которая отоюражает данные при загрузки панели
             */

            Update_ProductsInvoices();
            Update_BillOfLanding();
        }

        private void Update_ProductsInvoices()
        {
            /*
             Функция, которая перезагружает и показывает данные
             */

            dtProductsInvoices.Clear();
            string sqlProductsInvoices = @"
            SELECT * 
            FROM Products_invoices";
            NpgsqlDataAdapter daProductsInvoices = new NpgsqlDataAdapter(sqlProductsInvoices, conn);
            dsProductsInvoices.Reset();
            daProductsInvoices.Fill(dsProductsInvoices);
            dtProductsInvoices = dsProductsInvoices.Tables[0];
            dataGridViewProductsInvoices.DataSource = null;
            dataGridViewProductsInvoices.DataSource = dtProductsInvoices;
            dataGridViewProductsInvoices.Columns[0].HeaderText = "Номер";
            dataGridViewProductsInvoices.Columns[1].HeaderText = "Номер продукта";
            dataGridViewProductsInvoices.Columns[2].HeaderText = "Номер поставщика";
            dataGridViewProductsInvoices.Columns[3].HeaderText = "Кол-во товара";
            dataGridViewProductsInvoices.Sort(dataGridViewProductsInvoices.Columns["product_invoice_id"], ListSortDirection.Ascending);
            dataGridViewProductsInvoices.Refresh();
            //делаем ширину колонок подходящей под содержимое
            foreach (DataGridViewColumn column in dataGridViewProductsInvoices.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void Update_BillOfLanding()
        {
            /*
             Функция, которая перезагружает и показывает данные
             */

            dtBillOfLanding.Clear();
            string sqlBillOfLanding = @"
            SELECT * 
            FROM Bill_of_landing";
            NpgsqlDataAdapter daBillOfLanding = new NpgsqlDataAdapter(sqlBillOfLanding, conn);
            dsBillOfLanding.Reset();
            daBillOfLanding.Fill(dsBillOfLanding);
            dtBillOfLanding = dsBillOfLanding.Tables[0];
            dataGridViewBillOfLanding.DataSource = null;
            dataGridViewBillOfLanding.DataSource = dtBillOfLanding;
            dataGridViewBillOfLanding.Columns[0].HeaderText = "Номер";
            dataGridViewBillOfLanding.Columns[1].HeaderText = "Номер товарной накладной";
            dataGridViewBillOfLanding.Columns[2].HeaderText = "Общая стоимость";
            dataGridViewBillOfLanding.Columns[3].HeaderText = "Дата получения";
            dataGridViewBillOfLanding.Columns[4].HeaderText = "Статус платежа";
            dataGridViewBillOfLanding.Sort(dataGridViewBillOfLanding.Columns["bill_of_landing_id"], ListSortDirection.Ascending);
            dataGridViewBillOfLanding.Refresh();
            //делаем ширину колонок подходящей под содержимое
            foreach (DataGridViewColumn column in dataGridViewBillOfLanding.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void buttonAddProductsInvoices_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая получает нужные данные и вызывает форму для вставки данных
             */

            List<String> productsNames = new List<String>();
            string sql = @"
            SELECT product_name 
            FROM Products";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string productName = reader.GetString(0);
                productsNames.Add(productName);
            }
            reader.Close();

            List<String> providersNames = new List<String>();
            sql = @"
            SELECT provider_name 
            FROM Providers";
            command = new NpgsqlCommand(sql, conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string providerName = reader.GetString(0);
                providersNames.Add(providerName);
            }
            reader.Close();

            ProductsInvoicesForm productsInvoicesForm = new ProductsInvoicesForm(conn, productsNames, providersNames);
            productsInvoicesForm.ShowDialog();
            Update_ProductsInvoices();
            Update_BillOfLanding();
        }

        private void buttonChangeProductsInvoices_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая получает нужные данные и вызывает форму для редактирования данных
             */

            int productInvoiceId = (int)dataGridViewProductsInvoices.CurrentRow.Cells["product_invoice_id"].Value;
            int productId = (int)dataGridViewProductsInvoices.CurrentRow.Cells["product_id"].Value;
            int providerId = (int)dataGridViewProductsInvoices.CurrentRow.Cells["provider_id"].Value;
            int productQuantity = (int)dataGridViewProductsInvoices.CurrentRow.Cells["product_quantity"].Value;

            string sql = @"
            SELECT product_name 
            FROM Products 
            WHERE product_id = :product_id";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("product_id", productId);
            object productNameObj = command.ExecuteScalar();
            string productName = Convert.ToString(productNameObj);

            sql = @"
            SELECT provider_name 
            FROM Providers 
            WHERE provider_id = :provider_id";
            command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("provider_id", providerId);
            object providerNameObj = command.ExecuteScalar();
            string providerName = Convert.ToString(providerNameObj);

            List<String> productsNames = new List<String>();
            sql = @"
            SELECT product_name 
            FROM Products";
            command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tmpProductName = reader.GetString(0);
                productsNames.Add(tmpProductName);
            }
            reader.Close();

            List<String> providersNames = new List<String>();
            sql = @"
            SELECT provider_name 
            FROM Providers";
            command = new NpgsqlCommand(sql, conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string tmpProviderName = reader.GetString(0);
                providersNames.Add(tmpProviderName);
            }
            reader.Close();

            ProductsInvoicesForm productInvoicesForm = new ProductsInvoicesForm(conn, productInvoiceId, productName, providerName, productQuantity, productsNames, providersNames);
            productInvoicesForm.ShowDialog();
            Update_ProductsInvoices();
            Update_BillOfLanding();
        }

        private void buttonDeleteProductsInvoices_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая удаляет данные без вызова формы
             */

            int productInvoiceId = (int)dataGridViewProductsInvoices.CurrentRow.Cells["product_invoice_id"].Value;
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись с номером " + productInvoiceId + "?\nЭто автоматически удалит соответствующую запись из таблицы транспортных накладных!", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = @"
                DELETE FROM Products_invoices 
                WHERE product_invoice_id = :product_invoice_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                command.Parameters.AddWithValue("product_invoice_id", productInvoiceId);
                command.ExecuteNonQuery();
                Update_ProductsInvoices();
                Update_BillOfLanding();
            }
        }

        private void buttonSelectProductsInvoices_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая отображает транспортную накладную для выбранной товарной накладной
             */

            int productInvoiceId = (int)dataGridViewProductsInvoices.CurrentRow.Cells["product_invoice_id"].Value;
            dtBillOfLanding.Clear();
            string sql = @"
            SELECT * 
            FROM Bill_of_landing 
            WHERE product_invoice_id = " + productInvoiceId;
            NpgsqlDataAdapter daBillOfLanding = new NpgsqlDataAdapter(sql, conn);
            dsBillOfLanding.Reset();
            daBillOfLanding.Fill(dsBillOfLanding);
            dtBillOfLanding = dsBillOfLanding.Tables[0];
            dataGridViewBillOfLanding.DataSource = null;
            dataGridViewBillOfLanding.DataSource = dtBillOfLanding;
            dataGridViewBillOfLanding.Columns[0].HeaderText = "Номер";
            dataGridViewBillOfLanding.Columns[1].HeaderText = "Номер товарной накладной";
            dataGridViewBillOfLanding.Columns[2].HeaderText = "Общая стоимость";
            dataGridViewBillOfLanding.Columns[3].HeaderText = "Дата получения";
            dataGridViewBillOfLanding.Columns[4].HeaderText = "Статус платежа";
            dataGridViewBillOfLanding.Sort(dataGridViewBillOfLanding.Columns["bill_of_landing_id"], ListSortDirection.Ascending);
            dataGridViewBillOfLanding.Refresh();
        }

        private void buttonShowAllProductsInvoices_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая перезагружает и показывает данные
             */

            Update_ProductsInvoices();
        }

        private void buttonChangeBillOfLanding_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая получает нужные данные и вызывает форму для редактирования данных
             */

            int billOfLandingId = (int)dataGridViewBillOfLanding.CurrentRow.Cells["bill_of_landing_id"].Value;
            DateTime dateOfReceipt;
            try
            {
                dateOfReceipt = (DateTime)dataGridViewBillOfLanding.CurrentRow.Cells["date_of_receipt"].Value;
            }
            catch (Exception ex)
            {
                dateOfReceipt = DateTime.Today;
            }
            string paymentStatus = (string)dataGridViewBillOfLanding.CurrentRow.Cells["payment_status"].Value;
            BillOfLandingForm billOfLandingForm = new BillOfLandingForm(conn, billOfLandingId, dateOfReceipt, paymentStatus);
            billOfLandingForm.ShowDialog();
            Update_BillOfLanding();
        }

        private void buttonDeleteBillOfLanding_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая удаляет данные без вызова формы
             */

            int billOfLandingId = (int)dataGridViewBillOfLanding.CurrentRow.Cells["bill_of_landing_id"].Value;
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить запись с номером " + billOfLandingId + "?\nЭто автоматически удалит соответствующую запись из таблицы товарных накладных!", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = @"
                DELETE FROM Bill_of_landing 
                WHERE bill_of_landing_id = :billOfLandingId";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                command.Parameters.AddWithValue("billOfLandingId", billOfLandingId);
                command.ExecuteNonQuery();
                Update_ProductsInvoices();
                Update_BillOfLanding();
            }
        }

        private void buttonSelectBillOfLanding_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая отображает товарную накладную для выбранной транспортной накладной
             */

            int productInvoicesId = (int)dataGridViewBillOfLanding.CurrentRow.Cells["product_invoice_id"].Value;
            dtProductsInvoices.Clear();
            string sql = @"
            SELECT * 
            FROM Products_invoices 
            WHERE product_invoice_id = " + productInvoicesId;
            NpgsqlDataAdapter daProductsInvoices = new NpgsqlDataAdapter(sql, conn);
            dsProductsInvoices.Reset();
            daProductsInvoices.Fill(dsProductsInvoices);
            dtProductsInvoices = dsProductsInvoices.Tables[0];
            dataGridViewProductsInvoices.DataSource = null;
            dataGridViewProductsInvoices.DataSource = dtProductsInvoices;
            dataGridViewProductsInvoices.Columns[0].HeaderText = "Номер";
            dataGridViewProductsInvoices.Columns[1].HeaderText = "Номер продукта";
            dataGridViewProductsInvoices.Columns[2].HeaderText = "Номер поставщика";
            dataGridViewProductsInvoices.Columns[3].HeaderText = "Кол-во товара";
            dataGridViewProductsInvoices.Sort(dataGridViewProductsInvoices.Columns["product_invoice_id"], ListSortDirection.Ascending);
            dataGridViewProductsInvoices.Refresh();
        }

        private void buttonShowAllBillOfLanding_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая перезагружает и показывает данные
             */

            Update_BillOfLanding();
        }

        private void buttonExportToExcel_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая экспортирует данные о транспортных накладных в созданный Excel-файл
             */

            dtProductsInvoices.Clear();
            string sql = @"
            SELECT b.bill_of_landing_id, p.product_name, pr.provider_name, pi.product_quantity, b.total_price, b.date_of_receipt, b.payment_status 
            FROM Bill_of_landing b 
            JOIN Products_invoices pi 
            ON b.product_invoice_id = pi.product_invoice_id 
            JOIN Products p 
            ON pi.product_id = p.product_id     
            JOIN Providers pr 
            ON pi.provider_id = pr.provider_id";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            dsProductsInvoices.Reset();
            da.Fill(dsProductsInvoices);
            dtProductsInvoices = dsProductsInvoices.Tables[0];

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            string filename = ofd.FileName;
            Microsoft.Office.Interop.Excel.Application excelObj = new Microsoft.Office.Interop.Excel.Application();
            excelObj.Visible = true;
            Workbook wb = excelObj.Workbooks.Open(filename, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Worksheet wsh = wb.Sheets[1];
            List<string> listInfo = new List<string> { "Номер товарно-транспортной накладной", "Наименование продукта", "Наименование поставщика", "Количество продукта", "Общая стоимость", "Дата получения", "Статус платежа" };
            for (int i = 0; i < listInfo.Count; i++)
            {
                wsh.Cells[1, i + 1] = listInfo[i];
            }
            try
            {
                for (int row = 0; row < dtProductsInvoices.Columns.Count; row++)
                {
                    DataRow dr = dtProductsInvoices.Rows[row];
                    for (int col = 0; col < dtProductsInvoices.Columns.Count; col++)
                    {
                        wsh.Cells[row + 2, col + 1] = dr[col].ToString();
                    }
                }
            }
            catch (Exception ex) { }
            Update_ProductsInvoices();
            Update_BillOfLanding();
        }
    }
}
