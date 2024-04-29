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
    public partial class ProvidersForm : Form
    {
        //соединение с бд и поля записей
        public NpgsqlConnection conn;
        public int providerId = -1;
        public string providerName;

        public ProvidersForm(NpgsqlConnection conn)
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

        public ProvidersForm(NpgsqlConnection conn, int providerId, string providerName)
        {
            /*
             Функция-конструктор для изменения данных
             */

            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.conn = conn;
            this.providerId = providerId;
            this.providerName = providerName;
            textBoxName.Text = providerName;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая подтверждает вставку/изменение данных
             */

            //для вставки
            if (this.providerId == -1)
            {
                if (textBoxName.Text != "")
                {
                    DialogResult result = MessageBox.Show("Вы действительно хотите добавить новые данные?", "Подтверждение добавления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string sql = @"
                    INSERT 
                    INTO Providers (provider_name) 
                    VALUES (:provider_name)";
                        NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                        command.Parameters.AddWithValue("provider_name", textBoxName.Text);
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
                DialogResult result = MessageBox.Show("Вы действительно хотите изменить данные в записи с номером " + this.providerId + "?", "Подтверждение изменения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string sql = @"
                    UPDATE Providers 
                    SET provider_name = :provider_name 
                    WHERE provider_id = :provider_id";
                    NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                    command.Parameters.AddWithValue("provider_id", this.providerId);
                    command.Parameters.AddWithValue("provider_name", textBoxName.Text);
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
