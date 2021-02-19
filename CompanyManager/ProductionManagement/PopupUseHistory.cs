using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VO;
using Util;
using Service;
namespace CompanyManager
{
    public partial class PopupUseHistory : CompanyManager.PopupBaseForm
    {
        private int woID;
        public PopupUseHistory(int woID)
        {
            InitializeComponent();
            this.woID = woID;
        }

        private void PopupUseHistory_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dataGridView1);
            CommonUtil.SetDGVDesign(dataGridView1);

            CommonUtil.AddGridTextColumn(dataGridView1, "품목", "item_id", 100);
            CommonUtil.AddGridTextColumn(dataGridView1, "품목명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dataGridView1, "차감창고", "warehouse_name", 100);
            CommonUtil.AddGridTextColumn(dataGridView1, "차감량", "use_qty", 80);

            WorkOrderService service = new WorkOrderService();
            DataTable dt = service.GetUseInfo(woID);

            dataGridView1.DataSource = dt;
        }
    }
}
