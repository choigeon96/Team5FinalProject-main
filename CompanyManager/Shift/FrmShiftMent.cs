using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;

namespace CompanyManager
{
    public partial class FrmShiftMent : CompanyManager.MDIBaseForm
    {
        public FrmShiftMent()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
       

        private void FrmShiftMent_Load(object sender, EventArgs e)
        {

            DataLoad();
            ComboBoxBinding();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now.AddDays(10);
        }

        private void DataLoad()
        {
            CommonUtil.SetDGVDesign(dataGridView2);
            dataGridView2.AutoGenerateColumns = true;

           
        }
        DataTable dt;
        private void button14_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            ShiftService service = new ShiftService();
            dt = service.GetShiftInfo(dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString(), cboShift.Text,cboMachine.Text);
            CommonUtil.AddGridTextColumn(dataGridView2, "설비명", "설비명", 130);
            dataGridView2.DataSource = dt;
            //DataView dv= dt.DefaultView;

            //if (cboMachine.Text != "전체")
            //    dv.RowFilter = $"machine_id='{cboMachine.SelectedValue}'";
            //else
            //    dataGridView2.DataSource = dt;


            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[1].HeaderText = "Shift";
            dataGridView2.Columns[4].Visible = false;
            dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        
        List<CodeVO> code;
        List<MachineVO> machine;
         

        private void ComboBoxBinding()
        {
            MachineService service = new MachineService();
            machine = service.GetMachine();
            machine.Insert(0, new MachineVO { machine_name = "전체" });
            CommonUtil.BindingComboBox(cboMachine, machine, "machine_id", "machine_name");

            //var shift1 = shift.ConvertAll(o => o);
            //shift1.Insert(0, new ShiftVO { shift_type = "전체" });
            //CommonUtil.BindingComboBoxPart(cboShift, shift1, "shift_type");


            CodeService service1 = new CodeService();
            code = service1.GetAllCommonCode();
            var code1 = (from All in code where All.category == "shift_type" select All).ToList();
            //code1.Insert(0, new CodeVO { name = "전체" });
            CommonUtil.BindingComboBox(cboShift, code1, "code", "name");


        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save as Excel File";
            sfd.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";
            sfd.FileName = "";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
               CommonExcel.dataGridView_ExportToExcel(sfd.FileName, dataGridView2);
            }

   
        }

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("검색기간의 설정이 잘못되었습니다.");
                return;
            }
        }
       
    }
}
