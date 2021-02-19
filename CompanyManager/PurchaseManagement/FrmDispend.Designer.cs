
namespace CompanyManager
{
    partial class FrmDispend
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.txtWoID = new System.Windows.Forms.TextBox();
            this.cboWarehouse = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboStock = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cboMachine = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvDispend = new System.Windows.Forms.DataGridView();
            this.btnOutbound = new System.Windows.Forms.Button();
            this.btxExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispend)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.dgvDispend);
            this.splitContainer1.Panel2.Controls.Add(this.btnOutbound);
            this.splitContainer1.Panel2.Controls.Add(this.btxExcel);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1168, 647);
            this.splitContainer1.SplitterDistance = 130;
            this.splitContainer1.TabIndex = 24;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Controls.Add(this.dtpTo);
            this.pnlSearch.Controls.Add(this.dtpFrom);
            this.pnlSearch.Controls.Add(this.txtWoID);
            this.pnlSearch.Controls.Add(this.cboWarehouse);
            this.pnlSearch.Controls.Add(this.label2);
            this.pnlSearch.Controls.Add(this.cboStock);
            this.pnlSearch.Controls.Add(this.label3);
            this.pnlSearch.Controls.Add(this.label4);
            this.pnlSearch.Controls.Add(this.cboState);
            this.pnlSearch.Controls.Add(this.label5);
            this.pnlSearch.Controls.Add(this.label19);
            this.pnlSearch.Controls.Add(this.cboMachine);
            this.pnlSearch.Controls.Add(this.label6);
            this.pnlSearch.Controls.Add(this.label20);
            this.pnlSearch.Controls.Add(this.label21);
            this.pnlSearch.Controls.Add(this.txtItem);
            this.pnlSearch.Controls.Add(this.label22);
            this.pnlSearch.Controls.Add(this.label23);
            this.pnlSearch.Controls.Add(this.label24);
            this.pnlSearch.Controls.Add(this.btnDown);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.label25);
            this.pnlSearch.Controls.Add(this.label26);
            this.pnlSearch.Controls.Add(this.label27);
            this.pnlSearch.Controls.Add(this.label28);
            this.pnlSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pnlSearch.Location = new System.Drawing.Point(10, 12);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1146, 114);
            this.pnlSearch.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 14);
            this.label1.TabIndex = 52;
            this.label1.Text = "~";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(208, 11);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(85, 21);
            this.dtpTo.TabIndex = 51;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(108, 11);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(85, 21);
            this.dtpFrom.TabIndex = 50;
            // 
            // txtWoID
            // 
            this.txtWoID.Location = new System.Drawing.Point(108, 44);
            this.txtWoID.Name = "txtWoID";
            this.txtWoID.Size = new System.Drawing.Size(185, 21);
            this.txtWoID.TabIndex = 48;
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarehouse.FormattingEnabled = true;
            this.cboWarehouse.Location = new System.Drawing.Point(427, 13);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Size = new System.Drawing.Size(185, 22);
            this.cboWarehouse.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label2.Location = new System.Drawing.Point(701, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "label2";
            // 
            // cboStock
            // 
            this.cboStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStock.FormattingEnabled = true;
            this.cboStock.Items.AddRange(new object[] {
            "전체",
            "가능",
            "불가능"});
            this.cboStock.Location = new System.Drawing.Point(769, 43);
            this.cboStock.Name = "cboStock";
            this.cboStock.Size = new System.Drawing.Size(185, 22);
            this.cboStock.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(702, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 14);
            this.label3.TabIndex = 25;
            this.label3.Text = "* 재고량";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label4.Location = new System.Drawing.Point(702, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 14);
            this.label4.TabIndex = 24;
            this.label4.Text = "label2";
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(108, 77);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(185, 22);
            this.cboState.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "* 상태";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label19.Location = new System.Drawing.Point(19, 77);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 14);
            this.label19.TabIndex = 21;
            this.label19.Text = "label2";
            // 
            // cboMachine
            // 
            this.cboMachine.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMachine.FormattingEnabled = true;
            this.cboMachine.Location = new System.Drawing.Point(427, 43);
            this.cboMachine.Name = "cboMachine";
            this.cboMachine.Size = new System.Drawing.Size(185, 22);
            this.cboMachine.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 14);
            this.label6.TabIndex = 16;
            this.label6.Text = "* 설비";
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
            this.txtItem.Size = new System.Drawing.Size(185, 21);
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
            this.label23.Size = new System.Drawing.Size(61, 14);
            this.label23.TabIndex = 11;
            this.label23.Text = "* 불출창고";
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
            this.btnDown.Location = new System.Drawing.Point(1111, 71);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(28, 28);
            this.btnDown.TabIndex = 8;
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
            this.btnSearch.Location = new System.Drawing.Point(997, 70);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(116, 30);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(19, 47);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(83, 14);
            this.label25.TabIndex = 3;
            this.label25.Text = "* 작업지시번호";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(19, 15);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(50, 14);
            this.label26.TabIndex = 3;
            this.label26.Text = "* 요청일";
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
            this.label10.Location = new System.Drawing.Point(12, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 14);
            this.label10.TabIndex = 13;
            this.label10.Text = "      원자재불출";
            // 
            // dgvDispend
            // 
            this.dgvDispend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDispend.BackgroundColor = System.Drawing.Color.White;
            this.dgvDispend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDispend.Location = new System.Drawing.Point(10, 32);
            this.dgvDispend.Name = "dgvDispend";
            this.dgvDispend.RowTemplate.Height = 23;
            this.dgvDispend.Size = new System.Drawing.Size(1146, 469);
            this.dgvDispend.TabIndex = 19;
            this.dgvDispend.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDispend_CellContentClick);
            // 
            // btnOutbound
            // 
            this.btnOutbound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutbound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.btnOutbound.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnOutbound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutbound.Image = global::CompanyManager.Properties.Resources.FullShoppingCart_16x16;
            this.btnOutbound.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOutbound.Location = new System.Drawing.Point(1040, 3);
            this.btnOutbound.Name = "btnOutbound";
            this.btnOutbound.Size = new System.Drawing.Size(56, 23);
            this.btnOutbound.TabIndex = 18;
            this.btnOutbound.Text = "    출고";
            this.btnOutbound.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOutbound.UseVisualStyleBackColor = false;
            this.btnOutbound.Click += new System.EventHandler(this.btnOutbound_Click);
            // 
            // btxExcel
            // 
            this.btxExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btxExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.btxExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btxExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btxExcel.Image = global::CompanyManager.Properties.Resources.New_16x16;
            this.btxExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btxExcel.Location = new System.Drawing.Point(1102, 3);
            this.btxExcel.Name = "btxExcel";
            this.btxExcel.Size = new System.Drawing.Size(54, 23);
            this.btxExcel.TabIndex = 17;
            this.btxExcel.Text = "    엑셀";
            this.btxExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btxExcel.UseVisualStyleBackColor = false;
            this.btxExcel.Click += new System.EventHandler(this.btxExcel_Click);
            // 
            // FrmDispend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1168, 647);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmDispend";
            this.Load += new System.EventHandler(this.FrmDispend_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispend)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboStock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboMachine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvDispend;
        private System.Windows.Forms.Button btnOutbound;
        private System.Windows.Forms.Button btxExcel;
        private System.Windows.Forms.TextBox txtWoID;
        private System.Windows.Forms.ComboBox cboWarehouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
    }
}
