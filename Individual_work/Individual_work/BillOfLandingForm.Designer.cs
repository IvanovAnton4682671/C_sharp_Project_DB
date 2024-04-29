namespace Individual_work
{
    partial class BillOfLandingForm
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
            labelDateOfReceipt = new Label();
            labelPaymentStatus = new Label();
            dateTimePicker = new DateTimePicker();
            comboBox = new ComboBox();
            buttonConfirm = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelDateOfReceipt
            // 
            labelDateOfReceipt.AutoSize = true;
            labelDateOfReceipt.Location = new Point(81, 89);
            labelDateOfReceipt.Name = "labelDateOfReceipt";
            labelDateOfReceipt.Size = new Size(146, 23);
            labelDateOfReceipt.TabIndex = 0;
            labelDateOfReceipt.Text = "Дата получения";
            // 
            // labelPaymentStatus
            // 
            labelPaymentStatus.AutoSize = true;
            labelPaymentStatus.Location = new Point(81, 147);
            labelPaymentStatus.Name = "labelPaymentStatus";
            labelPaymentStatus.Size = new Size(140, 23);
            labelPaymentStatus.TabIndex = 1;
            labelPaymentStatus.Text = "Статус платежа";
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(81, 115);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(250, 29);
            dateTimePicker.TabIndex = 2;
            // 
            // comboBox
            // 
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[] { "Не оплачено", "Оплачено" });
            comboBox.Location = new Point(81, 173);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(250, 31);
            comboBox.TabIndex = 3;
            // 
            // buttonConfirm
            // 
            buttonConfirm.AutoSize = true;
            buttonConfirm.Location = new Point(81, 210);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(131, 33);
            buttonConfirm.TabIndex = 4;
            buttonConfirm.Text = "Подтвердить";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.AutoSize = true;
            buttonCancel.Location = new Point(227, 210);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(104, 33);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отменить";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // BillOfLandingForm
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 353);
            Controls.Add(buttonCancel);
            Controls.Add(buttonConfirm);
            Controls.Add(comboBox);
            Controls.Add(dateTimePicker);
            Controls.Add(labelPaymentStatus);
            Controls.Add(labelDateOfReceipt);
            Font = new Font("Microsoft YaHei UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "BillOfLandingForm";
            Text = "Товарно-транспортная накладная";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDateOfReceipt;
        private Label labelPaymentStatus;
        private DateTimePicker dateTimePicker;
        private ComboBox comboBox;
        private Button buttonConfirm;
        private Button buttonCancel;
    }
}