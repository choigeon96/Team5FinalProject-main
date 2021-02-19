
namespace CompanyManager
{
    partial class PopEmployeeCRUD
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpEmp = new System.Windows.Forms.DateTimePicker();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.txtUp_Emp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblIDchk = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmpID = new System.Windows.Forms.TextBox();
            this.emp_id = new System.Windows.Forms.Label();
            this.btnCencel = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lbldept_id = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // popupTitleBar1
            // 
            this.popupTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupTitleBar1.HeaderText = "직원";
            this.popupTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.popupTitleBar1.Size = new System.Drawing.Size(479, 33);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dtpEmp);
            this.panel1.Controls.Add(this.cboDept);
            this.panel1.Controls.Add(this.txtUp_Emp);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblIDchk);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtEmpName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtEmpID);
            this.panel1.Controls.Add(this.emp_id);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 147);
            this.panel1.TabIndex = 7;
            // 
            // dtpEmp
            // 
            this.dtpEmp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEmp.Location = new System.Drawing.Point(90, 108);
            this.dtpEmp.Name = "dtpEmp";
            this.dtpEmp.Size = new System.Drawing.Size(104, 21);
            this.dtpEmp.TabIndex = 4;
            // 
            // cboDept
            // 
            this.cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(300, 64);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(154, 22);
            this.cboDept.TabIndex = 3;
            this.cboDept.SelectedIndexChanged += new System.EventHandler(this.cboDept_SelectedIndexChanged);
            // 
            // txtUp_Emp
            // 
            this.txtUp_Emp.Location = new System.Drawing.Point(300, 108);
            this.txtUp_Emp.Name = "txtUp_Emp";
            this.txtUp_Emp.ReadOnly = true;
            this.txtUp_Emp.Size = new System.Drawing.Size(154, 21);
            this.txtUp_Emp.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(217, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "* 부서";
            // 
            // lblIDchk
            // 
            this.lblIDchk.AutoSize = true;
            this.lblIDchk.ForeColor = System.Drawing.Color.White;
            this.lblIDchk.Location = new System.Drawing.Point(87, 43);
            this.lblIDchk.Name = "lblIDchk";
            this.lblIDchk.Size = new System.Drawing.Size(0, 14);
            this.lblIDchk.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(301, 20);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(154, 21);
            this.txtPassword.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(217, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "* 비밀번호";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(217, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "* 수정자";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(16, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 14);
            this.label10.TabIndex = 3;
            this.label10.Text = "* 입사일";
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(90, 62);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(104, 21);
            this.txtEmpName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(17, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "* 직원명";
            // 
            // txtEmpID
            // 
            this.txtEmpID.Location = new System.Drawing.Point(90, 19);
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.Size = new System.Drawing.Size(104, 21);
            this.txtEmpID.TabIndex = 0;
            this.txtEmpID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpID_KeyPress);
            this.txtEmpID.Leave += new System.EventHandler(this.txtEmpID_Leave);
            // 
            // emp_id
            // 
            this.emp_id.AutoSize = true;
            this.emp_id.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.emp_id.Location = new System.Drawing.Point(16, 23);
            this.emp_id.Name = "emp_id";
            this.emp_id.Size = new System.Drawing.Size(51, 14);
            this.emp_id.TabIndex = 3;
            this.emp_id.Text = "* 직원ID";
            // 
            // btnCencel
            // 
            this.btnCencel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCencel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(142)))), ((int)(((byte)(150)))));
            this.btnCencel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCencel.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCencel.ForeColor = System.Drawing.Color.White;
            this.btnCencel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCencel.Location = new System.Drawing.Point(272, 186);
            this.btnCencel.Name = "btnCencel";
            this.btnCencel.Size = new System.Drawing.Size(85, 30);
            this.btnCencel.TabIndex = 6;
            this.btnCencel.Text = "취소";
            this.btnCencel.UseVisualStyleBackColor = false;
            this.btnCencel.Click += new System.EventHandler(this.btnCencel_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(147)))), ((int)(((byte)(211)))));
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegister.Location = new System.Drawing.Point(122, 186);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(85, 30);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "저장";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lbldept_id
            // 
            this.lbldept_id.AutoSize = true;
            this.lbldept_id.ForeColor = System.Drawing.Color.White;
            this.lbldept_id.Location = new System.Drawing.Point(467, 202);
            this.lbldept_id.Name = "lbldept_id";
            this.lbldept_id.Size = new System.Drawing.Size(0, 14);
            this.lbldept_id.TabIndex = 3;
            // 
            // PopEmployeeCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(479, 224);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCencel);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lbldept_id);
            this.Name = "PopEmployeeCRUD";
            this.Load += new System.EventHandler(this.PopEmployeeCRUD_Load);
            this.Controls.SetChildIndex(this.lbldept_id, 0);
            this.Controls.SetChildIndex(this.popupTitleBar1, 0);
            this.Controls.SetChildIndex(this.btnRegister, 0);
            this.Controls.SetChildIndex(this.btnCencel, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtUp_Emp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmpID;
        private System.Windows.Forms.Label emp_id;
        private System.Windows.Forms.Button btnCencel;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.DateTimePicker dtpEmp;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbldept_id;
        private System.Windows.Forms.Label lblIDchk;
    }
}
