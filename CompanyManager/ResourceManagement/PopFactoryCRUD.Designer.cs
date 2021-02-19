
namespace CompanyManager
{
    partial class PopFactoryCRUD
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
            this.cboParent = new System.Windows.Forms.ComboBox();
            this.cboFUse = new System.Windows.Forms.ComboBox();
            this.cboFType = new System.Windows.Forms.ComboBox();
            this.cboFGrade = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtUpEmp = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCRU = new System.Windows.Forms.Button();
            this.cboFParent = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // popupTitleBar1
            // 
            this.popupTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupTitleBar1.HeaderText = "공장정보";
            this.popupTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.popupTitleBar1.Size = new System.Drawing.Size(574, 33);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboFParent);
            this.panel1.Controls.Add(this.cboParent);
            this.panel1.Controls.Add(this.cboFUse);
            this.panel1.Controls.Add(this.cboFType);
            this.panel1.Controls.Add(this.cboFGrade);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtComment);
            this.panel1.Controls.Add(this.txtUpEmp);
            this.panel1.Controls.Add(this.txtFName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 249);
            this.panel1.TabIndex = 7;
            // 
            // cboParent
            // 
            this.cboParent.BackColor = System.Drawing.Color.NavajoWhite;
            this.cboParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParent.Enabled = false;
            this.cboParent.FormattingEnabled = true;
            this.cboParent.Location = new System.Drawing.Point(371, 15);
            this.cboParent.Name = "cboParent";
            this.cboParent.Size = new System.Drawing.Size(190, 22);
            this.cboParent.TabIndex = 1;
            // 
            // cboFUse
            // 
            this.cboFUse.BackColor = System.Drawing.Color.NavajoWhite;
            this.cboFUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFUse.FormattingEnabled = true;
            this.cboFUse.Location = new System.Drawing.Point(79, 69);
            this.cboFUse.Name = "cboFUse";
            this.cboFUse.Size = new System.Drawing.Size(181, 22);
            this.cboFUse.TabIndex = 4;
            // 
            // cboFType
            // 
            this.cboFType.BackColor = System.Drawing.Color.NavajoWhite;
            this.cboFType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFType.FormattingEnabled = true;
            this.cboFType.Location = new System.Drawing.Point(79, 42);
            this.cboFType.Name = "cboFType";
            this.cboFType.Size = new System.Drawing.Size(181, 22);
            this.cboFType.TabIndex = 2;
            // 
            // cboFGrade
            // 
            this.cboFGrade.BackColor = System.Drawing.Color.NavajoWhite;
            this.cboFGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFGrade.FormattingEnabled = true;
            this.cboFGrade.Location = new System.Drawing.Point(79, 15);
            this.cboFGrade.Name = "cboFGrade";
            this.cboFGrade.Size = new System.Drawing.Size(181, 22);
            this.cboFGrade.TabIndex = 0;
            this.cboFGrade.SelectedIndexChanged += new System.EventHandler(this.cboFGrade_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(10, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "* 사용유무";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(284, 45);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 14);
            this.label15.TabIndex = 3;
            this.label15.Text = "* 시설명";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(284, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "* 상위시설";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(10, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "* 설명";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Gray;
            this.label18.Location = new System.Drawing.Point(284, 72);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 14);
            this.label18.TabIndex = 3;
            this.label18.Text = "* 수정자";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(10, 45);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 14);
            this.label16.TabIndex = 3;
            this.label16.Text = "* 시설구분";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(79, 97);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(482, 139);
            this.txtComment.TabIndex = 5;
            // 
            // txtUpEmp
            // 
            this.txtUpEmp.Location = new System.Drawing.Point(371, 69);
            this.txtUpEmp.Name = "txtUpEmp";
            this.txtUpEmp.ReadOnly = true;
            this.txtUpEmp.Size = new System.Drawing.Size(190, 21);
            this.txtUpEmp.TabIndex = 4;
            // 
            // txtFName
            // 
            this.txtFName.BackColor = System.Drawing.Color.NavajoWhite;
            this.txtFName.Location = new System.Drawing.Point(371, 42);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(190, 21);
            this.txtFName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "* 시설군";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(142)))), ((int)(((byte)(150)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(301, 290);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCRU
            // 
            this.btnCRU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCRU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(147)))), ((int)(((byte)(211)))));
            this.btnCRU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCRU.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCRU.ForeColor = System.Drawing.Color.White;
            this.btnCRU.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCRU.Location = new System.Drawing.Point(189, 290);
            this.btnCRU.Name = "btnCRU";
            this.btnCRU.Size = new System.Drawing.Size(85, 30);
            this.btnCRU.TabIndex = 6;
            this.btnCRU.Text = "저장";
            this.btnCRU.UseVisualStyleBackColor = false;
            this.btnCRU.Click += new System.EventHandler(this.btnCRU_Click);
            // 
            // cboFParent
            // 
            this.cboFParent.BackColor = System.Drawing.Color.NavajoWhite;
            this.cboFParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFParent.Enabled = false;
            this.cboFParent.FormattingEnabled = true;
            this.cboFParent.Location = new System.Drawing.Point(371, 15);
            this.cboFParent.Name = "cboFParent";
            this.cboFParent.Size = new System.Drawing.Size(190, 22);
            this.cboFParent.TabIndex = 6;
            // 
            // PopFactoryCRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(574, 327);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCRU);
            this.Name = "PopFactoryCRUD";
            this.Load += new System.EventHandler(this.PopFactoryCRUD_Load);
            this.Controls.SetChildIndex(this.popupTitleBar1, 0);
            this.Controls.SetChildIndex(this.btnCRU, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCRU;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtUpEmp;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.ComboBox cboFUse;
        private System.Windows.Forms.ComboBox cboFType;
        private System.Windows.Forms.ComboBox cboFGrade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboParent;
        private System.Windows.Forms.ComboBox cboFParent;
    }
}
