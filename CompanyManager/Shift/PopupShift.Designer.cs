
namespace CompanyManager
{
    partial class PopupShift
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.dtpEday = new System.Windows.Forms.DateTimePicker();
            this.dtpSday = new System.Windows.Forms.DateTimePicker();
            this.cboShift = new System.Windows.Forms.ComboBox();
            this.cboUse = new System.Windows.Forms.ComboBox();
            this.cboMachine = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEtime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(142)))), ((int)(((byte)(150)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(338, 598);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(147)))), ((int)(((byte)(211)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(247, 598);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.dtpEday);
            this.panel1.Controls.Add(this.dtpSday);
            this.panel1.Controls.Add(this.cboShift);
            this.panel1.Controls.Add(this.cboUse);
            this.panel1.Controls.Add(this.cboMachine);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtEtime);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox14);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.textBox8);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textBox17);
            this.panel1.Controls.Add(this.textBox13);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBox12);
            this.panel1.Controls.Add(this.textBox10);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textBox18);
            this.panel1.Controls.Add(this.textBox15);
            this.panel1.Controls.Add(this.textBox9);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.textBox11);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtStime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 546);
            this.panel1.TabIndex = 5;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(91, 369);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(563, 163);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // dtpEday
            // 
            this.dtpEday.Location = new System.Drawing.Point(485, 84);
            this.dtpEday.Name = "dtpEday";
            this.dtpEday.Size = new System.Drawing.Size(169, 21);
            this.dtpEday.TabIndex = 7;
            this.dtpEday.ValueChanged += new System.EventHandler(this.dtpEday_ValueChanged);
            // 
            // dtpSday
            // 
            this.dtpSday.Location = new System.Drawing.Point(156, 84);
            this.dtpSday.Name = "dtpSday";
            this.dtpSday.Size = new System.Drawing.Size(169, 21);
            this.dtpSday.TabIndex = 7;
            this.dtpSday.ValueChanged += new System.EventHandler(this.dtpEday_ValueChanged);
            // 
            // cboShift
            // 
            this.cboShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShift.FormattingEnabled = true;
            this.cboShift.Location = new System.Drawing.Point(485, 20);
            this.cboShift.Name = "cboShift";
            this.cboShift.Size = new System.Drawing.Size(169, 22);
            this.cboShift.TabIndex = 5;
            // 
            // cboUse
            // 
            this.cboUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUse.FormattingEnabled = true;
            this.cboUse.Location = new System.Drawing.Point(156, 335);
            this.cboUse.Name = "cboUse";
            this.cboUse.Size = new System.Drawing.Size(169, 22);
            this.cboUse.TabIndex = 5;
            // 
            // cboMachine
            // 
            this.cboMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMachine.FormattingEnabled = true;
            this.cboMachine.Location = new System.Drawing.Point(156, 20);
            this.cboMachine.Name = "cboMachine";
            this.cboMachine.Size = new System.Drawing.Size(169, 22);
            this.cboMachine.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(348, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "* 적용완료일자";
            // 
            // txtEtime
            // 
            this.txtEtime.Location = new System.Drawing.Point(485, 53);
            this.txtEtime.Name = "txtEtime";
            this.txtEtime.Size = new System.Drawing.Size(169, 21);
            this.txtEtime.TabIndex = 4;
            this.txtEtime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(348, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "* 완료시간";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(348, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "* Shift ID";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(156, 177);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(169, 21);
            this.textBox14.TabIndex = 4;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Gray;
            this.label23.Location = new System.Drawing.Point(348, 279);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(105, 14);
            this.label23.TabIndex = 3;
            this.label23.Text = "* 잔업간접사고시간";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Gray;
            this.label14.Location = new System.Drawing.Point(348, 180);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 14);
            this.label14.TabIndex = 3;
            this.label14.Text = "* 잔업간접작업시간";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(156, 111);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(169, 21);
            this.textBox8.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Gray;
            this.label13.Location = new System.Drawing.Point(16, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 14);
            this.label13.TabIndex = 3;
            this.label13.Text = "* 잔업직접작업시간";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(348, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 14);
            this.label10.TabIndex = 3;
            this.label10.Text = "* 간접투입인원";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(485, 276);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(169, 21);
            this.textBox17.TabIndex = 4;
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(485, 177);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(169, 21);
            this.textBox13.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(16, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 14);
            this.label8.TabIndex = 3;
            this.label8.Text = "* 직접투입인원";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(485, 210);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(169, 21);
            this.textBox12.TabIndex = 4;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(485, 111);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(169, 21);
            this.textBox10.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(348, 213);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 14);
            this.label12.TabIndex = 3;
            this.label12.Text = "* 잔업간접투입인원";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(156, 276);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 21);
            this.textBox1.TabIndex = 4;
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(156, 243);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(169, 21);
            this.textBox18.TabIndex = 4;
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(485, 243);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(169, 21);
            this.textBox15.TabIndex = 4;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(485, 144);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(169, 21);
            this.textBox9.TabIndex = 4;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Gray;
            this.label21.Location = new System.Drawing.Point(348, 248);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(105, 14);
            this.label21.TabIndex = 3;
            this.label21.Text = "* 간접사고작업시간";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(156, 210);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(169, 21);
            this.textBox11.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(348, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 14);
            this.label9.TabIndex = 3;
            this.label9.Text = "* 정상간접작업시간";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Gray;
            this.label16.Location = new System.Drawing.Point(16, 369);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 14);
            this.label16.TabIndex = 3;
            this.label16.Text = "* 비고";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Gray;
            this.label18.Location = new System.Drawing.Point(16, 279);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(105, 14);
            this.label18.TabIndex = 3;
            this.label18.Text = "* 잔업직접사고시간";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Gray;
            this.label15.Location = new System.Drawing.Point(16, 246);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 14);
            this.label15.TabIndex = 3;
            this.label15.Text = "* 직접사고작업시간";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(16, 213);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 14);
            this.label11.TabIndex = 3;
            this.label11.Text = "* 잔업직접투입인원";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(156, 144);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(169, 21);
            this.textBox7.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(16, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "* 정상직접작업시간";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label19.Location = new System.Drawing.Point(16, 338);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 14);
            this.label19.TabIndex = 3;
            this.label19.Text = "* 사용유무";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(16, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "* 적용시작일자";
            // 
            // txtStime
            // 
            this.txtStime.Location = new System.Drawing.Point(156, 53);
            this.txtStime.Name = "txtStime";
            this.txtStime.Size = new System.Drawing.Size(169, 21);
            this.txtStime.TabIndex = 4;
            this.txtStime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "* 시작시간";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "* 설비코드";
            // 
            // PopupShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(671, 636);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "PopupShift";
            this.Load += new System.EventHandler(this.PopupShift_Load);
            this.Controls.SetChildIndex(this.popupTitleBar1, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEtime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DateTimePicker dtpEday;
        private System.Windows.Forms.DateTimePicker dtpSday;
        private System.Windows.Forms.ComboBox cboShift;
        private System.Windows.Forms.ComboBox cboMachine;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cboUse;
        
    }
}
