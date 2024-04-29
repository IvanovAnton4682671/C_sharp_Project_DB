using Npgsql;

namespace Individual_work
{
    public partial class MainForm : Form
    {
        //все используемые панели
        public ProductsUserControl productsUserControl;
        public ProvidersUserControl providersUserControl;
        public PIABOLUserControl pIABOLUserControl;
        public ReportingUserControl reportingUserControl;

        //объект-соединение с бд
        public NpgsqlConnection conn;

        public MainForm()
        {
            /*
             Функция-конструктор
             */

            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            Connection();
            LoadUserControls();
        }

        public void Connection()
        {
            /*
             Функция, отвечающая за установку и открытие соеднинения с бд
             */

            string connData = @"
            Server=localhost; 
            Port=5432; 
            UserID=postgres; 
            Password=postpass; 
            Database=C#_Ivanov_Anton_Individual_work_Shop";
            conn = new NpgsqlConnection(connData);
            conn.Open();
        }

        public void CenterUserControl(Control control)
        {
            /*
             Функция, которая центрирует панель для корректного отображения внутри формы
             */

            int newX = (this.ClientSize.Width - control.Width) / 2;
            int newY = (this.ClientSize.Height - control.Height) / 2;
            control.Location = new Point(newX, newY);
        }

        public void LoadUserControls()
        {
            /*
             Функция, которая инициализирует все панели перед началом использования
             */

            productsUserControl = new ProductsUserControl(conn);
            this.Controls.Add(productsUserControl);
            CenterUserControl(productsUserControl);
            productsUserControl.Visible = false;

            providersUserControl = new ProvidersUserControl(conn);
            this.Controls.Add(providersUserControl);
            CenterUserControl(providersUserControl);
            providersUserControl.Visible = false;

            pIABOLUserControl = new PIABOLUserControl(conn);
            this.Controls.Add(pIABOLUserControl);
            CenterUserControl(pIABOLUserControl);
            pIABOLUserControl.Visible = false;

            /*
             Для панели с отчётностью нужно заранее загрузить и передать все нужные данные, потому что
             эта панель фактически является формой (при её создании сразу нужно отображать данные)
             */
            List<String> providersNames = new List<String>();
            string sql = @"
            SELECT provider_name 
            FROM Providers";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string providerName = reader.GetString(0);
                providersNames.Add(providerName);
            }
            reader.Close();
            string[] providersNamesArr = providersNames.ToArray();

            List<String> productsNames = new List<String>();
            sql = @"
            SELECT product_name 
            FROM Products";
            command = new NpgsqlCommand(sql, conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string productName = reader.GetString(0);
                productsNames.Add(productName);
            }
            reader.Close();
            string[] productsNamesArr = productsNames.ToArray();

            reportingUserControl = new ReportingUserControl(conn, providersNamesArr, productsNamesArr);
            this.Controls.Add(reportingUserControl);
            CenterUserControl(reportingUserControl);
            reportingUserControl.Visible = false;
        }

        private void ProductsStripMenu_Click(object sender, EventArgs e)
        {
            /*
             Функция для корректного отображения панели "Продукты"
             */

            productsUserControl.Visible = true;
            providersUserControl.Visible = false;
            pIABOLUserControl.Visible = false;
            reportingUserControl.Visible = false;
        }

        private void ProvidersStripMenu_Click(object sender, EventArgs e)
        {
            /*
             Функция для корректного отображения панели "Поставщики"
             */

            providersUserControl.Visible = true;
            productsUserControl.Visible = false;
            pIABOLUserControl.Visible = false;
            reportingUserControl.Visible = false;
        }

        private void PIABOLStripMenu_Click(object sender, EventArgs e)
        {
            /*
             Функция для корректного отображения панели с накладными
             */

            pIABOLUserControl.Visible = true;
            productsUserControl.Visible = false;
            providersUserControl.Visible = false;
            reportingUserControl.Visible = false;
        }

        private void ReportingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
             Функция, которая переинициализирует панель при повторном открытии, так как могут появиться
             новые данные, которые нужно будет заного получить и передать
             */

            List<String> providersNames = new List<String>();
            string sql = @"
            SELECT provider_name 
            FROM Providers";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string providerName = reader.GetString(0);
                providersNames.Add(providerName);
            }
            reader.Close();
            string[] providersNamesArr = providersNames.ToArray();

            List<String> productsNames = new List<String>();
            sql = @"
            SELECT product_name 
            FROM Products";
            command = new NpgsqlCommand(sql, conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string productName = reader.GetString(0);
                productsNames.Add(productName);
            }
            reader.Close();
            string[] productsNamesArr = productsNames.ToArray();

            reportingUserControl = new ReportingUserControl(conn, providersNamesArr, productsNamesArr);
            this.Controls.Add(reportingUserControl);
            CenterUserControl(reportingUserControl);

            reportingUserControl.Visible = true;
            productsUserControl.Visible = false;
            providersUserControl.Visible = false;
            pIABOLUserControl.Visible = false;
        }
    }
}
