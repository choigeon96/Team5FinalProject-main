
namespace CompanyManager
{
    partial class FrmShipment
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.cboWarehouse = new System.Windows.Forms.ComboBox();
            this.cboDest = new System.Windows.Forms.ComboBox();
            this.txtSOID = new System.Windows.Forms.TextBox();
            this.txtWOID = new System.Windows.Forms.TextBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnCommit = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btxExcel = new System.Windows.Forms.Button();
            this.dgvShipment = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipment)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlSearch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCommit);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.btxExcel);
            this.splitContainer1.Panel2.Controls.Add(this.dgvShipment);
            this.splitContainer1.Size = new System.Drawing.Size(1168, 647);
            this.splitContainer1.SplitterDistance = 130;
            this.splitContainer1.TabIndex = 25;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.label20);
            this.pnlSearch.Controls.Add(this.dtpTo);
            this.pnlSearch.Controls.Add(this.dtpFrom);
            this.pnlSearch.Controls.Add(this.cboWarehouse);
            this.pnlSearch.Controls.Add(this.cboDest);
            this.pnlSearch.Controls.Add(this.txtSOID);
            this.pnlSearch.Controls.Add(this.txtWOID);
            this.pnlSearch.Controls.Add(this.txtItem);
            this.pnlSearch.Controls.Add(this.cboCompany);
            this.pnlSearch.Controls.Add(this.label9);
            this.pnlSearch.Controls.Add(this.label11);
            this.pnlSearch.Controls.Add(this.label7);
            this.pnlSearch.Controls.Add(this.label8);
            this.pnlSearch.Controls.Add(this.label5);
            this.pnlSearch.Controls.Add(this.label6);
            this.pnlSearch.Controls.Add(this.label3);
            this.pnlSearch.Controls.Add(this.label4);
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Controls.Add(this.label2);
            this.pnlSearch.Controls.Add(this.btnDown);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.label12);
            this.pnlSearch.Controls.Add(this.label14);
            this.pnlSearch.Controls.Add(this.label16);
            this.pnlSearch.Controls.Add(this.label18);
            this.pnlSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pnlSearch.Location = new System.Drawing.Point(10, 12);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1146, 114);
            this.pnlSearch.TabIndex = 22;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(169, 23);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(15, 14);
            this.label20.TabIndex = 76;
            this.label20.Text = "~";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(187, 18);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(85, 21);
            this.dtpTo.TabIndex = 75;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(79, 18);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(85, 21);
            this.dtpFrom.TabIndex = 74;
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarehouse.FormattingEnabled = true;
            this.cboWarehouse.Location = new System.Drawing.Point(79, 45);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Size = new System.Drawing.Size(193, 22);
            this.cboWarehouse.TabIndex = 73;
            // 
            // cboDest
            // 
            this.cboDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDest.FormattingEnabled = true;
            this.cboDest.Location = new System.Drawing.Point(783, 18);
            this.cboDest.Name = "cboDest";
            this.cboDest.Size = new System.Drawing.Size(193, 22);
            this.cboDest.TabIndex = 72;
            // 
            // txtSOID
            // 
            this.txtSOID.Location = new System.Drawing.Point(79, 72);
            this.txtSOID.Name = "txtSOID";
            this.txtSOID.Size = new System.Drawing.Size(193, 21);
            this.txtSOID.TabIndex = 71;
            this.txtSOID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericCheck);
            // 
            // txtWOID
            // 
            this.txtWOID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWOID.Location = new System.Drawing.Point(783, 45);
            this.txtWOID.Name = "txtWOID";
            this.txtWOID.Size = new System.Drawing.Size(193, 21);
            this.txtWOID.TabIndex = 70;
            this.txtWOID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericCheck);
            // 
            // txtItem
            // 
            this.txtItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtItem.Location = new System.Drawing.Point(420, 46);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(193, 21);
            this.txtItem.TabIndex = 69;
            // 
            // cboCompany
            // 
            this.cboCompany.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(420, 18);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(193, 22);
            this.cboCompany.TabIndex = 68;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 14);
            this.label9.TabIndex = 67;
            this.label9.Text = "* SO ID";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label11.Location = new System.Drawing.Point(12, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 14);
            this.label11.TabIndex = 66;
            this.label11.Text = "label2";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(694, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 14);
            this.label7.TabIndex = 65;
            this.label7.Text = "* 고객주문번호";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label8.Location = new System.Drawing.Point(694, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 14);
            this.label8.TabIndex = 64;
            this.label8.Text = "label2";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(353, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 63;
            this.label5.Text = "* 품목";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label6.Location = new System.Drawing.Point(353, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 14);
            this.label6.TabIndex = 62;
            this.label6.Text = "label2";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(694, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 14);
            this.label3.TabIndex = 61;
            this.label3.Text = "* 도착지";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label4.Location = new System.Drawing.Point(695, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 14);
            this.label4.TabIndex = 60;
            this.label4.Text = "label4";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 59;
            this.label1.Text = "* 고객사";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label2.Location = new System.Drawing.Point(355, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 14);
            this.label2.TabIndex = 58;
            this.label2.Text = "label2";
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.BackColor = System.Drawing.Color.White;
            this.btnDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(102)))), ((int)(((byte)(198)))));
            this.btnDown.FlatAppearance.BorderSize = 2;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(102)))), ((int)(((byte)(198)))));
            this.btnDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDown.Location = new System.Drawing.Point(1104, 74);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(28, 28);
            this.btnDown.TabIndex = 57;
            this.btnDown.Text = "ᐱ";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(102)))), ((int)(((byte)(198)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(990, 73);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(116, 30);
            this.btnSearch.TabIndex = 56;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 14);
            this.label12.TabIndex = 55;
            this.label12.Text = "* 출하창고";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 14);
            this.label14.TabIndex = 54;
            this.label14.Text = "* 납기일";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label16.Location = new System.Drawing.Point(12, 45);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 14);
            this.label16.TabIndex = 53;
            this.label16.Text = "label2";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label18.Location = new System.Drawing.Point(13, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 14);
            this.label18.TabIndex = 52;
            this.label18.Text = "label18";
            // 
            // btnCommit
            // 
            this.btnCommit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.btnCommit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommit.Image = global::CompanyManager.Properties.Resources.Edit_16x16;
            this.btnCommit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCommit.Location = new System.Drawing.Point(1026, 3);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(76, 23);
            this.btnCommit.TabIndex = 56;
            this.btnCommit.Text = "출하처리";
            this.btnCommit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCommit.UseVisualStyleBackColor = false;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Image = global::CompanyManager.Properties.Resources.AlignJustify_16x16;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(14, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 14);
            this.label10.TabIndex = 52;
            this.label10.Text = "      고객주문";
            // 
            // btxExcel
            // 
            this.btxExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btxExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.btxExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btxExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btxExcel.Image = global::CompanyManager.Properties.Resources.New_16x16;
            this.btxExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btxExcel.Location = new System.Drawing.Point(1108, 3);
            this.btxExcel.Name = "btxExcel";
            this.btxExcel.Size = new System.Drawing.Size(54, 23);
            this.btxExcel.TabIndex = 54;
            this.btxExcel.Text = "    엑셀";
            this.btxExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btxExcel.UseVisualStyleBackColor = false;
            this.btxExcel.Click += new System.EventHandler(this.btxExcel_Click);
            // 
            // dgvShipment
            // 
            this.dgvShipment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShipment.BackgroundColor = System.Drawing.Color.White;
            this.dgvShipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShipment.Location = new System.Drawing.Point(10, 32);
            this.dgvShipment.Name = "dgvShipment";
            this.dgvShipment.RowTemplate.Height = 23;
            this.dgvShipment.Size = new System.Drawing.Size(1152, 469);
            this.dgvShipment.TabIndex = 55;
            this.dgvShipment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShipment_CellContentClick);
            // 
            // FrmShipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1168, 647);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmShipment";
            this.Load += new System.EventHandler(this.FrmShipment_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.ComboBox cboWarehouse;
        private System.Windows.Forms.ComboBox cboDest;
        private System.Windows.Forms.TextBox txtSOID;
        private System.Windows.Forms.TextBox txtWOID;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btxExcel;
        private System.Windows.Forms.DataGridView dgvShipment;
    }
}
