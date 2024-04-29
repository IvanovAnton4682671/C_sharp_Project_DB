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
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace Individual_work
{
    public partial class ReportingUserControl : UserControl
    {
        //соединение с бд и данные для листБоксов
        public NpgsqlConnection conn;
        public string[] providersNames;
        public string[] productsNames;

        public ReportingUserControl(NpgsqlConnection conn, string[] providersNames, string[] productsNames)
        {
            /*
             Функция-конструктор
             */

            InitializeComponent();
            this.conn = conn;
            this.providersNames = providersNames;
            this.productsNames = productsNames;
            this.checkedListBoxReportProvidersNames.Items.AddRange(providersNames);
            this.checkedListBoxReportProductsNames.Items.AddRange(productsNames);
        }

        private void buttonReportProviders_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая создаёт отчёт по поставщикам (указывает оборот и общую неоплаченную сумму)
             */

            DateTime reportProvidersFrom = dateTimePickerReportProvidersFrom.Value;
            DateTime reportProvidersTo = dateTimePickerReportProvidersTo.Value;
            List<string> providersNamesChecked = new List<string>();
            for (int i = 0; i < checkedListBoxReportProvidersNames.CheckedItems.Count; i++)
            {
                providersNamesChecked.Add(checkedListBoxReportProvidersNames.CheckedItems[i].ToString());
            }

            string result = "----------\n";
            result += "Отчётность за период с " + reportProvidersFrom + " по " + reportProvidersTo + "\n";
            result += "----------\n";

            //получаем все номера товарных накладных, для которых транспортные накладные укладываются во временной промежуток
            string sql = @"
            SELECT 
            DISTINCT product_invoice_id 
            FROM Bill_of_landing 
            WHERE DATE(date_of_receipt) >= DATE(:reportProvidersFrom) 
            AND DATE(date_of_receipt) <= DATE(:reportProvidersTo)";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("reportProvidersFrom", reportProvidersFrom);
            command.Parameters.AddWithValue("reportProvidersTo", reportProvidersTo);
            NpgsqlDataReader reader = command.ExecuteReader();
            List<int> productsInvoicesIds = new List<int>();
            while (reader.Read())
            {
                int productInvoiceId = reader.GetInt32(0);
                productsInvoicesIds.Add(productInvoiceId);
            }
            reader.Close();

            List<Tuple<string, int, int>> resultData = new List<Tuple<string, int, int>>();
            foreach (string providerName in providersNamesChecked)
            {
                int totalPaid = 0;
                int totalUnpaid = 0;
                foreach (int productInvoiceId in productsInvoicesIds)
                {
                    //получаем данные о поставщике и товарной накладной
                    sql = @"
                    SELECT bol.total_price, bol.payment_status 
                    FROM Bill_of_landing bol 
                    JOIN Products_invoices pi 
                    ON bol.product_invoice_id = pi.product_invoice_id 
                    JOIN Providers prov 
                    ON pi.provider_id = prov.provider_id 
                    WHERE pi.product_invoice_id = :productInvoiceId 
                    AND prov.provider_name = :providerName";
                    command = new NpgsqlCommand(sql, conn);
                    command.Parameters.AddWithValue("productInvoiceId", productInvoiceId);
                    command.Parameters.AddWithValue("providerName", providerName);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int totalPrice = reader.GetInt32(0);
                        string paymentStatus = reader.GetString(1);
                        if (paymentStatus == "Оплачено")
                            totalPaid += totalPrice;
                        else
                            totalUnpaid += totalPrice;
                    }
                    reader.Close();
                }
                resultData.Add(Tuple.Create(providerName, totalPaid, totalUnpaid));
            }
            for (int i = 0; i < resultData.Count; i++)
            {
                result += "----------\n";
                result += "Поставщик: " + resultData[i].Item1 + "\n";
                result += "Общий оборот: " + resultData[i].Item2 + "\n";
                result += "Общая неоплаченная сумма: " + resultData[i].Item3 + "\n";
                result += "----------\n";
            }
            richTextBoxReportProviders.Text = result;
        }

        private void buttonReportProducts_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                 Функция, которая получает все данные для постройки графика по дням для выбранных товаров
                 (указывает неоплаченные суммы) и вызывает форму для показа графика
                 */

                DateTime reportProductsFrom = dateTimePickerReportProductsFrom.Value;
                DateTime reportProductsTo = dateTimePickerReportProductsTo.Value;
                List<string> productsNamesChecked = new List<string>();
                for (int i = 0; i < checkedListBoxReportProductsNames.CheckedItems.Count; i++)
                {
                    productsNamesChecked.Add(checkedListBoxReportProductsNames.CheckedItems[i].ToString());
                }

                //собираем все названия товаров в строку для использования в SQL-запросе с параметром IN
                string productsNamesString = string.Join(",", productsNamesChecked.Select(p => $"'{p}'"));

                //запрос на получение данных
                string sql = @"
            SELECT bol.date_of_receipt, prod.product_name, bol.total_price 
            FROM Bill_of_landing bol 
            JOIN Products_invoices pi 
            ON bol.product_invoice_id = pi.product_invoice_id
            JOIN Products prod 
            ON prod.product_id = pi.product_id
            WHERE DATE(bol.date_of_receipt) >= DATE(:reportProductsFrom)
            AND DATE(bol.date_of_receipt) <= DATE(:reportProductsTo)
            AND prod.product_name 
            IN (" + productsNamesString + @") 
            AND bol.payment_status != 'Оплачено'";

                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                command.Parameters.AddWithValue("reportProductsFrom", reportProductsFrom);
                command.Parameters.AddWithValue("reportProductsTo", reportProductsTo);
                //command.Parameters.AddWithValue("productsNames", productsNamesString); //автоматическое преобразование типов не смогло корректно интрерпретировать список имён товаров
                NpgsqlDataReader reader = command.ExecuteReader();

                //собираем результаты в список
                List<Tuple<DateTime, string, int>> resultData = new List<Tuple<DateTime, string, int>>();
                while (reader.Read())
                {
                    DateTime date = reader.GetDateTime(0);
                    string productName = reader.GetString(1);
                    int totalPrice = reader.GetInt32(2);
                    resultData.Add(Tuple.Create(date, productName, totalPrice));
                }
                reader.Close();

                ChartForm chartForm = new ChartForm(productsNamesChecked, resultData);
                chartForm.ShowDialog();
            }
            catch (Exception ex) { }
        }
    }
}
