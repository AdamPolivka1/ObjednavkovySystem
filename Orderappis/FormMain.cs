using Orderappis.UIComponents.AuthForm;
using Orderis.Dev;
using Orderis.Services.Auth;
using Orderis.UIComponents.Menu;

namespace Orderis
{
    public partial class FormMain : Form
    {
        private MainLayoutSwitch _mainLayoutController;

        public FormMain()
        {
            _mainLayoutController = new MainLayoutSwitch(new LeftPanelMenuRenderer());
            InitializeComponent();
        }

        private void InitMainForm()
        {
            InitLeftPanelMenu();
            string imgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "log-out.jpg");

            if (File.Exists(imgPath))
            {
                pictureBoxLogOut.Image = Image.FromFile(imgPath);
            }
            this.Icon = new Icon(@"Images\container.ico"); // nastavení hlavní ikony
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Auth Form
            var authForm = new AuthForm();
            authForm.ShowDialog();

            // PRO PRODUKCI:
            if (!authForm.IsLoggedIn) // pøihlášení selhalo
            {
                Close();
            }

            InitMainForm();
        }

        private void panelHeaderMain_Paint(object sender, PaintEventArgs e)
        {
            Color borderColor = Color.MediumTurquoise;
            int borderWidth = 3;

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                int y = HeaderPanel.ClientSize.Height - borderWidth / 2;
                e.Graphics.DrawLine(pen, 0, y, HeaderPanel.ClientSize.Width, y);
            }
        }

        private void pictureBoxLogOut_Click(object sender, EventArgs e)
        {
            if (MessageDialog.ShowMessage("question", "Pøejete si ukonèit aplikaci?") == DialogResult.OK)
                Application.Exit();
        }

        private void InitLeftPanelMenu()
        {
            LeftPanelMenu.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            LeftPanelMenu.Stretch = true;
            LeftPanelMenu.BackColor = SystemColors.Window;
            LeftPanelMenu.Cursor = Cursors.Hand;

            LeftPanelMenu.Renderer = _mainLayoutController.leftPanelMenuRenderer;

            ToolStripMenuItem item1 = new ToolStripMenuItem("Uživatel");
            ToolStripMenuItem item2 = new ToolStripMenuItem("Produkty");
            ToolStripMenuItem item3 = new ToolStripMenuItem("Objednávky");

            string baseDir = Application.StartupPath;

            // uživatel
            string pathUserPng = Path.Combine(baseDir, "Images", "user.png");

            if (File.Exists(pathUserPng))
            {
                item1.Image = Image.FromFile(pathUserPng);
            }
            // produkty
            string pathProductsPng = Path.Combine(baseDir, "Images", "products.png");

            if (File.Exists(pathProductsPng))
            {
                item2.Image = Image.FromFile(pathProductsPng);
            }
            // objednávky
            string pathOrdersPng = Path.Combine(baseDir, "Images", "orders.png");

            if (File.Exists(pathOrdersPng))
            {
                item3.Image = Image.FromFile(pathOrdersPng);
            }

            item1.ImageAlign = ContentAlignment.MiddleLeft;
            item2.ImageAlign = ContentAlignment.MiddleLeft;
            item3.ImageAlign = ContentAlignment.MiddleLeft;

            // objednávky sub
            ToolStripMenuItem sub3orderA = new ToolStripMenuItem("Pøehled");
            ToolStripMenuItem sub3orderB = new ToolStripMenuItem("Dodání");
            ToolStripMenuItem sub3orderC = new ToolStripMenuItem("Platby");

            sub3orderA.Tag = "MOD_ORDERS_X";
            sub3orderB.Tag = "MOD_ORDERS_SUB_Deliveries";
            sub3orderC.Tag = "MOD_ORDERS_SUB_Payments";

            // sub action handlers
            sub3orderA.Click += SubMenuItem_Click;
            sub3orderB.Click += SubMenuItem_Click;
            sub3orderC.Click += SubMenuItem_Click;

            item3.DropDownItems.Add(sub3orderA);
            item3.DropDownItems.Add(sub3orderB);
            item3.DropDownItems.Add(sub3orderC);

            // set onlick handler
            item1.Click += MenuItem_Click;
            item2.Click += MenuItem_Click;
            item3.Click += MenuItem_Click;

            // TOP LEVEL AUTH
            // Defaultní odrážky v menu jsou povoleny pro všechny role
            // Zobrazení konkrétních záložek je øešeno v pøidružených Mod*
            // AUTH
            bool isZ = AuthService.Instance.InUserRole("zákazník");
            bool isM = AuthService.Instance.InUserRole("manažer");
            bool isS = AuthService.Instance.InUserRole("skladník");
            bool isA = AuthService.Instance.InUserRole("administrátor");

            if (isA || isM || isS || isZ)
            {
                LeftPanelMenu.Items.Add(item1); // Uživatel
            }

            if (isA || isM || isZ || isZ)
            {
                LeftPanelMenu.Items.Add(item2); // Produkty
            }

            if (isA || isM || isS || isZ)
            {
                LeftPanelMenu.Items.Add(item3); // Objednávky
            }

            item1.Tag = "MOD_USERS";
            item2.Tag = "MOD_PRODS";
            item3.Tag = "MOD_ORDERS";

            // zobrazení submenu už pøi MouseHover
            foreach (ToolStripMenuItem item in LeftPanelMenu.Items)
            {
                item.MouseHover += (s, e) =>
                {
                    if (s is ToolStripMenuItem mi && mi.HasDropDownItems)
                    {
                        mi.ShowDropDown();
                    }
                };
            }

            // set active item to MOD_USERS
            _mainLayoutController.ChangeMod(item1, this);
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem mItem)
            {
                mItem.DropDown.Close(); // vynucení zavøení popup
                _mainLayoutController.ChangeMod(mItem, this);
            }
        }

        private void SubMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem mItem)
            {
                mItem.DropDown.Close(); // vynucení zavøení popup
                _mainLayoutController.ChangeMod(mItem, this);
            }
        }

    }
}