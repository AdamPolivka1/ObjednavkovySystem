namespace Orderis
{
    partial class FormMain
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
            HeaderPanel = new Panel();
            pictureBoxLogOut = new PictureBox();
            labelMainAppHeading = new Label();
            LeftPanel = new Panel();
            LeftPanelMenu = new MenuStrip();
            npgsqlCommandBuilder1 = new Npgsql.NpgsqlCommandBuilder();
            panelMain = new Panel();
            panelMainWrapper = new Panel();
            panelMainLayout = new Panel();
            pageHeaderMain = new UserControls.PageHeader();
            HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogOut).BeginInit();
            LeftPanel.SuspendLayout();
            panelMain.SuspendLayout();
            panelMainWrapper.SuspendLayout();
            SuspendLayout();
            // 
            // HeaderPanel
            // 
            HeaderPanel.BackColor = SystemColors.Window;
            HeaderPanel.Controls.Add(pictureBoxLogOut);
            HeaderPanel.Controls.Add(labelMainAppHeading);
            HeaderPanel.Dock = DockStyle.Top;
            HeaderPanel.Location = new Point(0, 0);
            HeaderPanel.Margin = new Padding(4);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Size = new Size(1380, 80);
            HeaderPanel.TabIndex = 0;
            HeaderPanel.Paint += panelHeaderMain_Paint;
            // 
            // pictureBoxLogOut
            // 
            pictureBoxLogOut.Anchor = AnchorStyles.Right;
            pictureBoxLogOut.Cursor = Cursors.Hand;
            pictureBoxLogOut.Location = new Point(1327, 22);
            pictureBoxLogOut.Name = "pictureBoxLogOut";
            pictureBoxLogOut.Size = new Size(41, 41);
            pictureBoxLogOut.TabIndex = 1;
            pictureBoxLogOut.TabStop = false;
            pictureBoxLogOut.Click += pictureBoxLogOut_Click;
            // 
            // labelMainAppHeading
            // 
            labelMainAppHeading.AutoSize = true;
            labelMainAppHeading.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelMainAppHeading.Location = new Point(15, 30);
            labelMainAppHeading.Margin = new Padding(4, 0, 4, 0);
            labelMainAppHeading.Name = "labelMainAppHeading";
            labelMainAppHeading.Size = new Size(131, 26);
            labelMainAppHeading.TabIndex = 0;
            labelMainAppHeading.Text = "OrderAppIS";
            // 
            // LeftPanel
            // 
            LeftPanel.BackColor = SystemColors.Window;
            LeftPanel.Controls.Add(LeftPanelMenu);
            LeftPanel.Dock = DockStyle.Left;
            LeftPanel.Location = new Point(0, 80);
            LeftPanel.Name = "LeftPanel";
            LeftPanel.Padding = new Padding(0, 3, 0, 0);
            LeftPanel.Size = new Size(250, 755);
            LeftPanel.TabIndex = 1;
            // 
            // LeftPanelMenu
            // 
            LeftPanelMenu.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            LeftPanelMenu.ImageScalingSize = new Size(26, 26);
            LeftPanelMenu.Location = new Point(0, 3);
            LeftPanelMenu.Name = "LeftPanelMenu";
            LeftPanelMenu.Size = new Size(250, 24);
            LeftPanelMenu.TabIndex = 0;
            LeftPanelMenu.Text = "menuStrip1";
            // 
            // npgsqlCommandBuilder1
            // 
            npgsqlCommandBuilder1.QuotePrefix = "\"";
            npgsqlCommandBuilder1.QuoteSuffix = "\"";
            // 
            // panelMain
            // 
            panelMain.BackColor = SystemColors.ControlLight;
            panelMain.Controls.Add(panelMainWrapper);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(250, 80);
            panelMain.Margin = new Padding(0);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(5);
            panelMain.Size = new Size(1130, 755);
            panelMain.TabIndex = 2;
            // 
            // panelMainWrapper
            // 
            panelMainWrapper.BackColor = SystemColors.Window;
            panelMainWrapper.Controls.Add(panelMainLayout);
            panelMainWrapper.Controls.Add(pageHeaderMain);
            panelMainWrapper.Dock = DockStyle.Fill;
            panelMainWrapper.Location = new Point(5, 5);
            panelMainWrapper.Margin = new Padding(0);
            panelMainWrapper.Name = "panelMainWrapper";
            panelMainWrapper.Size = new Size(1120, 745);
            panelMainWrapper.TabIndex = 0;
            // 
            // panelMainLayout
            // 
            panelMainLayout.Dock = DockStyle.Fill;
            panelMainLayout.Location = new Point(0, 62);
            panelMainLayout.Name = "panelMainLayout";
            panelMainLayout.Size = new Size(1120, 683);
            panelMainLayout.TabIndex = 1;
            // 
            // pageHeaderMain
            // 
            pageHeaderMain.Dock = DockStyle.Top;
            pageHeaderMain.Location = new Point(0, 0);
            pageHeaderMain.Name = "pageHeaderMain";
            pageHeaderMain.Size = new Size(1120, 62);
            pageHeaderMain.TabIndex = 0;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(10F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1380, 835);
            Controls.Add(panelMain);
            Controls.Add(LeftPanel);
            Controls.Add(HeaderPanel);
            Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Margin = new Padding(4);
            Name = "FormMain";
            Load += FormMain_Load;
            HeaderPanel.ResumeLayout(false);
            HeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogOut).EndInit();
            LeftPanel.ResumeLayout(false);
            LeftPanel.PerformLayout();
            panelMain.ResumeLayout(false);
            panelMainWrapper.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel HeaderPanel;
        private Label labelMainAppHeading;
        private Panel LeftPanel;
        private Npgsql.NpgsqlCommandBuilder npgsqlCommandBuilder1;
        private PictureBox pictureBoxLogOut;
        private Panel panelMain;
        private Panel panelMainWrapper;

        // PUBLIC
        public MenuStrip LeftPanelMenu;
        public UserControls.PageHeader pageHeaderMain;
        public Panel panelMainLayout;
    }
}
