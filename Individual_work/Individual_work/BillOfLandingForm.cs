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
    public partial class BillOfLandingForm : Form
    {
        //соединение с бд и поля записей
        public NpgsqlConnection conn;
        public int billOfLandingId;
        public DateTime dateOfReceipt;
        public string paymentStatus;

        public BillOfLandingForm(NpgsqlConnection conn, int billOfLandingId, DateTime dateOfReceipt, string paymentStatus)
        {
            /*
             Функция-конструктор для изменения данных
             */

            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.conn = conn;
            this.billOfLandingId = billOfLandingId;
            this.dateOfReceipt = dateOfReceipt;
            this.paymentStatus = paymentStatus;
            this.dateTimePicker.Value = dateOfReceipt;
            this.comboBox.SelectedItem = paymentStatus;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая подтверждает изменение данных
             */

            DialogResult result = MessageBox.Show("Вы действительно хотите изменить данные в записи с номером " + this.billOfLandingId + "?", "Подтверждение добавления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = @"
                UPDATE Bill_of_landing 
                SET date_of_receipt = :date_of_receipt, payment_status = :payment_status 
                WHERE bill_of_landing_id = :bill_of_landing_id";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                command.Parameters.AddWithValue("bill_of_landing_id", this.billOfLandingId);
                command.Parameters.AddWithValue("date_of_receipt", dateTimePicker.Value);
                command.Parameters.AddWithValue("payment_status", comboBox.SelectedItem.ToString());
                command.ExecuteNonQuery();
                Close();
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
