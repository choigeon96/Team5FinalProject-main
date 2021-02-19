using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;

namespace CompanyManager
{
    public partial class PopupShift : CompanyManager.PopupBaseForm
    {
        public enum OpenMode { Insert, Update,Copy }
        
        List<CodeVO> code;

        List<MachineVO> machine;
        public int emp_id { get; set; }

        string openmode="";
        public ShiftVO list { get; set; }
        /// <summary>
        /// 오픈모드 설정
        /// </summary>
        /// <param name="mode"></param>
        public PopupShift(OpenMode mode,int emp_id)
        {
            InitializeComponent();
            this.emp_id = emp_id;
            if (mode == OpenMode.Insert)
            {
                openmode = "Insert";
            }
            else if (mode==OpenMode.Copy)
            {
                openmode = "Copy";
            }
            else
            {
                openmode = "Update";
            }
        }
        /// <summary>
        /// 데이터 로드
        /// </summary>
        private void DataLoad()
        {
       // textBox1.Text=  list.shift_id.ToString();
        cboMachine.Text=  list.machine_name;
        cboShift.Text=  list.shift_type;
        txtStime.Text=  list.shift_stime;
        txtEtime.Text=  list.shift_etime;
        dtpSday.Text=  list.shift_sdate.ToString();
        dtpEday.Text=  list.shift_edate.ToString();
        cboUse.Text=  list.shift_use;
        richTextBox1.Text=  list.shift_comment;
        //textBox1.Text=  list.ins_date.ToString();
        //textBox1.Text=  list.ins_emp;
        //textBox1.Text=  list.up_date.ToString();
        //textBox1.Text=  list.up_emp;
       //textBox8.Text=  list.Directly_Input_Person;
       //textBox10.Text=  list.Indirect_Input_Person;
       //textBox7.Text=  list.Nomal_Direct_WorkTime;
       //textBox9.Text=  list.Nomal_indirect_WorkTime;
       //textBox14.Text=  list.Overtime_Directly_WorkTime;
       //textBox13.Text=  list.Overtime_Indirect_WorkTime;
       //textBox11.Text=  list.Overtime_Directly_Input_Person;
       //textBox12.Text=  list.Overtime_Indirect_Input_Person;
       //textBox18.Text=  list.Directly_Accident_WorkTime;
       //textBox15.Text=  list.Indirect_Accident_WorkTime;
       //textBox1.Text=  list.Overtime_Directly_Accident_Time;
       //textBox17.Text=  list.Overtime_Indirect_Accident_Time;
        }
        /// <summary>
        /// 폼로드 시 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopupShift_Load(object sender, EventArgs e)
        {          
            MachineService service = new MachineService();
            machine = service.GetMachine();
            machine.Insert(0, new MachineVO { machine_name = "" });
            CommonUtil.BindingComboBox(cboMachine, machine, "machine_id", "machine_name");    

            CodeService service1 = new CodeService();
            code = service1.GetAllCommonCode();
            var code1 = (from All in code where All.category == "shift_type" select All).ToList();
            code1.Insert(0, new CodeVO { name = "" });
            CommonUtil.BindingComboBox(cboShift, code1, "code", "name");

            var code2 = (from All in code where All.category == "USE_FLAG" select All).ToList();
            code2.Insert(0, new CodeVO { name = "" });
            CommonUtil.BindingComboBox(cboUse, code2, "code", "name");

            if (openmode != "Insert")
                DataLoad();
        }

      
        /// <summary>
        /// 숫자만 입력
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }

        }
        /// <summary>
        /// 저장버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (openmode != "Update")//등록
            {
                if (cboMachine.SelectedIndex < 0 || cboShift.SelectedIndex < 0 || txtStime.Text.Length < 0 || txtEtime.Text.Length < 0 || dtpEday.Value == null || dtpSday.Value == null)
                {
                    MessageBox.Show("주황글씨는 필수입력입니다.");
                    return;
                }
                ShiftVO emp = new ShiftVO();
                emp.machine_id = cboMachine.SelectedValue.ToString();
                emp.shift_type = cboShift.Text;
                emp.shift_stime = txtStime.Text;
                emp.shift_etime = txtEtime.Text;
                emp.shift_sdate = dtpSday.Value;
                emp.shift_edate = dtpEday.Value;
                emp.shift_use = cboUse.Text;

                emp.Directly_Input_Person = textBox8.Text;
                emp.Indirect_Input_Person = textBox10.Text;
                emp.Nomal_Direct_WorkTime = textBox7.Text;
                emp.Nomal_indirect_WorkTime = textBox9.Text;
                emp.Overtime_Directly_WorkTime = textBox14.Text;
                emp.Overtime_Indirect_WorkTime = textBox13.Text;
                emp.Overtime_Directly_Input_Person = textBox11.Text; 
                emp.Overtime_Indirect_Input_Person = textBox12.Text;
                emp.Directly_Accident_WorkTime = textBox18.Text;
                emp.Indirect_Accident_WorkTime = textBox15.Text;
                emp.Overtime_Directly_Accident_Time = textBox1.Text;
                emp.Overtime_Indirect_Accident_Time = textBox17.Text;
                emp.shift_comment = richTextBox1.Text;
                emp.ins_emp = emp_id;


                ShiftService service = new ShiftService();
                bool bFlag = service.AddShift(emp);

                if (bFlag)
                {
                    MessageBox.Show("저장되었습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    MessageBox.Show("저장 중 오류가 발생하였습니다.");
            }
            else //수정
            {
                if (cboMachine.SelectedIndex < 0 || cboShift.SelectedIndex < 0 || txtStime.Text.Length < 0 || txtEtime.Text.Length < 0 || dtpEday.Value == null || dtpSday.Value == null)
                {
                    MessageBox.Show("주황글씨는 필수입력입니다.");
                    return;
                }
                ShiftVO emp = new ShiftVO();
                emp.shift_id = list.shift_id;
                emp.machine_id = cboMachine.SelectedValue.ToString();
                emp.shift_type = cboShift.Text;
                emp.shift_stime = txtStime.Text;
                emp.shift_etime = txtEtime.Text;
                emp.shift_sdate = dtpSday.Value;
                emp.shift_edate = dtpEday.Value;
                emp.shift_use = cboUse.Text;

                emp.Directly_Input_Person = textBox8.Text;
                emp.Indirect_Input_Person = textBox10.Text;
                emp.Nomal_Direct_WorkTime = textBox7.Text;
                emp.Nomal_indirect_WorkTime = textBox9.Text;
                emp.Overtime_Directly_WorkTime = textBox14.Text;
                emp.Overtime_Indirect_WorkTime = textBox13.Text;
                emp.Overtime_Directly_Input_Person = textBox11.Text;
                emp.Overtime_Indirect_Input_Person = textBox12.Text;
                emp.Directly_Accident_WorkTime = textBox18.Text;
                emp.Indirect_Accident_WorkTime = textBox15.Text;
                emp.Overtime_Directly_Accident_Time = textBox1.Text;
                emp.Overtime_Indirect_Accident_Time = textBox17.Text;
                emp.shift_comment = richTextBox1.Text;
                emp.ins_emp = emp_id;

                ShiftService service = new ShiftService();
                bool bFlag = service.Update(emp);

                if (bFlag)
                {
                    MessageBox.Show("수정되었습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    MessageBox.Show("수정 중 오류가 발생하였습니다.");
            }

        }
        /// <summary>
        /// 데이트타임피커 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpEday_ValueChanged(object sender, EventArgs e)
        {
            //if (dtpSday.Value == dtpEday.Value)
            //    return;
            //if (dtpSday.Value > dtpEday.Value)
            //{
            //    MessageBox.Show("날짜를 다시 입력해주세요");
            //    return;
            //}
        }
        /// <summary>
        /// 취소버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
