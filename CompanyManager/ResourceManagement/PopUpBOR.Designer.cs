
namespace CompanyManager
{
    partial class PopUpBOR
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
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboUse = new System.Windows.Forms.ComboBox();
            this.cboRoute = new System.Windows.Forms.ComboBox();
            this.cboMacine = new System.Windows.Forms.ComboBox();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCompletion = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTack = new System.Windows.Forms.TextBox();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtpreceding = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // popupTitleBar1
            // 
            this.popupTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupTitleBar1.Location = new System.Drawing.Point(0, 0);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(76, 184);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(539, 129);
            this.txtComment.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Gray;
            this.label12.Location = new System.Drawing.Point(7, 187);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 14);
            this.label12.TabIndex = 12;
            this.label12.Text = "* 비고";
            // 
            // cboUse
            // 
            this.cboUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUse.FormattingEnabled = true;
            this.cboUse.Location = new System.Drawing.Point(430, 143);
            this.cboUse.Name = "cboUse";
            this.cboUse.Size = new System.Drawing.Size(185, 22);
            this.cboUse.TabIndex = 11;
            this.cboUse.Tag = "사용유무";
            // 
            // cboRoute
            // 
            this.cboRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoute.FormattingEnabled = true;
            this.cboRoute.Location = new System.Drawing.Point(430, 20);
            this.cboRoute.Name = "cboRoute";
            this.cboRoute.Size = new System.Drawing.Size(185, 22);
            this.cboRoute.TabIndex = 10;
            this.cboRoute.Tag = "공정";
            // 
            // cboMacine
            // 
            this.cboMacine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMacine.FormattingEnabled = true;
            this.cboMacine.Location = new System.Drawing.Point(118, 60);
            this.cboMacine.Name = "cboMacine";
            this.cboMacine.Size = new System.Drawing.Size(186, 22);
            this.cboMacine.TabIndex = 7;
            this.cboMacine.Tag = "설비";
            // 
            // cboItem
            // 
            this.cboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Location = new System.Drawing.Point(118, 20);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(186, 22);
            this.cboItem.TabIndex = 6;
            this.cboItem.Tag = "품목";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(324, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 14);
            this.label6.TabIndex = 3;
            this.label6.Text = "* 공정";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(324, 146);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 14);
            this.label14.TabIndex = 3;
            this.label14.Text = "* 사용유무";
            // 
            // txtCompletion
            // 
            this.txtCompletion.Location = new System.Drawing.Point(120, 143);
            this.txtCompletion.Name = "txtCompletion";
            this.txtCompletion.Size = new System.Drawing.Size(185, 21);
            this.txtCompletion.TabIndex = 4;
            this.txtCompletion.Tag = "수율";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Gray;
            this.label13.Location = new System.Drawing.Point(9, 146);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 14);
            this.label13.TabIndex = 3;
            this.label13.Text = "* 수율";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(324, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 14);
            this.label10.TabIndex = 3;
            this.label10.Text = "* Tack Time(Sec)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(9, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 14);
            this.label8.TabIndex = 3;
            this.label8.Text = "* 설비";
            // 
            // txtTack
            // 
            this.txtTack.Location = new System.Drawing.Point(430, 61);
            this.txtTack.Name = "txtTack";
            this.txtTack.Size = new System.Drawing.Size(184, 21);
            this.txtTack.TabIndex = 4;
            this.txtTack.Tag = "Tact Time";
            this.txtTack.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNum_KeyPress);
            // 
            // txtPriority
            // 
            this.txtPriority.Location = new System.Drawing.Point(430, 102);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(184, 21);
            this.txtPriority.TabIndex = 4;
            this.txtPriority.Tag = "우선순위";
            this.txtPriority.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNum_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(324, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 14);
            this.label9.TabIndex = 3;
            this.label9.Text = "* 우선순위";
            // 
            // txtpreceding
            // 
            this.txtpreceding.Location = new System.Drawing.Point(119, 102);
            this.txtpreceding.Name = "txtpreceding";
            this.txtpreceding.Size = new System.Drawing.Size(185, 21);
            this.txtpreceding.TabIndex = 4;
            this.txtpreceding.Tag = "";
            this.txtpreceding.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyNum_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(147)))), ((int)(((byte)(211)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(233, 397);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 30);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "저장";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(9, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "* 공정선행일(Day)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(9, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "* 품목";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(142)))), ((int)(((byte)(150)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(352, 397);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtComment);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cboUse);
            this.panel1.Controls.Add(this.cboRoute);
            this.panel1.Controls.Add(this.cboMacine);
            this.panel1.Controls.Add(this.cboItem);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtCompletion);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtTack);
            this.panel1.Controls.Add(this.txtPriority);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtpreceding);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 337);
            this.panel1.TabIndex = 10;
            // 
            // PopUpBOR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(669, 439);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.Name = "PopUpBOR";
            this.Load += new System.EventHandler(this.PopUpBOR_Load);
            this.Controls.SetChildIndex(this.popupTitleBar1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboUse;
        private System.Windows.Forms.ComboBox cboRoute;
        private System.Windows.Forms.ComboBox cboMacine;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCompletion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTack;
        private System.Windows.Forms.TextBox txtPriority;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtpreceding;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
    }
}
