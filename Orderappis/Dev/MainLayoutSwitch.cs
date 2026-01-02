using Orderis.UIComponents.Menu;
using Orderis.UserControls.Mod.Orders;
using Orderis.UserControls.Mod.Products;
using Orderis.UserControls.Mod.Users;

namespace Orderis.Dev
{
    class MainLayoutSwitch
    {
        public LeftPanelMenuRenderer leftPanelMenuRenderer;

        public MainLayoutSwitch(LeftPanelMenuRenderer lpmr)
        {
            leftPanelMenuRenderer = lpmr;
        }

        public void ChangeMod(ToolStripMenuItem mItemSender, FormMain form)
        {
            bool isMainLevel = false;
            UserControl userControl = null;
            string PageLabelStr = "";

            switch (mItemSender.Tag)
            {
                case "MOD_USERS":
                    userControl = new ModUsersMain();
                    PageLabelStr = "Modul uživatelé";
                    isMainLevel = true;
                    break;
                case "MOD_ORDERS":
                    userControl = new ModOrdersMain();
                    PageLabelStr = "Modul objednávky";
                    isMainLevel = true;
                    break;
                case "MOD_ORDERS_X":
                    userControl = new ModOrdersMain();
                    PageLabelStr = "Modul objednávky";
                    // isMainLevel = true;
                    break;
                case "MOD_ORDERS_SUB_Deliveries":
                    userControl = new ModOrdersDelivery();
                    PageLabelStr = "Modul objednávky > Dodání";
                    break;
                case "MOD_ORDERS_SUB_Payments":
                    userControl = new ModOrdersPayment();
                    PageLabelStr = "Modul objednávky > Platby";
                    break;
                case "MOD_PRODS":
                    userControl = new ModProductsMain();
                    PageLabelStr = "Modul produkty";
                    isMainLevel = true;
                    break;
            }

            if (userControl != null) {
                form.pageHeaderMain.SetLabel(PageLabelStr);
                form.panelMainLayout.Controls.Clear();
                userControl.Dock = DockStyle.Fill;
                form.panelMainLayout.Controls.Add(userControl);
                userControl.BringToFront();
            }

        
            if (isMainLevel) 
            {
                leftPanelMenuRenderer.SetActiveItem(mItemSender);
            }
            else { 
                ToolStripMenuItem parent = mItemSender.OwnerItem as ToolStripMenuItem;
                if (parent != null)
                {
                    leftPanelMenuRenderer.SetActiveItem(parent);
                }
            }
            
            form.LeftPanelMenu.Refresh();
        }


    }
}
