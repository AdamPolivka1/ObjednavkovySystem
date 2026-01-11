using Orderappis.Data.Model;
using Orderappis.Data.Repositories;
using Orderis.Data.Model;
using Orderis.Services.Auth;

namespace Orderappis.UserControls.Mod.Orders.dlg
{
    public partial class dlgOrderE : UserControl
    {
        private Order OrderModel { get; set; }
        private OrderRepository _orderRepository;
        public int OrderID { get; set; }

        //
        private decimal PrevTotalPriceCZK { get; set; } = -1;

        public dlgOrderE()
        {
            InitializeComponent();
            InitComboBox();
            _orderRepository = new OrderRepository();
            OrderModel = new Order();
            numericUpDownTotalPriceCZK.Validating += TotalPriceChanged;
        }

        private void TotalPriceChanged(object? sender, EventArgs e)
        {
            bool isM = AuthService.Instance.InUserRole("manažer");
            if (!isM)
            {
                MessageBox.Show(
                    "Akce není povolena.",
                    "Chyba",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                // jinak návrat k původní hodnotě
                if (PrevTotalPriceCZK != -1)
                {
                    numericUpDownTotalPriceCZK.Value = PrevTotalPriceCZK;
                }
                return;
            }
        }

        public void LoadData()
        {
            // Load Order from database
            var order = _orderRepository.GetById(OrderID);
            if (order != null)
            {
                OrderModel = order;
                comboBoxStatus.SelectedValue = OrderModel.Status;
                numericUpDownTotalPriceCZK.Value = OrderModel.TotalPriceCZK;
                PrevTotalPriceCZK = numericUpDownTotalPriceCZK.Value;
            }
        }

        private void InitComboBox()
        {
            // Vytvořena (1), Zpracování (2)
            // Připravena (3), Doručování (4)
            // Dokončena(5), Zrušena(6)
            List<OrderStatus> listVals = new List<OrderStatus>();
            listVals.Add(new OrderStatus(1, "Vytvořena"));
            listVals.Add(new OrderStatus(2, "Zpracování"));
            listVals.Add(new OrderStatus(3, "Připravena"));
            listVals.Add(new OrderStatus(4, "Doručování"));
            listVals.Add(new OrderStatus(5, "Dokončena"));
            listVals.Add(new OrderStatus(6, "Zrušena"));

            comboBoxStatus.DataSource = listVals;
            comboBoxStatus.DisplayMember = "Name";
            comboBoxStatus.ValueMember = "Id";
        }

        private void UpdateData()
        {
            var statusObj = comboBoxStatus.SelectedValue;
            if (statusObj != null)
            {
                decimal totalPrice = numericUpDownTotalPriceCZK.Value;
                _orderRepository.UpdateOrderStatusAndPrice((int)statusObj, totalPrice, OrderModel.OrderId);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UpdateData();
            // zavření parent formu
            var parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.DialogResult = DialogResult.OK;
                parentForm.Close();
            }
        }
    }
}
