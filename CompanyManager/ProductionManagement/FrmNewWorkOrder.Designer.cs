
namespace CompanyManager
{
    partial class FrmNewWorkOrder
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
            this.dgvWorkOrder = new System.Windows.Forms.DataGridView();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.cboMachine = new System.Windows.Forms.ComboBox();
            this.cboID = new System.Windows.Forms.ComboBox();
            this.cboDate = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnRegWO = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrder)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvWorkOrder
            // 
            this.dgvWorkOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWorkOrder.BackgroundColor = System.Drawing.Color.White;
            this.dgvWorkOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkOrder.Location = new System.Drawing.Point(8, 158);
            this.dgvWorkOrder.Name = "dgvWorkOrder";
            this.dgvWorkOrder.RowHeadersWidth = 50;
            this.dgvWorkOrder.RowTemplate.Height = 23;
            this.dgvWorkOrder.Size = new System.Drawing.Size(1152, 480);
            this.dgvWorkOrder.TabIndex = 25;
            this.dgvWorkOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWorkOrder_CellContentClick);
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(113, 51);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(185, 22);
            this.cboState.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.dtpTo);
            this.panel2.Controls.Add(this.dtpFrom);
            this.panel2.Controls.Add(this.cboMachine);
            this.panel2.Controls.Add(this.cboID);
            this.panel2.Controls.Add(this.cboDate);
            this.panel2.Controls.Add(this.cboState);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.txtID);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel2.Location = new System.Drawing.Point(8, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1152, 98);
            this.panel2.TabIndex = 26;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(198, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(15, 14);
            this.label20.TabIndex = 49;
            this.label20.Text = "~";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(213, 20);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(85, 21);
            this.dtpTo.TabIndex = 48;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(113, 20);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(85, 21);
            this.dtpFrom.TabIndex = 47;
            // 
            // cboMachine
            // 
            this.cboMachine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMachine.FormattingEnabled = true;
            this.cboMachine.Location = new System.Drawing.Point(732, 23);
            this.cboMachine.Name = "cboMachine";
            this.cboMachine.Size = new System.Drawing.Size(185, 22);
            this.cboMachine.TabIndex = 14;
            // 
            // cboID
            // 
            this.cboID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboID.FormattingEnabled = true;
            this.cboID.Items.AddRange(new object[] {
            "작업/생산 ID",
            "품목 ID"});
            this.cboID.Location = new System.Drawing.Point(379, 22);
            this.cboID.Name = "cboID";
            this.cboID.Size = new System.Drawing.Size(66, 22);
            this.cboID.TabIndex = 13;
            // 
            // cboDate
            // 
            this.cboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDate.FormattingEnabled = true;
            this.cboDate.Items.AddRange(new object[] {
            "계획시작",
            "납기일자",
            "등록시간"});
            this.cboDate.Location = new System.Drawing.Point(32, 20);
            this.cboDate.Name = "cboDate";
            this.cboDate.Size = new System.Drawing.Size(74, 22);
            this.cboDate.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(685, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 14);
            this.label11.TabIndex = 3;
            this.label11.Text = "* 설비";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 14);
            this.label12.TabIndex = 3;
            this.label12.Text = "* 상태";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(366, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 14);
            this.label13.TabIndex = 3;
            this.label13.Text = "* ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 14);
            this.label14.TabIndex = 3;
            this.label14.Text = "* ";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label15.Location = new System.Drawing.Point(685, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 14);
            this.label15.TabIndex = 1;
            this.label15.Text = "label2";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label16.Location = new System.Drawing.Point(19, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 14);
            this.label16.TabIndex = 1;
            this.label16.Text = "label16";
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtID.Location = new System.Drawing.Point(451, 22);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(185, 21);
            this.txtID.TabIndex = 2;
            this.txtID.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label17.Location = new System.Drawing.Point(366, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 14);
            this.label17.TabIndex = 1;
            this.label17.Text = "label2";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.label18.Location = new System.Drawing.Point(20, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 14);
            this.label18.TabIndex = 1;
            this.label18.Text = "label18";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(102)))), ((int)(((byte)(198)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(1027, 61);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(116, 30);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Image = global::CompanyManager.Properties.Resources.AlignJustify_16x16;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(12, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 14);
            this.label10.TabIndex = 22;
            this.label10.Text = "      작업지시생성";
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Image = global::CompanyManager.Properties.Resources.New_16x16;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(1106, 129);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(54, 23);
            this.btnExcel.TabIndex = 24;
            this.btnExcel.Text = "    엑셀";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRegWO
            // 
            this.btnRegWO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegWO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.btnRegWO.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnRegWO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegWO.Image = global::CompanyManager.Properties.Resources.Edit_16x16;
            this.btnRegWO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegWO.Location = new System.Drawing.Point(1011, 129);
            this.btnRegWO.Name = "btnRegWO";
            this.btnRegWO.Size = new System.Drawing.Size(89, 23);
            this.btnRegWO.TabIndex = 32;
            this.btnRegWO.Text = "수작업등록";
            this.btnRegWO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegWO.UseVisualStyleBackColor = false;
            this.btnRegWO.Click += new System.EventHandler(this.btnRegWO_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = global::CompanyManager.Properties.Resources.trash;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(883, 129);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 23);
            this.btnDelete.TabIndex = 34;
            this.btnDelete.Text = "작업지시계획삭제";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.btnCommit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommit.Image = global::CompanyManager.Properties.Resources.Previous_16x16;
            this.btnCommit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCommit.Location = new System.Drawing.Point(776, 129);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(101, 23);
            this.btnCommit.TabIndex = 35;
            this.btnCommit.Text = "작업지시확정";
            this.btnCommit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCommit.UseVisualStyleBackColor = false;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // FrmNewWorkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1168, 647);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRegWO);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.dgvWorkOrder);
            this.Controls.Add(this.panel2);
            this.Name = "FrmNewWorkOrder";
            this.Load += new System.EventHandler(this.FrmNewWorkOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrder)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridView dgvWorkOrder;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboDate;
        private System.Windows.Forms.ComboBox cboID;
        private System.Windows.Forms.Button btnRegWO;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.ComboBox cboMachine;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
    }
}
