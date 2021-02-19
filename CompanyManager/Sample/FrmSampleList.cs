using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager
{ 
    public partial class FrmSampleList : CompanyManager.MDIBaseForm
    {
        public FrmSampleList()
        {
            InitializeComponent();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (btnDown.Text == "V")
            {
                this.Size = new Size(this.Size.Width, this.Size.Height * 3 / 2);
                


                btnDown.Text = "ᐱ";
            }
            else
            {
                btnDown.Text = "V";
               
            }
        }
       

      

        private void dataGridView2_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView2.RowHeadersWidth = 50;
            dataGridView2.RowHeadersVisible = true;
            StringFormat drawFormat = new StringFormat();
            //drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            using (Brush brush = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font,
                brush, e.RowBounds.Location.X + 35, e.RowBounds.Location.Y + 4, drawFormat);
            }
        }

        private void dataGridView2_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell is DataGridViewCheckBoxCell)

            {

                dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);

            }
        }
    }
}
