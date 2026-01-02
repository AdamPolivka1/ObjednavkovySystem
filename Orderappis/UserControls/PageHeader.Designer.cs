namespace Orderis.UserControls
{
    partial class PageHeader
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            panelPageHeader = new Panel();
            labelPageHeader = new Label();
            panelPageHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelPageHeader
            // 
            panelPageHeader.BackColor = SystemColors.ButtonFace;
            panelPageHeader.Controls.Add(labelPageHeader);
            panelPageHeader.Dock = DockStyle.Fill;
            panelPageHeader.Location = new Point(0, 0);
            panelPageHeader.Name = "panelPageHeader";
            panelPageHeader.Size = new Size(898, 50);
            panelPageHeader.TabIndex = 0;
            panelPageHeader.Paint += panelPageHeader_Paint;
            // 
            // labelPageHeader
            // 
            labelPageHeader.AutoSize = true;
            labelPageHeader.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelPageHeader.Location = new Point(15, 15);
            labelPageHeader.Name = "labelPageHeader";
            labelPageHeader.Size = new Size(59, 25);
            labelPageHeader.TabIndex = 0;
            labelPageHeader.Text = "label1";
            // 
            // PageHeader
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelPageHeader);
            Name = "PageHeader";
            Size = new Size(898, 50);
            panelPageHeader.ResumeLayout(false);
            panelPageHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelPageHeader;
        private Label labelPageHeader;
    }
}
