using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class MDIListSample2 : CompanyManager.MDIBaseForm
    {
        public MDIListSample2()
        {
            InitializeComponent();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (btnDown.Text == "ᐱ")
            {
                btnDown.Text = "V";
                int size = this.Size.Height;
                btnDown.Location = new Point(btnDown.Location.X, 71);
                btnSearch.Location = new Point(btnSearch.Location.X, 70);



                pnlSearch.Size = new Size(pnlSearch.Size.Width, 114);
                splitContainer1.SplitterDistance = splitContainer1.SplitterDistance + 38;

            }
            else
            {
                btnDown.Text = "ᐱ";

                btnDown.Location = new Point(btnDown.Location.X, 38);
                btnSearch.Location = new Point(btnSearch.Location.X, 37);
                pnlSearch.Size = new Size(pnlSearch.Size.Width, pnlSearch.Size.Height * 2 / 3);

               
                splitContainer1.SplitterDistance = splitContainer1.SplitterDistance - 38;
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
