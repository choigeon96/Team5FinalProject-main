using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;

namespace CompanyManager
{
    public partial class PopupSoUpload : CompanyManager.PopupBaseForm
    {
        private DataTable dt;
        private string planDate;

        public string PlanDate { get => planDate; }

        public DataTable DT { get => dt; }
        
        string fileName = string.Empty;
        public PopupSoUpload()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            (dt, fileName) = CommonExcel.ReadExcelData();
            if (dt == null)
            {
                MessageBox.Show("파일을 불러오는데 실패하였습니다. 다시 시도하여 주십시오");
                return;
            }
            txtFileName.Text = fileName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dt == null)
            {
                MessageBox.Show("파일을 선택하여 주십시오.");
                return;
            }
            dt.Rows.Remove(dt.Rows[0]);
            dt.Columns.Add("planDate");
            foreach (DataRow row in dt.Rows)
            {
                row["planDate"] = dtpPlanDate.Value.ToString("yyyy-MM-dd");
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
