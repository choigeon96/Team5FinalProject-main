using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class MDIListDetailSample2 : CompanyManager.MDIBaseForm
    {
        public MDIListDetailSample2()
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
                splitContainer1.Location = new Point(splitContainer1.Location.X, splitContainer1.Location.Y + 38);
                splitContainer1.Size = new Size(splitContainer1.Size.Width, splitContainer1.Size.Height - 38);

            }
            else
            {
                btnDown.Text = "ᐱ";
               
                btnDown.Location = new Point(btnDown.Location.X, 38);
                btnSearch.Location = new Point(btnSearch.Location.X, 37);
                pnlSearch.Size = new Size(pnlSearch.Size.Width, pnlSearch.Size.Height * 2 / 3);

                splitContainer1.Location = new Point(splitContainer1.Location.X, splitContainer1.Location.Y - 38);
                splitContainer1.Size = new Size(splitContainer1.Size.Width, splitContainer1.Size.Height + 38);
            }
        }
    }
}
