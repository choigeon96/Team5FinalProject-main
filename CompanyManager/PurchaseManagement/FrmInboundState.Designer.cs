
namespace CompanyManager
{
    partial class FrmInboundState
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
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.txtPurchasesID = new System.Windows.Forms.TextBox();
            this.txtInboundID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboWareHouse = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvInbound = new System.Windows.Forms.DataGridView();
            this.btnExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInbound)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.dgvInbound);
            this.splitContainer1.Panel2.Controls.Add(this.btnExcel);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1168, 647);
            this.splitContainer1.SplitterDistance = 106;
            this.splitContainer1.TabIndex = 24;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.cboCompany);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Controls.Add(this.dtpTo);
            this.pnlSearch.Controls.Add(this.dtpFrom);
            this.pnlSearch.Controls.Add(this.txtPurchasesID);
            this.pnlSearch.Controls.Add(this.txtInboundID);
            this.pnlSearch.Controls.Add(this.label5);
            this.pnlSearch.Controls.Add(this.label19);
            this.pnlSearch.Controls.Add(this.label7);
            this.pnlSearch.Controls.Add(this.label8);
            this.pnlSearch.Controls.Add(this.cboWareHouse);
            this.pnlSearch.Controls.Add(this.label6);
            this.pnlSearch.Controls.Add(this.label20);
            this.pnlSearch.Controls.Add(this.label21);
            this.pnlSearch.Controls.Add(this.txtItem);
            this.pnlSearch.Controls.Add(this.label22);
            this.pnlSearch.Controls.Add(this.label23);
            this.pnlSearch.Controls.Add(this.label24);
            this.pnlSearch.Controls.Add(this.label26);
            this.pnlSearch.Controls.Add(this.label28);
            this.pnlSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pnlSearch.Location = new System.Drawing.Point(10, 12);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1146, 84);
            this.pnlSearch.TabIndex = 22;
            // 
            // cboCompany
            // 
            this.cboCompany.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(427, 12);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(210, 22);
            this.cboCompany.TabIndex = 53;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(102)))), ((int)(((byte)(198)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(1022, 41);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(116, 30);
            this.btnSearch.TabIndex = 52;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 14);
            this.label1.TabIndex = 51;
            this.label1.Text = "~";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(201, 13);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(95, 21);
            this.dtpTo.TabIndex = 50;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(86, 13);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(95, 21);
            this.dtpFrom.TabIndex = 49;
            // 
            // txtPurchasesID
            // 
            this.txtPurchasesID.Location = new System.Drawing.Point(86, 45);
            this.txtPurchasesID.Name = "txtPurchasesID";
            this.txtPurchasesID.Size = new System.Drawing.Size(210, 21);
            this.txtPurchasesID.TabIndex = 48;
            // 
            // txtInboundID
            // 
            this.txtInboundID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInboundID.Location = new System.Drawing.Point(767, 44);
            this.txtInboundID.Name = "txtInboundID";
            this.txtInboundID.Size = new System.Drawing.Size(210, 21);
            this.txtInboundID.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "* 발주번호";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label19.Location = new System.Drawing.Point(19, 45);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 14);
            this.label19.TabIndex = 21;
            this.label19.Text = "label2";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(700, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 14);
            this.label7.TabIndex = 19;
            this.label7.Text = "* 입고번호";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label8.Location = new System.Drawing.Point(701, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 14);
            this.label8.TabIndex = 18;
            this.label8.Text = "label2";
            // 
            // cboWareHouse
            // 
            this.cboWareHouse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboWareHouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWareHouse.FormattingEnabled = true;
            this.cboWareHouse.Location = new System.Drawing.Point(427, 44);
            this.cboWareHouse.Name = "cboWareHouse";
            this.cboWareHouse.Size = new System.Drawing.Size(210, 22);
            this.cboWareHouse.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 14);
            this.label6.TabIndex = 16;
            this.label6.Text = "* 입고창고";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label20.Location = new System.Drawing.Point(360, 44);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 14);
            this.label20.TabIndex = 15;
            this.label20.Text = "label2";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(701, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(39, 14);
            this.label21.TabIndex = 14;
            this.label21.Text = "* 품목";
            // 
            // txtItem
            // 
            this.txtItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItem.Location = new System.Drawing.Point(767, 12);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(210, 21);
            this.txtItem.TabIndex = 13;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label22.Location = new System.Drawing.Point(702, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 14);
            this.label22.TabIndex = 12;
            this.label22.Text = "label22";
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(360, 15);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(39, 14);
            this.label23.TabIndex = 11;
            this.label23.Text = "* 업체";
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label24.Location = new System.Drawing.Point(362, 15);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 14);
            this.label24.TabIndex = 9;
            this.label24.Text = "label24";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(19, 15);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(50, 14);
            this.label26.TabIndex = 3;
            this.label26.Text = "* 입고일";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label28.Location = new System.Drawing.Point(20, 15);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 14);
            this.label28.TabIndex = 1;
            this.label28.Text = "label28";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::CompanyManager.Properties.Resources.Undo_16x16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(1018, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "    입고취소";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Image = global::CompanyManager.Properties.Resources.AlignJustify_16x16;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(12, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 14);
            this.label10.TabIndex = 13;
            this.label10.Text = "      자재입고현황";
            // 
            // dgvInbound
            // 
            this.dgvInbound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInbound.BackgroundColor = System.Drawing.Color.White;
            this.dgvInbound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInbound.Location = new System.Drawing.Point(10, 32);
            this.dgvInbound.Name = "dgvInbound";
            this.dgvInbound.RowTemplate.Height = 23;
            this.dgvInbound.Size = new System.Drawing.Size(1146, 493);
            this.dgvInbound.TabIndex = 19;
            this.dgvInbound.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInbound_CellContentClick);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Image = global::CompanyManager.Properties.Resources.New_16x16;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(1102, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(54, 23);
            this.btnExcel.TabIndex = 17;
            this.btnExcel.Text = "    엑셀";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // FrmInboundState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1168, 647);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmInboundState";
            this.Load += new System.EventHandler(this.FrmInboundState_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInbound)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboWareHouse;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvInbound;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TextBox txtPurchasesID;
        private System.Windows.Forms.TextBox txtInboundID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboCompany;
    }
}
