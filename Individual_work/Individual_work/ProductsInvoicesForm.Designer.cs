namespace Individual_work
{
    partial class ProductsInvoicesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelProductName = new Label();
            labelProviderName = new Label();
            labelProductQuantity = new Label();
            comboBoxProductsNames = new ComboBox();
            comboBoxProvidersNames = new ComboBox();
            textBoxProductQuantity = new TextBox();
            buttonConfirm = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelProductName
            // 
            labelProductName.AutoSize = true;
            labelProductName.Location = new Point(62, 59);
            labelProductName.Name = "labelProductName";
            labelProductName.Size = new Size(202, 23);
            labelProductName.TabIndex = 0;
            labelProductName.Text = "Наименование товара";
            // 
            // labelProviderName
            // 
            labelProviderName.AutoSize = true;
            labelProviderName.Location = new Point(62, 119);
            labelProviderName.Name = "labelProviderName";
            labelProviderName.Size = new Size(246, 23);
            labelProviderName.TabIndex = 1;
            labelProviderName.Text = "Наименование поставщика";
            // 
            // labelProductQuantity
            // 
            labelProductQuantity.AutoSize = true;
            labelProductQuantity.Location = new Point(62, 179);
            labelProductQuantity.Name = "labelProductQuantity";
            labelProductQuantity.Size = new Size(174, 23);
            labelProductQuantity.TabIndex = 2;
            labelProductQuantity.Text = "Количество товара";
            // 
            // comboBoxProductsNames
            // 
            comboBoxProductsNames.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProductsNames.FormattingEnabled = true;
            comboBoxProductsNames.Location = new Point(62, 85);
            comboBoxProductsNames.Name = "comboBoxProductsNames";
            comboBoxProductsNames.Size = new Size(246, 31);
            comboBoxProductsNames.TabIndex = 3;
            // 
            // comboBoxProvidersNames
            // 
            comboBoxProvidersNames.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProvidersNames.FormattingEnabled = true;
            comboBoxProvidersNames.Location = new Point(62, 145);
            comboBoxProvidersNames.Name = "comboBoxProvidersNames";
            comboBoxProvidersNames.Size = new Size(246, 31);
            comboBoxProvidersNames.TabIndex = 4;
            // 
            // textBoxProductQuantity
            // 
            textBoxProductQuantity.Location = new Point(62, 205);
            textBoxProductQuantity.Name = "textBoxProductQuantity";
            textBoxProductQuantity.Size = new Size(246, 29);
            textBoxProductQuantity.TabIndex = 5;
            // 
            // buttonConfirm
            // 
            buttonConfirm.AutoSize = true;
            buttonConfirm.Location = new Point(62, 240);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(131, 33);
            buttonConfirm.TabIndex = 6;
            buttonConfirm.Text = "Подтвердить";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.AutoSize = true;
            buttonCancel.Location = new Point(204, 240);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(104, 33);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Отменить";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // ProductsInvoicesForm
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 353);
            Controls.Add(buttonCancel);
            Controls.Add(buttonConfirm);
            Controls.Add(textBoxProductQuantity);
            Controls.Add(comboBoxProvidersNames);
            Controls.Add(comboBoxProductsNames);
            Controls.Add(labelProductQuantity);
            Controls.Add(labelProviderName);
            Controls.Add(labelProductName);
            Font = new Font("Microsoft YaHei UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ProductsInvoicesForm";
            Text = "Товарная накладная";
            Load += ProductsInvoicesForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelProductName;
        private Label labelProviderName;
        private Label labelProductQuantity;
        private ComboBox comboBoxProductsNames;
        private ComboBox comboBoxProvidersNames;
        private TextBox textBoxProductQuantity;
        private Button buttonConfirm;
        private Button buttonCancel;
    }
}