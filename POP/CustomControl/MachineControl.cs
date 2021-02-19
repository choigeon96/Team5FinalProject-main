using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POP
{
    public partial class MachineControl : UserControl
    {
        public string MachinName { get; set; }
        public Image image { get; set; }
        public MachineControl()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void MachineControl_Load(object sender, EventArgs e)
        {
            groupBox1.Text = MachinName;
            pictureBox1.Image = image;
        }
    }
}
