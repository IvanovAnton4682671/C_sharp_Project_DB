namespace Individual_work
{
    partial class ProductsForm
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
            labelName = new Label();
            labelMeasurementUnit = new Label();
            labelPrice = new Label();
            textBoxName = new TextBox();
            textBoxMeasurementUnit = new TextBox();
            textBoxPrice = new TextBox();
            buttonConfirm = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(68, 67);
            labelName.Name = "labelName";
            labelName.Size = new Size(139, 23);
            labelName.TabIndex = 0;
            labelName.Text = "Наименование";
            // 
            // labelMeasurementUnit
            // 
            labelMeasurementUnit.AutoSize = true;
            labelMeasurementUnit.Location = new Point(68, 125);
            labelMeasurementUnit.Name = "labelMeasurementUnit";
            labelMeasurementUnit.Size = new Size(185, 23);
            labelMeasurementUnit.TabIndex = 1;
            labelMeasurementUnit.Text = "Единицы измерения";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(68, 183);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(54, 23);
            labelPrice.TabIndex = 2;
            labelPrice.Text = "Цена";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(68, 93);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(241, 29);
            textBoxName.TabIndex = 3;
            // 
            // textBoxMeasurementUnit
            // 
            textBoxMeasurementUnit.Location = new Point(68, 151);
            textBoxMeasurementUnit.Name = "textBoxMeasurementUnit";
            textBoxMeasurementUnit.Size = new Size(241, 29);
            textBoxMeasurementUnit.TabIndex = 4;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(68, 209);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(241, 29);
            textBoxPrice.TabIndex = 5;
            // 
            // buttonConfirm
            // 
            buttonConfirm.AutoSize = true;
            buttonConfirm.Location = new Point(68, 244);
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
            buttonCancel.Location = new Point(205, 244);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(104, 33);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Отменить";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 353);
            Controls.Add(buttonCancel);
            Controls.Add(buttonConfirm);
            Controls.Add(textBoxPrice);
            Controls.Add(textBoxMeasurementUnit);
            Controls.Add(textBoxName);
            Controls.Add(labelPrice);
            Controls.Add(labelMeasurementUnit);
            Controls.Add(labelName);
            Font = new Font("Microsoft YaHei UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ProductsForm";
            Text = "Товар";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private Label labelMeasurementUnit;
        private Label labelPrice;
        private TextBox textBoxName;
        private TextBox textBoxMeasurementUnit;
        private TextBox textBoxPrice;
        private Button buttonConfirm;
        private Button buttonCancel;
    }
}