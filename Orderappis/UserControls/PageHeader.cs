using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orderis.UserControls
{
    public partial class PageHeader : UserControl
    {
        public PageHeader()
        {
            InitializeComponent();
        }

        public void SetLabel(string textStr)
        {
            labelPageHeader.Text = textStr;
        }

        private void panelPageHeader_Paint(object sender, PaintEventArgs e)
        {
            Color borderColor = Color.MediumTurquoise;
            int borderWidth = 3;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                int y = panelPageHeader.ClientSize.Height - borderWidth / 2;
                e.Graphics.DrawLine(pen, 0, y, panelPageHeader.ClientSize.Width, y);
            }
        }
    }
}
