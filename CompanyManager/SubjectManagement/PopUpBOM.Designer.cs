
namespace CompanyManager
{
    partial class PopUpBOM
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
            this.btnSave = new System.Windows.Forms.Button();
            this.txtcomment = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbosubject = new System.Windows.Forms.ComboBox();
            this.txtupemp = new System.Windows.Forms.TextBox();
            this.txtupdate = new System.Windows.Forms.TextBox();
            this.dtpstart = new System.Windows.Forms.DateTimePicker();
            this.dtpend = new System.Windows.Forms.DateTimePicker();
            this.txtuseqty = new System.Windows.Forms.TextBox();
            this.cboParentsubject = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboplan = new System.Windows.Forms.ComboBox();
            this.cbouse = new System.Windows.Forms.ComboBox();
            this.cboauto = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // popupTitleBar1
            // 
            this.popupTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupTitleBar1.HeaderText = "BOM";
            this.popupTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.popupTitleBar1.Size = new System.Drawing.Size(651, 33);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(147)))), ((int)(((byte)(211)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(228, 432);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 30);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtcomment
            // 
            this.txtcomment.Location = new System.Drawing.Point(91, 216);
            this.txtcomment.Multiline = true;
            this.txtcomment.Name = "txtcomment";
            this.txtcomment.Size = new System.Drawing.Size(502, 135);
            this.txtcomment.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(31, 219);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 14);
            this.label11.TabIndex = 3;
            this.label11.Text = "* 비고";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(142)))), ((int)(((byte)(150)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(337, 432);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbosubject);
            this.panel1.Controls.Add(this.txtupemp);
            this.panel1.Controls.Add(this.txtupdate);
            this.panel1.Controls.Add(this.dtpstart);
            this.panel1.Controls.Add(this.dtpend);
            this.panel1.Controls.Add(this.txtuseqty);
            this.panel1.Controls.Add(this.cboParentsubject);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboplan);
            this.panel1.Controls.Add(this.cbouse);
            this.panel1.Controls.Add(this.cboauto);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtcomment);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(12, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 377);
            this.panel1.TabIndex = 8;
            // 
            // cbosubject
            // 
            this.cbosubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbosubject.FormattingEnabled = true;
            this.cbosubject.Location = new System.Drawing.Point(421, 22);
            this.cbosubject.Name = "cbosubject";
            this.cbosubject.Size = new System.Drawing.Size(169, 22);
            this.cbosubject.TabIndex = 128;
            this.cbosubject.Tag = "품목";
            // 
            // txtupemp
            // 
            this.txtupemp.Location = new System.Drawing.Point(130, 138);
            this.txtupemp.Name = "txtupemp";
            this.txtupemp.ReadOnly = true;
            this.txtupemp.Size = new System.Drawing.Size(169, 21);
            this.txtupemp.TabIndex = 127;
            // 
            // txtupdate
            // 
            this.txtupdate.Location = new System.Drawing.Point(424, 138);
            this.txtupdate.Name = "txtupdate";
            this.txtupdate.ReadOnly = true;
            this.txtupdate.Size = new System.Drawing.Size(169, 21);
            this.txtupdate.TabIndex = 126;
            // 
            // dtpstart
            // 
            this.dtpstart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpstart.Location = new System.Drawing.Point(421, 58);
            this.dtpstart.Name = "dtpstart";
            this.dtpstart.Size = new System.Drawing.Size(172, 21);
            this.dtpstart.TabIndex = 125;
            // 
            // dtpend
            // 
            this.dtpend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpend.Location = new System.Drawing.Point(127, 97);
            this.dtpend.Name = "dtpend";
            this.dtpend.Size = new System.Drawing.Size(172, 21);
            this.dtpend.TabIndex = 124;
            // 
            // txtuseqty
            // 
            this.txtuseqty.Location = new System.Drawing.Point(130, 60);
            this.txtuseqty.Name = "txtuseqty";
            this.txtuseqty.Size = new System.Drawing.Size(169, 21);
            this.txtuseqty.TabIndex = 123;
            this.txtuseqty.Tag = "소요량";
            this.txtuseqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNum_KeyPress);
            // 
            // cboParentsubject
            // 
            this.cboParentsubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParentsubject.FormattingEnabled = true;
            this.cboParentsubject.Location = new System.Drawing.Point(130, 22);
            this.cboParentsubject.Name = "cboParentsubject";
            this.cboParentsubject.Size = new System.Drawing.Size(169, 22);
            this.cboParentsubject.TabIndex = 122;
            this.cboParentsubject.Tag = "상위품목";
            this.cboParentsubject.SelectedIndexChanged += new System.EventHandler(this.cboParentsubject_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(333, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 14);
            this.label4.TabIndex = 121;
            this.label4.Text = "* 시작일";
            // 
            // cboplan
            // 
            this.cboplan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboplan.FormattingEnabled = true;
            this.cboplan.Location = new System.Drawing.Point(424, 177);
            this.cboplan.Name = "cboplan";
            this.cboplan.Size = new System.Drawing.Size(169, 22);
            this.cboplan.TabIndex = 120;
            this.cboplan.Tag = "소요계획";
            // 
            // cbouse
            // 
            this.cbouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbouse.FormattingEnabled = true;
            this.cbouse.Location = new System.Drawing.Point(424, 99);
            this.cbouse.Name = "cbouse";
            this.cbouse.Size = new System.Drawing.Size(169, 22);
            this.cbouse.TabIndex = 118;
            this.cbouse.Tag = "사용유무";
            // 
            // cboauto
            // 
            this.cboauto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboauto.FormattingEnabled = true;
            this.cboauto.Location = new System.Drawing.Point(130, 177);
            this.cboauto.Name = "cboauto";
            this.cboauto.Size = new System.Drawing.Size(169, 22);
            this.cboauto.TabIndex = 114;
            this.cboauto.Tag = "자동차감";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(333, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 14);
            this.label10.TabIndex = 102;
            this.label10.Text = "* 수정일";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(333, 180);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 14);
            this.label14.TabIndex = 105;
            this.label14.Text = "* 소요계획";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(333, 102);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 14);
            this.label15.TabIndex = 104;
            this.label15.Text = "* 사용유무";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label17.Location = new System.Drawing.Point(333, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 14);
            this.label17.TabIndex = 107;
            this.label17.Text = "* 품목";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(31, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 14);
            this.label8.TabIndex = 98;
            this.label8.Text = "* 수정자";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(31, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 14);
            this.label7.TabIndex = 97;
            this.label7.Text = "* 자동차감";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(31, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 14);
            this.label3.TabIndex = 96;
            this.label3.Text = "* 종료일";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(31, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 95;
            this.label2.Text = "* 소요량";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(31, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 14);
            this.label1.TabIndex = 94;
            this.label1.Text = "* 상위품목";
            // 
            // PopUpBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(651, 474);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.Name = "PopUpBOM";
            this.Load += new System.EventHandler(this.PopUpBOM_Load);
            this.Controls.SetChildIndex(this.popupTitleBar1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtcomment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtupemp;
        private System.Windows.Forms.TextBox txtupdate;
        private System.Windows.Forms.DateTimePicker dtpstart;
        private System.Windows.Forms.DateTimePicker dtpend;
        private System.Windows.Forms.TextBox txtuseqty;
        private System.Windows.Forms.ComboBox cboParentsubject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboplan;
        private System.Windows.Forms.ComboBox cbouse;
        private System.Windows.Forms.ComboBox cboauto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbosubject;
    }
}
