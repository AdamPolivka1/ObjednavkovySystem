namespace Orderis.UIComponents.Menu
{
    public class LeftPanelMenuRenderer : ToolStripProfessionalRenderer
    {
        
        private ToolStripItem? _activeItem;

        public LeftPanelMenuRenderer() : base()
        {
        }

        public void SetActiveItem(ToolStripItem item)
        {
            _activeItem = item;
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderMenuItemBackground(e);

            if (e.Item == _activeItem)
            {
                Rectangle rc = e.Item.ContentRectangle;
                Rectangle borderRect = new Rectangle(rc.X, rc.Y, 5, rc.Height);

                using (Brush brush = new SolidBrush(Color.MediumTurquoise))
                {
                    e.Graphics.FillRectangle(brush, borderRect);
                }
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
        }
    }
}
