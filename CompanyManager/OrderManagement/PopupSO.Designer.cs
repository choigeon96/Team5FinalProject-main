
namespace CompanyManager
{
    partial class PopupSO
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOQty = new System.Windows.Forms.TextBox();
            this.txtCQty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSQty = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboCurrency = new System.Windows.Forms.ComboBox();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.cboDest = new System.Windows.Forms.ComboBox();
            this.cboMkt = new System.Windows.Forms.ComboBox();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // popupTitleBar1
            // 
            this.popupTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupTitleBar1.HeaderText = "S/O";
            this.popupTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.popupTitleBar1.Size = new System.Drawing.Size(616, 33);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(324, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "* 품목";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(9, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "* 도착지";
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(411, 18);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(185, 21);
            this.txtOrderID.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(323, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "* 고객주문번호";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(324, 185);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 14);
            this.label14.TabIndex = 3;
            this.label14.Text = "* 환종";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(9, 185);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 14);
            this.label13.TabIndex = 3;
            this.label13.Text = "* Market";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(324, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 14);
            this.label10.TabIndex = 3;
            this.label10.Text = "* 주문수량";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(9, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 14);
            this.label8.TabIndex = 3;
            this.label8.Text = "* 납기일";
            // 
            // txtOQty
            // 
            this.txtOQty.Location = new System.Drawing.Point(412, 100);
            this.txtOQty.Name = "txtOQty";
            this.txtOQty.Size = new System.Drawing.Size(184, 21);
            this.txtOQty.TabIndex = 4;
            this.txtOQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextBox_KeyPress);
            // 
            // txtCQty
            // 
            this.txtCQty.Location = new System.Drawing.Point(412, 141);
            this.txtCQty.Name = "txtCQty";
            this.txtCQty.Size = new System.Drawing.Size(184, 21);
            this.txtCQty.TabIndex = 4;
            this.txtCQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextBox_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(324, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 14);
            this.label9.TabIndex = 3;
            this.label9.Text = "* 취소수량";
            // 
            // txtSQty
            // 
            this.txtSQty.Location = new System.Drawing.Point(77, 141);
            this.txtSQty.Name = "txtSQty";
            this.txtSQty.ReadOnly = true;
            this.txtSQty.Size = new System.Drawing.Size(185, 21);
            this.txtSQty.TabIndex = 4;
            this.txtSQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextBox_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(9, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "* 출고수량";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(9, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "* 고객사";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dtpDueDate);
            this.panel1.Controls.Add(this.txtComment);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cboCurrency);
            this.panel1.Controls.Add(this.cboItem);
            this.panel1.Controls.Add(this.cboDest);
            this.panel1.Controls.Add(this.cboMkt);
            this.panel1.Controls.Add(this.cboCompany);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtOrderID);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtOQty);
            this.panel1.Controls.Add(this.txtCQty);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtSQty);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 376);
            this.panel1.TabIndex = 7;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Location = new System.Drawing.Point(77, 100);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(186, 21);
            this.dtpDueDate.TabIndex = 14;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(80, 226);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(519, 129);
            this.txtComment.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(11, 229);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 14);
            this.label12.TabIndex = 12;
            this.label12.Text = "* 비고";
            // 
            // cboCurrency
            // 
            this.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Location = new System.Drawing.Point(412, 182);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(185, 22);
            this.cboCurrency.TabIndex = 11;
            // 
            // cboItem
            // 
            this.cboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Location = new System.Drawing.Point(412, 59);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(185, 22);
            this.cboItem.TabIndex = 10;
            // 
            // cboDest
            // 
            this.cboDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDest.FormattingEnabled = true;
            this.cboDest.Location = new System.Drawing.Point(78, 59);
            this.cboDest.Name = "cboDest";
            this.cboDest.Size = new System.Drawing.Size(185, 22);
            this.cboDest.TabIndex = 9;
            // 
            // cboMkt
            // 
            this.cboMkt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMkt.FormattingEnabled = true;
            this.cboMkt.Location = new System.Drawing.Point(77, 182);
            this.cboMkt.Name = "cboMkt";
            this.cboMkt.Size = new System.Drawing.Size(186, 22);
            this.cboMkt.TabIndex = 7;
            // 
            // cboCompany
            // 
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(76, 18);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(186, 22);
            this.cboCompany.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(142)))), ((int)(((byte)(150)))));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(312, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "취소";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(147)))), ((int)(((byte)(211)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(221, 443);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // PopupSO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(616, 494);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Name = "PopupSO";
            this.Load += new System.EventHandler(this.PopupSO_Load);
            this.Controls.SetChildIndex(this.popupTitleBar1, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOQty;
        private System.Windows.Forms.TextBox txtCQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSQty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cboCurrency;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.ComboBox cboDest;
        private System.Windows.Forms.ComboBox cboMkt;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
    }
}
