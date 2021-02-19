
namespace CompanyManager
{
    partial class FrmPurchase
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
            this.cboPlanID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTO = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.cboWarehouse = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cboItemCategory = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtItemUnit = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvPurchases = new System.Windows.Forms.DataGridView();
            this.button13 = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.dgvPurchases);
            this.splitContainer1.Panel2.Controls.Add(this.button13);
            this.splitContainer1.Panel2.Controls.Add(this.btnExcel);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1168, 647);
            this.splitContainer1.SplitterDistance = 104;
            this.splitContainer1.TabIndex = 24;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.cboPlanID);
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Controls.Add(this.dtpTO);
            this.pnlSearch.Controls.Add(this.dtpFrom);
            this.pnlSearch.Controls.Add(this.cboWarehouse);
            this.pnlSearch.Controls.Add(this.label5);
            this.pnlSearch.Controls.Add(this.label19);
            this.pnlSearch.Controls.Add(this.cboItemCategory);
            this.pnlSearch.Controls.Add(this.label6);
            this.pnlSearch.Controls.Add(this.label20);
            this.pnlSearch.Controls.Add(this.label21);
            this.pnlSearch.Controls.Add(this.txtItemUnit);
            this.pnlSearch.Controls.Add(this.label22);
            this.pnlSearch.Controls.Add(this.label23);
            this.pnlSearch.Controls.Add(this.label24);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.cboCompany);
            this.pnlSearch.Controls.Add(this.label25);
            this.pnlSearch.Controls.Add(this.label26);
            this.pnlSearch.Controls.Add(this.label27);
            this.pnlSearch.Controls.Add(this.label28);
            this.pnlSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pnlSearch.Location = new System.Drawing.Point(10, 12);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1146, 82);
            this.pnlSearch.TabIndex = 22;
            // 
            // cboPlanID
            // 
            this.cboPlanID.Location = new System.Drawing.Point(85, 12);
            this.cboPlanID.Name = "cboPlanID";
            this.cboPlanID.Size = new System.Drawing.Size(210, 21);
            this.cboPlanID.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(524, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 14);
            this.label1.TabIndex = 46;
            this.label1.Text = "~";
            // 
            // dtpTO
            // 
            this.dtpTO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpTO.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTO.Location = new System.Drawing.Point(542, 12);
            this.dtpTO.Name = "dtpTO";
            this.dtpTO.Size = new System.Drawing.Size(95, 21);
            this.dtpTO.TabIndex = 45;
            this.dtpTO.Value = new System.DateTime(2020, 1, 20, 0, 0, 0, 0);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(427, 12);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(95, 21);
            this.dtpFrom.TabIndex = 44;
            this.dtpFrom.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarehouse.FormattingEnabled = true;
            this.cboWarehouse.Location = new System.Drawing.Point(748, 44);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Size = new System.Drawing.Size(210, 22);
            this.cboWarehouse.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(701, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "* 창고";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label19.Location = new System.Drawing.Point(701, 44);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 14);
            this.label19.TabIndex = 21;
            this.label19.Text = "label2";
            // 
            // cboItemCategory
            // 
            this.cboItemCategory.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboItemCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemCategory.FormattingEnabled = true;
            this.cboItemCategory.Location = new System.Drawing.Point(427, 44);
            this.cboItemCategory.Name = "cboItemCategory";
            this.cboItemCategory.Size = new System.Drawing.Size(210, 22);
            this.cboItemCategory.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 14);
            this.label6.TabIndex = 16;
            this.label6.Text = "* 품목형태";
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
            // txtItemUnit
            // 
            this.txtItemUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemUnit.Location = new System.Drawing.Point(748, 13);
            this.txtItemUnit.Name = "txtItemUnit";
            this.txtItemUnit.Size = new System.Drawing.Size(210, 21);
            this.txtItemUnit.TabIndex = 13;
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
            this.label23.Size = new System.Drawing.Size(44, 14);
            this.label23.TabIndex = 11;
            this.label23.Text = "* Date";
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
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(102)))), ((int)(((byte)(198)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(1015, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(116, 30);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboCompany
            // 
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(86, 44);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(210, 22);
            this.cboCompany.TabIndex = 4;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(19, 47);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(61, 14);
            this.label25.TabIndex = 3;
            this.label25.Text = "* 업체코드";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(19, 15);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(57, 14);
            this.label26.TabIndex = 3;
            this.label26.Text = "* Prod ID";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label27.Location = new System.Drawing.Point(19, 44);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(41, 14);
            this.label27.TabIndex = 1;
            this.label27.Text = "label2";
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Image = global::CompanyManager.Properties.Resources.AlignJustify_16x16;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(12, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 14);
            this.label10.TabIndex = 13;
            this.label10.Text = "      정규발주";
            // 
            // dgvPurchases
            // 
            this.dgvPurchases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPurchases.BackgroundColor = System.Drawing.Color.White;
            this.dgvPurchases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPurchases.Location = new System.Drawing.Point(10, 38);
            this.dgvPurchases.Name = "dgvPurchases";
            this.dgvPurchases.RowTemplate.Height = 23;
            this.dgvPurchases.Size = new System.Drawing.Size(1146, 489);
            this.dgvPurchases.TabIndex = 19;
            this.dgvPurchases.DataSourceChanged += new System.EventHandler(this.dgvPurchases_DataSourceChanged);
            this.dgvPurchases.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchases_CellContentClick);
            this.dgvPurchases.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvPurchases_CellPainting);
            this.dgvPurchases.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvPurchases_ColumnWidthChanged);
            this.dgvPurchases.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvPurchases_Scroll);
            this.dgvPurchases.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvPurchases_Paint);
            // 
            // button13
            // 
            this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.button13.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Image = global::CompanyManager.Properties.Resources.pencil_16;
            this.button13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button13.Location = new System.Drawing.Point(1040, 9);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(56, 23);
            this.button13.TabIndex = 18;
            this.button13.Text = "    등록";
            this.button13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Image = global::CompanyManager.Properties.Resources.New_16x16;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(1102, 9);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(54, 23);
            this.btnExcel.TabIndex = 17;
            this.btnExcel.Text = "    엑셀";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // FrmPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1168, 647);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmPurchase";
            this.Load += new System.EventHandler(this.FrmPurchase_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchases)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.ComboBox cboItemCategory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtItemUnit;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvPurchases;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTO;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.ComboBox cboWarehouse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox cboPlanID;
    }
}
