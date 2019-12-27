using System.Windows.Forms;

namespace onlineplayer
{
    public partial class FormProgress : Form
    {
        public FormProgress(string processingText, string descText)
        {
            InitializeComponent();
            labelProcessing.Text = processingText;
            labelCurrentAction.Text = descText;
        }

    }
}
