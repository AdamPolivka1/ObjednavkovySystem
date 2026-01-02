using System.Data;

namespace Orderis
{

    public partial class MessageDialog : Form
    {
        private String _type;

        public MessageDialog(String type)
        {
            _type = type;
            InitializeComponent();
        }

        private void MessageDialog_Load(object sender, EventArgs e)
        {
            //..
        }

        public static DialogResult ShowMessage(String type, String message)
        {
            type = type.ToLower();
            MessageDialog form = new MessageDialog(type);
            ///// set defaults
            switch (type)
            {
                case "info":
                    form.Text = "Informace";
                    form.button1.Text = "Ok";
                    form.button2.Visible = false;
                    string pathImgInfo = Path.Combine(Application.StartupPath, "Images", "info.ico");
                    if (File.Exists(pathImgInfo)) {
                        form.Icon = new Icon(pathImgInfo);
                    }
                    break;
                case "question":
                    form.Text = "Dotaz";
                    form.button1.Text = "Ano";
                    form.button2.Visible = false;
                    string pathImgQuestion = Path.Combine(Application.StartupPath, "Images", "question.ico");
                    if (File.Exists(pathImgQuestion))
                    {
                        form.Icon = new Icon(pathImgQuestion);
                    }
                    break;
                case "warning":
                    form.Text = "Důležité Upozornění";
                    form.button1.Text = "Ok";
                    form.button2.Text = "Cancel";
                    string pathImgWarning = Path.Combine(Application.StartupPath, "Images", "info.ico");
                    if (File.Exists(pathImgWarning))
                    {
                        form.Icon = new Icon(pathImgWarning);
                    }
                    break;
                case "error":
                    form.button1.Text = "Ok";
                    form.button2.Visible = false;
                    form.Text = "Chyba";
                    string pathImgError = Path.Combine(Application.StartupPath, "Images", "info.ico");
                    if (File.Exists(pathImgError))
                    {
                        form.Icon = new Icon(pathImgError);
                    }
                    break;
                default:
                    break;
            }
            form.label1.Text = message;
            /////
            Form mainOpenForm = Application.OpenForms.Cast<Form>().FirstOrDefault(f => f == Application.OpenForms[0]);
            form.StartPosition = FormStartPosition.CenterParent;
            if (mainOpenForm != null)
                return form.ShowDialog(mainOpenForm);
            else
                return form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (_type)
            {
                case "question":
                    this.DialogResult = DialogResult.OK;
                    break;
                case "info":
                    this.DialogResult = DialogResult.OK;
                    break;
                case "warning":
                    this.DialogResult = DialogResult.OK;
                    break;
                case "error":
                    this.DialogResult = DialogResult.OK;
                    break;
                default:
                    break;
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (_type)
            {
                case "info":
                    break;
                case "warning":
                    this.DialogResult = DialogResult.Cancel;
                    break;
                case "error":
                    break;
                default:
                    break;
            }

            this.Close();
        }
    }
}
