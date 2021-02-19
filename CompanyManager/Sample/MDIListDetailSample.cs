using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;

namespace CompanyManager
{
    public partial class MDIListDetailSample : CompanyManager.MDIBaseForm
    {
        public MDIListDetailSample()
        {
            InitializeComponent();
        }

        private void MDISampleControl2_Load(object sender, EventArgs e)
        {
            CommonUtil.SetDGVDesign(dataGridView2);
            MenuService service = new MenuService();
            dataGridView2.DataSource = service.GetMenus(0);

            CommonUtil.SetDGVDesign(dataGridView1);
            dataGridView1.DataSource = service.GetMenus(0);
        }

       
       

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void dataGridView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell is DataGridViewCheckBoxCell)

            {

                dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);

            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1.RowHeadersWidth = 50;
            dataGridView1.RowHeadersVisible = true;
            StringFormat drawFormat = new StringFormat();
            //drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            using (Brush brush = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font,
                brush, e.RowBounds.Location.X + 35, e.RowBounds.Location.Y + 4, drawFormat);
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
            {

                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);

            }
        }

        private void dataGridView2_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell is DataGridViewCheckBoxCell)
            {

                dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);

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

    }
}
