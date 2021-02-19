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

    public partial class PopupNewWorkOrder : CompanyManager.PopupBaseForm
    {
        WorkOrderService service = new WorkOrderService();
        List<ItemTimeVO> items = new List<ItemTimeVO>();
        private NewWorkOrderVO selectedWO;

        private int loginEmp { get; set; }
        public PopupNewWorkOrder(int loginEmp)
        {
            InitializeComponent();
            this.loginEmp = loginEmp;
        }

        public PopupNewWorkOrder(NewWorkOrderVO selectedWO)
        {
            InitializeComponent();
            this.selectedWO = selectedWO;
        }

        private void PopupNewWorkOrder_Load(object sender, EventArgs e)
        {
            items = service.GetAllItems();
            items.Insert(0, new ItemTimeVO() { item_id = "", item_name = "선택" });
            CommonUtil.BindingComboBox(cboItem, items, "item_id", "item_name");

            if (selectedWO == null)
                return;


            cboItem.SelectedIndex = items.FindIndex(elem => elem.item_id == selectedWO.item_id);
            cboItem.Enabled = false;
            numQty.Value = selectedWO.wo_qty;
            dtpStartDate.Value = selectedWO.wo_sdate;
            txtEndDate.Text = selectedWO.wo_edate.ToString();
            txtComment.Text = selectedWO.wo_comment;
            btnSave.Text = "수정";
        }

        private void numQty_ValueChanged(object sender, EventArgs e)
        {
            CalcEndDate();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (selectedWO != null)
                return;
            if (dtpStartDate.Value < DateTime.Now)
            {
                MessageBox.Show("잘못 입력하셨습니다.");
                dtpStartDate.Value = DateTime.Now.AddDays(1);
            }
            CalcEndDate();
        }

        private void CalcEndDate()
        {
            if (cboItem.Text.Equals("선택") || numQty.Value < 1)
                return;

            ItemTimeVO item = items.Find(e => e.item_id.Equals(cboItem.SelectedValue.ToString()));
            int requiredTime = (item.tacktime * (int)numQty.Value) / 60;
            int h = Convert.ToInt32(item.shift_stime.Substring(0, 2));
            int m = Convert.ToInt32(item.shift_stime.Substring(2, 2));
            int s = Convert.ToInt32(item.shift_stime.Substring(4, 2));
            DateTime machineStartTime = new DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day, h, m, s);
            if (dtpStartDate.Value < machineStartTime)
                dtpStartDate.Value = machineStartTime;

            h = Convert.ToInt32(item.shift_etime.Substring(0, 2));
            m = Convert.ToInt32(item.shift_etime.Substring(2, 2));
            s = Convert.ToInt32(item.shift_etime.Substring(4, 2));
            DateTime machineEndTime = new DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day, h, m, s);
            DateTime woEndTime = dtpStartDate.Value.AddMinutes(requiredTime);
            if (woEndTime > machineEndTime)
            {
                h = Convert.ToInt32(item.shift_stime.Substring(0, 2));
                m = Convert.ToInt32(item.shift_stime.Substring(2, 2));
                s = Convert.ToInt32(item.shift_stime.Substring(4, 2));
                TimeSpan overTime = woEndTime - machineEndTime;
                woEndTime = new DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day, h, m, s).AddMinutes(overTime.TotalMinutes).AddDays(1);
            }

            txtEndDate.Text = woEndTime.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (btnSave.Text.Equals("수정"))
            {
                if (numQty.Value < 1)
                {
                    MessageBox.Show("필수 정보를 입력해 주십시오.");
                    return;
                }
                result = service.UpdateWorkOrder(selectedWO.wo_id, Convert.ToInt32(numQty.Value), dtpStartDate.Value, Convert.ToDateTime(txtEndDate.Text), txtComment.Text, loginEmp);
            }
            else
            {
                if (cboItem.Text.Equals("선택") || numQty.Value < 1)
                {
                    MessageBox.Show("필수 정보를 입력해 주십시오.");
                    return;
                }

                result = service.InsertWorkOrder(cboItem.SelectedValue.ToString(), Convert.ToInt32(numQty.Value), dtpStartDate.Value, Convert.ToDateTime(txtEndDate.Text), txtComment.Text, loginEmp);
            }

            if (result)
            {
                MessageBox.Show($"{btnSave.Text} 성공");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show($"{btnSave.Text}중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오");
                return;
            }

        }
    }
}
