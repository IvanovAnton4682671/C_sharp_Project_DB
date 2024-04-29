namespace Individual_work
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainMenuStrip = new MenuStrip();
            ProductsToolStripMenuItem = new ToolStripMenuItem();
            ProvidersToolStripMenuItem = new ToolStripMenuItem();
            PIABOLToolStripMenuItem = new ToolStripMenuItem();
            ReportingToolStripMenuItem = new ToolStripMenuItem();
            MainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MainMenuStrip
            // 
            MainMenuStrip.Dock = DockStyle.None;
            MainMenuStrip.Font = new Font("Microsoft YaHei UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip.ImageScalingSize = new Size(20, 20);
            MainMenuStrip.Items.AddRange(new ToolStripItem[] { ProductsToolStripMenuItem, ProvidersToolStripMenuItem, PIABOLToolStripMenuItem, ReportingToolStripMenuItem });
            MainMenuStrip.Location = new Point(220, 9);
            MainMenuStrip.Name = "MainMenuStrip";
            MainMenuStrip.Size = new Size(928, 31);
            MainMenuStrip.TabIndex = 0;
            MainMenuStrip.Text = "menuStrip1";
            // 
            // ProductsToolStripMenuItem
            // 
            ProductsToolStripMenuItem.Name = "ProductsToolStripMenuItem";
            ProductsToolStripMenuItem.Size = new Size(88, 27);
            ProductsToolStripMenuItem.Text = "Товары";
            ProductsToolStripMenuItem.Click += ProductsStripMenu_Click;
            // 
            // ProvidersToolStripMenuItem
            // 
            ProvidersToolStripMenuItem.Name = "ProvidersToolStripMenuItem";
            ProvidersToolStripMenuItem.Size = new Size(130, 27);
            ProvidersToolStripMenuItem.Text = "Поставщики";
            ProvidersToolStripMenuItem.Click += ProvidersStripMenu_Click;
            // 
            // PIABOLToolStripMenuItem
            // 
            PIABOLToolStripMenuItem.Name = "PIABOLToolStripMenuItem";
            PIABOLToolStripMenuItem.Size = new Size(430, 27);
            PIABOLToolStripMenuItem.Text = "Товарные и Товарно-транспортные накладные";
            PIABOLToolStripMenuItem.Click += PIABOLStripMenu_Click;
            // 
            // ReportingToolStripMenuItem
            // 
            ReportingToolStripMenuItem.Name = "ReportingToolStripMenuItem";
            ReportingToolStripMenuItem.Size = new Size(122, 27);
            ReportingToolStripMenuItem.Text = "Отчётность";
            ReportingToolStripMenuItem.Click += ReportingToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            Controls.Add(MainMenuStrip);
            Font = new Font("Microsoft YaHei UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "Главная панель";
            MainMenuStrip.ResumeLayout(false);
            MainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MainMenuStrip;
        private ToolStripMenuItem ProductsToolStripMenuItem;
        private ToolStripMenuItem ProvidersToolStripMenuItem;
        private ToolStripMenuItem PIABOLToolStripMenuItem;
        private ToolStripMenuItem ReportingToolStripMenuItem;
    }
}
