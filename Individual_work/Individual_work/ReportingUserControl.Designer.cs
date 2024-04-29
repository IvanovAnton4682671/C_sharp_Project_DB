namespace Individual_work
{
    partial class ReportingUserControl
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
            labelReportProvidersTitle = new Label();
            labelReportProvidersFrom = new Label();
            labelReportProvidersTo = new Label();
            labelReportProvidersNames = new Label();
            dateTimePickerReportProvidersFrom = new DateTimePicker();
            dateTimePickerReportProvidersTo = new DateTimePicker();
            checkedListBoxReportProvidersNames = new CheckedListBox();
            richTextBoxReportProviders = new RichTextBox();
            buttonReportProviders = new Button();
            labelReportProductsTitle = new Label();
            labelReportProductsFrom = new Label();
            labelReportProductsTo = new Label();
            dateTimePickerReportProductsFrom = new DateTimePicker();
            dateTimePickerReportProductsTo = new DateTimePicker();
            labelReportProductsNames = new Label();
            checkedListBoxReportProductsNames = new CheckedListBox();
            buttonReportProducts = new Button();
            SuspendLayout();
            // 
            // labelReportProvidersTitle
            // 
            labelReportProvidersTitle.AutoSize = true;
            labelReportProvidersTitle.Location = new Point(3, 9);
            labelReportProvidersTitle.Name = "labelReportProvidersTitle";
            labelReportProvidersTitle.Size = new Size(207, 23);
            labelReportProvidersTitle.TabIndex = 0;
            labelReportProvidersTitle.Text = "Отчёт по поставщикам";
            // 
            // labelReportProvidersFrom
            // 
            labelReportProvidersFrom.AutoSize = true;
            labelReportProvidersFrom.Location = new Point(3, 32);
            labelReportProvidersFrom.Name = "labelReportProvidersFrom";
            labelReportProvidersFrom.Size = new Size(99, 23);
            labelReportProvidersFrom.TabIndex = 1;
            labelReportProvidersFrom.Text = "С периода";
            // 
            // labelReportProvidersTo
            // 
            labelReportProvidersTo.AutoSize = true;
            labelReportProvidersTo.Location = new Point(3, 90);
            labelReportProvidersTo.Name = "labelReportProvidersTo";
            labelReportProvidersTo.Size = new Size(103, 23);
            labelReportProvidersTo.TabIndex = 2;
            labelReportProvidersTo.Text = "По период";
            // 
            // labelReportProvidersNames
            // 
            labelReportProvidersNames.AutoSize = true;
            labelReportProvidersNames.Location = new Point(3, 148);
            labelReportProvidersNames.Name = "labelReportProvidersNames";
            labelReportProvidersNames.Size = new Size(219, 23);
            labelReportProvidersNames.TabIndex = 3;
            labelReportProvidersNames.Text = "Выбранные поставщики";
            // 
            // dateTimePickerReportProvidersFrom
            // 
            dateTimePickerReportProvidersFrom.Location = new Point(3, 58);
            dateTimePickerReportProvidersFrom.Name = "dateTimePickerReportProvidersFrom";
            dateTimePickerReportProvidersFrom.Size = new Size(250, 29);
            dateTimePickerReportProvidersFrom.TabIndex = 4;
            // 
            // dateTimePickerReportProvidersTo
            // 
            dateTimePickerReportProvidersTo.Location = new Point(3, 116);
            dateTimePickerReportProvidersTo.Name = "dateTimePickerReportProvidersTo";
            dateTimePickerReportProvidersTo.Size = new Size(250, 29);
            dateTimePickerReportProvidersTo.TabIndex = 5;
            // 
            // checkedListBoxReportProvidersNames
            // 
            checkedListBoxReportProvidersNames.FormattingEnabled = true;
            checkedListBoxReportProvidersNames.Location = new Point(3, 174);
            checkedListBoxReportProvidersNames.Name = "checkedListBoxReportProvidersNames";
            checkedListBoxReportProvidersNames.Size = new Size(250, 100);
            checkedListBoxReportProvidersNames.TabIndex = 6;
            // 
            // richTextBoxReportProviders
            // 
            richTextBoxReportProviders.Location = new Point(3, 319);
            richTextBoxReportProviders.Name = "richTextBoxReportProviders";
            richTextBoxReportProviders.ReadOnly = true;
            richTextBoxReportProviders.Size = new Size(660, 228);
            richTextBoxReportProviders.TabIndex = 7;
            richTextBoxReportProviders.Text = "";
            // 
            // buttonReportProviders
            // 
            buttonReportProviders.AutoSize = true;
            buttonReportProviders.Location = new Point(3, 280);
            buttonReportProviders.Name = "buttonReportProviders";
            buttonReportProviders.Size = new Size(148, 33);
            buttonReportProviders.TabIndex = 8;
            buttonReportProviders.Text = "Сформировать";
            buttonReportProviders.UseVisualStyleBackColor = true;
            buttonReportProviders.Click += buttonReportProviders_Click;
            // 
            // labelReportProductsTitle
            // 
            labelReportProductsTitle.AutoSize = true;
            labelReportProductsTitle.Location = new Point(759, 9);
            labelReportProductsTitle.Name = "labelReportProductsTitle";
            labelReportProductsTitle.Size = new Size(238, 23);
            labelReportProductsTitle.TabIndex = 9;
            labelReportProductsTitle.Text = "Диаграммы для продуктов";
            // 
            // labelReportProductsFrom
            // 
            labelReportProductsFrom.AutoSize = true;
            labelReportProductsFrom.Location = new Point(898, 32);
            labelReportProductsFrom.Name = "labelReportProductsFrom";
            labelReportProductsFrom.Size = new Size(99, 23);
            labelReportProductsFrom.TabIndex = 10;
            labelReportProductsFrom.Text = "С периода";
            // 
            // labelReportProductsTo
            // 
            labelReportProductsTo.AutoSize = true;
            labelReportProductsTo.Location = new Point(894, 90);
            labelReportProductsTo.Name = "labelReportProductsTo";
            labelReportProductsTo.Size = new Size(103, 23);
            labelReportProductsTo.TabIndex = 11;
            labelReportProductsTo.Text = "По период";
            // 
            // dateTimePickerReportProductsFrom
            // 
            dateTimePickerReportProductsFrom.Location = new Point(747, 58);
            dateTimePickerReportProductsFrom.Name = "dateTimePickerReportProductsFrom";
            dateTimePickerReportProductsFrom.Size = new Size(250, 29);
            dateTimePickerReportProductsFrom.TabIndex = 12;
            // 
            // dateTimePickerReportProductsTo
            // 
            dateTimePickerReportProductsTo.Location = new Point(747, 116);
            dateTimePickerReportProductsTo.Name = "dateTimePickerReportProductsTo";
            dateTimePickerReportProductsTo.Size = new Size(250, 29);
            dateTimePickerReportProductsTo.TabIndex = 13;
            // 
            // labelReportProductsNames
            // 
            labelReportProductsNames.AutoSize = true;
            labelReportProductsNames.Location = new Point(800, 148);
            labelReportProductsNames.Name = "labelReportProductsNames";
            labelReportProductsNames.Size = new Size(197, 23);
            labelReportProductsNames.TabIndex = 14;
            labelReportProductsNames.Text = "Выбранные продукты";
            // 
            // checkedListBoxReportProductsNames
            // 
            checkedListBoxReportProductsNames.FormattingEnabled = true;
            checkedListBoxReportProductsNames.Location = new Point(747, 174);
            checkedListBoxReportProductsNames.Name = "checkedListBoxReportProductsNames";
            checkedListBoxReportProductsNames.Size = new Size(250, 100);
            checkedListBoxReportProductsNames.TabIndex = 15;
            // 
            // buttonReportProducts
            // 
            buttonReportProducts.AutoSize = true;
            buttonReportProducts.Location = new Point(849, 280);
            buttonReportProducts.Name = "buttonReportProducts";
            buttonReportProducts.Size = new Size(148, 33);
            buttonReportProducts.TabIndex = 16;
            buttonReportProducts.Text = "Сформировать";
            buttonReportProducts.UseVisualStyleBackColor = true;
            buttonReportProducts.Click += buttonReportProducts_Click;
            // 
            // ReportingUserControl
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonReportProducts);
            Controls.Add(checkedListBoxReportProductsNames);
            Controls.Add(labelReportProductsNames);
            Controls.Add(dateTimePickerReportProductsTo);
            Controls.Add(dateTimePickerReportProductsFrom);
            Controls.Add(labelReportProductsTo);
            Controls.Add(labelReportProductsFrom);
            Controls.Add(labelReportProductsTitle);
            Controls.Add(buttonReportProviders);
            Controls.Add(richTextBoxReportProviders);
            Controls.Add(checkedListBoxReportProvidersNames);
            Controls.Add(dateTimePickerReportProvidersTo);
            Controls.Add(dateTimePickerReportProvidersFrom);
            Controls.Add(labelReportProvidersNames);
            Controls.Add(labelReportProvidersTo);
            Controls.Add(labelReportProvidersFrom);
            Controls.Add(labelReportProvidersTitle);
            Font = new Font("Microsoft YaHei UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ReportingUserControl";
            Size = new Size(1000, 550);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelReportProvidersTitle;
        private Label labelReportProvidersFrom;
        private Label labelReportProvidersTo;
        private Label labelReportProvidersNames;
        private DateTimePicker dateTimePickerReportProvidersFrom;
        private DateTimePicker dateTimePickerReportProvidersTo;
        private CheckedListBox checkedListBoxReportProvidersNames;
        private RichTextBox richTextBoxReportProviders;
        private Button buttonReportProviders;
        private Label labelReportProductsTitle;
        private Label labelReportProductsFrom;
        private Label labelReportProductsTo;
        private DateTimePicker dateTimePickerReportProductsFrom;
        private DateTimePicker dateTimePickerReportProductsTo;
        private Label labelReportProductsNames;
        private CheckedListBox checkedListBoxReportProductsNames;
        private Button buttonReportProducts;
    }
}
