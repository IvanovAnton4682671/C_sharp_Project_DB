namespace Individual_work
{
    partial class PIABOLUserControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            labelTitleProductsInvoices = new Label();
            dataGridViewProductsInvoices = new DataGridView();
            buttonAddProductsInvoices = new Button();
            buttonChangeProductsInvoices = new Button();
            buttonDeleteProductsInvoices = new Button();
            dataGridViewBillOfLanding = new DataGridView();
            labelTitleBillOfLanding = new Label();
            buttonChangeBillOfLanding = new Button();
            buttonSelectProductsInvoices = new Button();
            buttonShowAllBillOfLanding = new Button();
            buttonShowAllProductsInvoices = new Button();
            buttonSelectBillOfLanding = new Button();
            buttonDeleteBillOfLanding = new Button();
            buttonExportToExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductsInvoices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBillOfLanding).BeginInit();
            SuspendLayout();
            // 
            // labelTitleProductsInvoices
            // 
            labelTitleProductsInvoices.AutoSize = true;
            labelTitleProductsInvoices.Location = new Point(420, 7);
            labelTitleProductsInvoices.Name = "labelTitleProductsInvoices";
            labelTitleProductsInvoices.Size = new Size(192, 23);
            labelTitleProductsInvoices.TabIndex = 0;
            labelTitleProductsInvoices.Text = "Товарные накладные";
            // 
            // dataGridViewProductsInvoices
            // 
            dataGridViewProductsInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductsInvoices.Location = new Point(4, 33);
            dataGridViewProductsInvoices.Name = "dataGridViewProductsInvoices";
            dataGridViewProductsInvoices.RowHeadersWidth = 51;
            dataGridViewProductsInvoices.Size = new Size(992, 180);
            dataGridViewProductsInvoices.TabIndex = 1;
            // 
            // buttonAddProductsInvoices
            // 
            buttonAddProductsInvoices.AutoSize = true;
            buttonAddProductsInvoices.Location = new Point(4, 219);
            buttonAddProductsInvoices.Name = "buttonAddProductsInvoices";
            buttonAddProductsInvoices.Size = new Size(102, 33);
            buttonAddProductsInvoices.TabIndex = 2;
            buttonAddProductsInvoices.Text = "Добавить";
            buttonAddProductsInvoices.UseVisualStyleBackColor = true;
            buttonAddProductsInvoices.Click += buttonAddProductsInvoices_Click;
            // 
            // buttonChangeProductsInvoices
            // 
            buttonChangeProductsInvoices.AutoSize = true;
            buttonChangeProductsInvoices.Location = new Point(112, 219);
            buttonChangeProductsInvoices.Name = "buttonChangeProductsInvoices";
            buttonChangeProductsInvoices.Size = new Size(104, 33);
            buttonChangeProductsInvoices.TabIndex = 3;
            buttonChangeProductsInvoices.Text = "Изменить";
            buttonChangeProductsInvoices.UseVisualStyleBackColor = true;
            buttonChangeProductsInvoices.Click += buttonChangeProductsInvoices_Click;
            // 
            // buttonDeleteProductsInvoices
            // 
            buttonDeleteProductsInvoices.AutoSize = true;
            buttonDeleteProductsInvoices.Location = new Point(222, 219);
            buttonDeleteProductsInvoices.Name = "buttonDeleteProductsInvoices";
            buttonDeleteProductsInvoices.Size = new Size(94, 33);
            buttonDeleteProductsInvoices.TabIndex = 4;
            buttonDeleteProductsInvoices.Text = "Удалить";
            buttonDeleteProductsInvoices.UseVisualStyleBackColor = true;
            buttonDeleteProductsInvoices.Click += buttonDeleteProductsInvoices_Click;
            // 
            // dataGridViewBillOfLanding
            // 
            dataGridViewBillOfLanding.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBillOfLanding.Location = new Point(4, 278);
            dataGridViewBillOfLanding.Name = "dataGridViewBillOfLanding";
            dataGridViewBillOfLanding.RowHeadersWidth = 51;
            dataGridViewBillOfLanding.Size = new Size(992, 180);
            dataGridViewBillOfLanding.TabIndex = 5;
            // 
            // labelTitleBillOfLanding
            // 
            labelTitleBillOfLanding.AutoSize = true;
            labelTitleBillOfLanding.Location = new Point(361, 252);
            labelTitleBillOfLanding.Name = "labelTitleBillOfLanding";
            labelTitleBillOfLanding.Size = new Size(310, 23);
            labelTitleBillOfLanding.TabIndex = 6;
            labelTitleBillOfLanding.Text = "Товарно-транспортные накладные";
            // 
            // buttonChangeBillOfLanding
            // 
            buttonChangeBillOfLanding.AutoSize = true;
            buttonChangeBillOfLanding.Location = new Point(4, 464);
            buttonChangeBillOfLanding.Name = "buttonChangeBillOfLanding";
            buttonChangeBillOfLanding.Size = new Size(104, 33);
            buttonChangeBillOfLanding.TabIndex = 7;
            buttonChangeBillOfLanding.Text = "Изменить";
            buttonChangeBillOfLanding.UseVisualStyleBackColor = true;
            buttonChangeBillOfLanding.Click += buttonChangeBillOfLanding_Click;
            // 
            // buttonSelectProductsInvoices
            // 
            buttonSelectProductsInvoices.AutoSize = true;
            buttonSelectProductsInvoices.Location = new Point(766, 219);
            buttonSelectProductsInvoices.Name = "buttonSelectProductsInvoices";
            buttonSelectProductsInvoices.Size = new Size(94, 33);
            buttonSelectProductsInvoices.TabIndex = 8;
            buttonSelectProductsInvoices.Text = "Выбрать";
            buttonSelectProductsInvoices.UseVisualStyleBackColor = true;
            buttonSelectProductsInvoices.Click += buttonSelectProductsInvoices_Click;
            // 
            // buttonShowAllBillOfLanding
            // 
            buttonShowAllBillOfLanding.AutoSize = true;
            buttonShowAllBillOfLanding.Location = new Point(866, 464);
            buttonShowAllBillOfLanding.Name = "buttonShowAllBillOfLanding";
            buttonShowAllBillOfLanding.Size = new Size(130, 33);
            buttonShowAllBillOfLanding.TabIndex = 9;
            buttonShowAllBillOfLanding.Text = "Показать все";
            buttonShowAllBillOfLanding.UseVisualStyleBackColor = true;
            buttonShowAllBillOfLanding.Click += buttonShowAllBillOfLanding_Click;
            // 
            // buttonShowAllProductsInvoices
            // 
            buttonShowAllProductsInvoices.AutoSize = true;
            buttonShowAllProductsInvoices.Location = new Point(866, 219);
            buttonShowAllProductsInvoices.Name = "buttonShowAllProductsInvoices";
            buttonShowAllProductsInvoices.Size = new Size(130, 33);
            buttonShowAllProductsInvoices.TabIndex = 10;
            buttonShowAllProductsInvoices.Text = "Показать все";
            buttonShowAllProductsInvoices.UseVisualStyleBackColor = true;
            buttonShowAllProductsInvoices.Click += buttonShowAllProductsInvoices_Click;
            // 
            // buttonSelectBillOfLanding
            // 
            buttonSelectBillOfLanding.AutoSize = true;
            buttonSelectBillOfLanding.Location = new Point(766, 464);
            buttonSelectBillOfLanding.Name = "buttonSelectBillOfLanding";
            buttonSelectBillOfLanding.Size = new Size(94, 33);
            buttonSelectBillOfLanding.TabIndex = 11;
            buttonSelectBillOfLanding.Text = "Выбрать";
            buttonSelectBillOfLanding.UseVisualStyleBackColor = true;
            buttonSelectBillOfLanding.Click += buttonSelectBillOfLanding_Click;
            // 
            // buttonDeleteBillOfLanding
            // 
            buttonDeleteBillOfLanding.AutoSize = true;
            buttonDeleteBillOfLanding.Location = new Point(114, 464);
            buttonDeleteBillOfLanding.Name = "buttonDeleteBillOfLanding";
            buttonDeleteBillOfLanding.Size = new Size(94, 33);
            buttonDeleteBillOfLanding.TabIndex = 12;
            buttonDeleteBillOfLanding.Text = "Удалить";
            buttonDeleteBillOfLanding.UseVisualStyleBackColor = true;
            buttonDeleteBillOfLanding.Click += buttonDeleteBillOfLanding_Click;
            // 
            // buttonExportToExcel
            // 
            buttonExportToExcel.AutoSize = true;
            buttonExportToExcel.Location = new Point(420, 464);
            buttonExportToExcel.Name = "buttonExportToExcel";
            buttonExportToExcel.Size = new Size(152, 33);
            buttonExportToExcel.TabIndex = 13;
            buttonExportToExcel.Text = "Экспорт в Excel";
            buttonExportToExcel.UseVisualStyleBackColor = true;
            buttonExportToExcel.Click += buttonExportToExcel_Click;
            // 
            // PIABOLUserControl
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonExportToExcel);
            Controls.Add(buttonDeleteBillOfLanding);
            Controls.Add(buttonSelectBillOfLanding);
            Controls.Add(buttonShowAllProductsInvoices);
            Controls.Add(buttonShowAllBillOfLanding);
            Controls.Add(buttonSelectProductsInvoices);
            Controls.Add(buttonChangeBillOfLanding);
            Controls.Add(labelTitleBillOfLanding);
            Controls.Add(dataGridViewBillOfLanding);
            Controls.Add(buttonDeleteProductsInvoices);
            Controls.Add(buttonChangeProductsInvoices);
            Controls.Add(buttonAddProductsInvoices);
            Controls.Add(dataGridViewProductsInvoices);
            Controls.Add(labelTitleProductsInvoices);
            Font = new Font("Microsoft YaHei UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "PIABOLUserControl";
            Size = new Size(1000, 500);
            Load += PIABOLUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductsInvoices).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBillOfLanding).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitleProductsInvoices;
        private DataGridView dataGridViewProductsInvoices;
        private Button buttonAddProductsInvoices;
        private Button buttonChangeProductsInvoices;
        private Button buttonDeleteProductsInvoices;
        private DataGridView dataGridViewBillOfLanding;
        private Label labelTitleBillOfLanding;
        private Button buttonChangeBillOfLanding;
        private Button buttonSelectProductsInvoices;
        private Button buttonShowAllBillOfLanding;
        private Button buttonShowAllProductsInvoices;
        private Button buttonSelectBillOfLanding;
        private Button buttonDeleteBillOfLanding;
        private Button buttonExportToExcel;
    }
}
