
namespace CompanyManager
{
    partial class PopMachineCRUD
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
            this.lblmgrade = new System.Windows.Forms.Label();
            this.cboOSuse = new System.Windows.Forms.ComboBox();
            this.cboUse = new System.Windows.Forms.ComboBox();
            this.cboNGWh = new System.Windows.Forms.ComboBox();
            this.cboOKWh = new System.Windows.Forms.ComboBox();
            this.cboUseWh = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUpEmp = new System.Windows.Forms.TextBox();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMachineID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCencel = new System.Windows.Forms.Button();
            this.btnCRU = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // popupTitleBar1
            // 
            this.popupTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupTitleBar1.HeaderText = "설비";
            this.popupTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.popupTitleBar1.Size = new System.Drawing.Size(604, 33);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblmgrade);
            this.panel1.Controls.Add(this.cboOSuse);
            this.panel1.Controls.Add(this.cboUse);
            this.panel1.Controls.Add(this.cboNGWh);
            this.panel1.Controls.Add(this.cboOKWh);
            this.panel1.Controls.Add(this.cboUseWh);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtComment);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtUpEmp);
            this.panel1.Controls.Add(this.txtMachineName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtMachineID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 247);
            this.panel1.TabIndex = 7;
            // 
            // lblmgrade
            // 
            this.lblmgrade.AutoSize = true;
            this.lblmgrade.ForeColor = System.Drawing.Color.White;
            this.lblmgrade.Location = new System.Drawing.Point(11, 185);
            this.lblmgrade.Name = "lblmgrade";
            this.lblmgrade.Size = new System.Drawing.Size(0, 14);
            this.lblmgrade.TabIndex = 6;
            this.lblmgrade.Visible = false;
            // 
            // cboOSuse
            // 
            this.cboOSuse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOSuse.FormattingEnabled = true;
            this.cboOSuse.Location = new System.Drawing.Point(93, 68);
            this.cboOSuse.Name = "cboOSuse";
            this.cboOSuse.Size = new System.Drawing.Size(95, 22);
            this.cboOSuse.TabIndex = 6;
            // 
            // cboUse
            // 
            this.cboUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUse.FormattingEnabled = true;
            this.cboUse.Location = new System.Drawing.Point(491, 13);
            this.cboUse.Name = "cboUse";
            this.cboUse.Size = new System.Drawing.Size(95, 22);
            this.cboUse.TabIndex = 2;
            // 
            // cboNGWh
            // 
            this.cboNGWh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNGWh.FormattingEnabled = true;
            this.cboNGWh.Location = new System.Drawing.Point(491, 41);
            this.cboNGWh.Name = "cboNGWh";
            this.cboNGWh.Size = new System.Drawing.Size(95, 22);
            this.cboNGWh.TabIndex = 5;
            // 
            // cboOKWh
            // 
            this.cboOKWh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOKWh.FormattingEnabled = true;
            this.cboOKWh.Location = new System.Drawing.Point(291, 40);
            this.cboOKWh.Name = "cboOKWh";
            this.cboOKWh.Size = new System.Drawing.Size(95, 22);
            this.cboOKWh.TabIndex = 4;
            // 
            // cboUseWh
            // 
            this.cboUseWh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUseWh.FormattingEnabled = true;
            this.cboUseWh.Location = new System.Drawing.Point(93, 40);
            this.cboUseWh.Name = "cboUseWh";
            this.cboUseWh.Size = new System.Drawing.Size(95, 22);
            this.cboUseWh.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(414, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "* 불량창고";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(414, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "* 사용유무";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(19, 110);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(567, 120);
            this.txtComment.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(215, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "* 수정자";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(16, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 14);
            this.label10.TabIndex = 3;
            this.label10.Text = "* 특이사항 및 비고";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(16, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 14);
            this.label11.TabIndex = 3;
            this.label11.Text = "* 외주여부";
            // 
            // txtUpEmp
            // 
            this.txtUpEmp.Location = new System.Drawing.Point(291, 67);
            this.txtUpEmp.Name = "txtUpEmp";
            this.txtUpEmp.ReadOnly = true;
            this.txtUpEmp.Size = new System.Drawing.Size(95, 21);
            this.txtUpEmp.TabIndex = 99;
            this.txtUpEmp.TabStop = false;
            // 
            // txtMachineName
            // 
            this.txtMachineName.Location = new System.Drawing.Point(292, 13);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(95, 21);
            this.txtMachineName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(215, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "* 양품창고";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(215, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 14);
            this.label15.TabIndex = 3;
            this.label15.Text = "* 설비명";
            // 
            // txtMachineID
            // 
            this.txtMachineID.Location = new System.Drawing.Point(93, 13);
            this.txtMachineID.Name = "txtMachineID";
            this.txtMachineID.Size = new System.Drawing.Size(95, 21);
            this.txtMachineID.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(16, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "* 소진창고";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "* 설비군코드";
            // 
            // btnCencel
            // 
            this.btnCencel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCencel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(142)))), ((int)(((byte)(150)))));
            this.btnCencel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCencel.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCencel.ForeColor = System.Drawing.Color.White;
            this.btnCencel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCencel.Location = new System.Drawing.Point(306, 286);
            this.btnCencel.Name = "btnCencel";
            this.btnCencel.Size = new System.Drawing.Size(85, 30);
            this.btnCencel.TabIndex = 9;
            this.btnCencel.Text = "취소";
            this.btnCencel.UseVisualStyleBackColor = false;
            this.btnCencel.Click += new System.EventHandler(this.btnCencel_Click);
            // 
            // btnCRU
            // 
            this.btnCRU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCRU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(147)))), ((int)(((byte)(211)))));
            this.btnCRU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCRU.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCRU.ForeColor = System.Drawing.Color.White;
            this.btnCRU.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCRU.Location = new System.Drawing.Point(215, 286);
            this.btnCRU.Name = "btnCRU";
            this.btnCRU.Size = new System.Drawing.Size(85, 30);
            this.btnCRU.TabIndex = 8;
            this.btnCRU.Text = "저장";
            this.btnCRU.UseVisualStyleBackColor = false;
            this.btnCRU.Click += new System.EventHandler(this.btnCRU_Click);
            // 
            // PopMachineCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(604, 321);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCencel);
            this.Controls.Add(this.btnCRU);
            this.Name = "PopMachineCRUD";
            this.Load += new System.EventHandler(this.PopMachineCRUD_Load);
            this.Controls.SetChildIndex(this.popupTitleBar1, 0);
            this.Controls.SetChildIndex(this.btnCRU, 0);
            this.Controls.SetChildIndex(this.btnCencel, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMachineID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCencel;
        private System.Windows.Forms.Button btnCRU;
        private System.Windows.Forms.ComboBox cboOSuse;
        private System.Windows.Forms.ComboBox cboUse;
        private System.Windows.Forms.ComboBox cboNGWh;
        private System.Windows.Forms.ComboBox cboOKWh;
        private System.Windows.Forms.ComboBox cboUseWh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtUpEmp;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblmgrade;
    }
}
