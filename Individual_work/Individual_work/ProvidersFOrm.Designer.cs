namespace Individual_work
{
    partial class ProvidersForm
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
            textBoxName = new TextBox();
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
            // textBoxName
            // 
            textBoxName.Location = new Point(68, 93);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(241, 29);
            textBoxName.TabIndex = 1;
            // 
            // buttonConfirm
            // 
            buttonConfirm.AutoSize = true;
            buttonConfirm.Location = new Point(68, 128);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(131, 33);
            buttonConfirm.TabIndex = 2;
            buttonConfirm.Text = "Подтвердить";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.AutoSize = true;
            buttonCancel.Location = new Point(205, 128);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(104, 33);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Отменить";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // ProvidersForm
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 253);
            Controls.Add(buttonCancel);
            Controls.Add(buttonConfirm);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Font = new Font("Microsoft YaHei UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ProvidersForm";
            Text = "Поставщик";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private TextBox textBoxName;
        private Button buttonConfirm;
        private Button buttonCancel;
    }
}