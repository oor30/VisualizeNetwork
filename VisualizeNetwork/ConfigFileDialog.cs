using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualizeNetwork
{
    public partial class ConfigFileDialog : Form
    {
        private int _y_range;

        public ConfigFileDialog()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            _y_range = (int)numericUpDown1.Value;
            this.Close();
        }

        public int getRangeY()
        {
            return _y_range;
        }
    }
}
