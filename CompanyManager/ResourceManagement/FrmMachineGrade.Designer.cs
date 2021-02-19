
namespace CompanyManager
{
    partial class FrmMachineGrade
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnMGDelete = new System.Windows.Forms.Button();
            this.dgvMachineGrade = new System.Windows.Forms.DataGridView();
            this.btnMGRegister = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlMGrade = new System.Windows.Forms.Panel();
            this.cboParent = new System.Windows.Forms.ComboBox();
            this.cboUse = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCencel = new System.Windows.Forms.Button();
            this.txtUpEmp = new System.Windows.Forms.TextBox();
            this.btnMGCRU = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMGCode = new System.Windows.Forms.TextBox();
            this.txtMGName = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMGrade = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMDelete = new System.Windows.Forms.Button();
            this.dgvMachine = new System.Windows.Forms.DataGridView();
            this.btnMRegister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMgradeN = new System.Windows.Forms.Label();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.btnExcelExport1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMachineGrade)).BeginInit();
            this.pnlMGrade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMachine)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(8, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnExcelExport);
            this.splitContainer1.Panel1.Controls.Add(this.btnMGDelete);
            this.splitContainer1.Panel1.Controls.Add(this.dgvMachineGrade);
            this.splitContainer1.Panel1.Controls.Add(this.btnMGRegister);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.pnlMGrade);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnExcelExport1);
            this.splitContainer1.Panel2.Controls.Add(this.btnMDelete);
            this.splitContainer1.Panel2.Controls.Add(this.dgvMachine);
            this.splitContainer1.Panel2.Controls.Add(this.btnMRegister);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(1148, 623);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 25;
            // 
            // btnMGDelete
            // 
            this.btnMGDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMGDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.btnMGDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnMGDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMGDelete.Image = global::CompanyManager.Properties.Resources.Cancel_16x16;
            this.btnMGDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMGDelete.Location = new System.Drawing.Point(509, 3);
            this.btnMGDelete.Name = "btnMGDelete";
            this.btnMGDelete.Size = new System.Drawing.Size(57, 23);
            this.btnMGDelete.TabIndex = 2;
            this.btnMGDelete.Text = "    삭제";
            this.btnMGDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMGDelete.UseVisualStyleBackColor = false;
            this.btnMGDelete.Click += new System.EventHandler(this.btnMGDelete_Click);
            // 
            // dgvMachineGrade
            // 
            this.dgvMachineGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMachineGrade.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMachineGrade.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMachineGrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMachineGrade.Location = new System.Drawing.Point(3, 29);
            this.dgvMachineGrade.Name = "dgvMachineGrade";
            this.dgvMachineGrade.RowTemplate.Height = 23;
            this.dgvMachineGrade.Size = new System.Drawing.Size(623, 221);
            this.dgvMachineGrade.TabIndex = 19;
            this.dgvMachineGrade.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMachineGrade_CellClick);
            this.dgvMachineGrade.DoubleClick += new System.EventHandler(this.dgvMachineGrade_DoubleClick);
            // 
            // btnMGRegister
            // 
            this.btnMGRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMGRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.btnMGRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnMGRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMGRegister.Image = global::CompanyManager.Properties.Resources.pencil_16;
            this.btnMGRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMGRegister.Location = new System.Drawing.Point(447, 3);
            this.btnMGRegister.Name = "btnMGRegister";
            this.btnMGRegister.Size = new System.Drawing.Size(56, 23);
            this.btnMGRegister.TabIndex = 0;
            this.btnMGRegister.Text = "    등록";
            this.btnMGRegister.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMGRegister.UseVisualStyleBackColor = false;
            this.btnMGRegister.Click += new System.EventHandler(this.btnMGRegister_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Image = global::CompanyManager.Properties.Resources.AlignJustify_16x16;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(3, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 14);
            this.label10.TabIndex = 13;
            this.label10.Text = "      설비군";
            // 
            // pnlMGrade
            // 
            this.pnlMGrade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMGrade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(227)))));
            this.pnlMGrade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMGrade.Controls.Add(this.cboParent);
            this.pnlMGrade.Controls.Add(this.cboUse);
            this.pnlMGrade.Controls.Add(this.label5);
            this.pnlMGrade.Controls.Add(this.btnCencel);
            this.pnlMGrade.Controls.Add(this.txtUpEmp);
            this.pnlMGrade.Controls.Add(this.btnMGCRU);
            this.pnlMGrade.Controls.Add(this.label2);
            this.pnlMGrade.Controls.Add(this.label8);
            this.pnlMGrade.Controls.Add(this.txtMGCode);
            this.pnlMGrade.Controls.Add(this.txtMGName);
            this.pnlMGrade.Controls.Add(this.txtComment);
            this.pnlMGrade.Controls.Add(this.label6);
            this.pnlMGrade.Controls.Add(this.label3);
            this.pnlMGrade.Controls.Add(this.lblMGrade);
            this.pnlMGrade.Controls.Add(this.label4);
            this.pnlMGrade.Location = new System.Drawing.Point(632, 3);
            this.pnlMGrade.Name = "pnlMGrade";
            this.pnlMGrade.Size = new System.Drawing.Size(516, 247);
            this.pnlMGrade.TabIndex = 40;
            this.pnlMGrade.Visible = false;
            // 
            // cboParent
            // 
            this.cboParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParent.FormattingEnabled = true;
            this.cboParent.Location = new System.Drawing.Point(324, 36);
            this.cboParent.Name = "cboParent";
            this.cboParent.Size = new System.Drawing.Size(176, 22);
            this.cboParent.TabIndex = 3;
            // 
            // cboUse
            // 
            this.cboUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUse.FormattingEnabled = true;
            this.cboUse.Location = new System.Drawing.Point(94, 36);
            this.cboUse.Name = "cboUse";
            this.cboUse.Size = new System.Drawing.Size(140, 22);
            this.cboUse.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(13, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 14);
            this.label5.TabIndex = 31;
            this.label5.Text = "* 설비군 코드";
            // 
            // btnCencel
            // 
            this.btnCencel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCencel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(142)))), ((int)(((byte)(150)))));
            this.btnCencel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCencel.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCencel.ForeColor = System.Drawing.Color.White;
            this.btnCencel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCencel.Location = new System.Drawing.Point(415, 207);
            this.btnCencel.Name = "btnCencel";
            this.btnCencel.Size = new System.Drawing.Size(85, 30);
            this.btnCencel.TabIndex = 7;
            this.btnCencel.Text = "닫기";
            this.btnCencel.UseVisualStyleBackColor = false;
            this.btnCencel.Click += new System.EventHandler(this.btnCencel_Click);
            // 
            // txtUpEmp
            // 
            this.txtUpEmp.Location = new System.Drawing.Point(94, 62);
            this.txtUpEmp.Name = "txtUpEmp";
            this.txtUpEmp.ReadOnly = true;
            this.txtUpEmp.Size = new System.Drawing.Size(140, 21);
            this.txtUpEmp.TabIndex = 4;
            // 
            // btnMGCRU
            // 
            this.btnMGCRU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMGCRU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(147)))), ((int)(((byte)(211)))));
            this.btnMGCRU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMGCRU.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMGCRU.ForeColor = System.Drawing.Color.White;
            this.btnMGCRU.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMGCRU.Location = new System.Drawing.Point(324, 207);
            this.btnMGCRU.Name = "btnMGCRU";
            this.btnMGCRU.Size = new System.Drawing.Size(85, 30);
            this.btnMGCRU.TabIndex = 6;
            this.btnMGCRU.Text = "저장";
            this.btnMGCRU.UseVisualStyleBackColor = false;
            this.btnMGCRU.Click += new System.EventHandler(this.btnMGCRU_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(247, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 14);
            this.label2.TabIndex = 30;
            this.label2.Text = "* 설비군 명";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(13, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 14);
            this.label8.TabIndex = 26;
            this.label8.Text = "* 수정자";
            // 
            // txtMGCode
            // 
            this.txtMGCode.Location = new System.Drawing.Point(94, 11);
            this.txtMGCode.Name = "txtMGCode";
            this.txtMGCode.Size = new System.Drawing.Size(140, 21);
            this.txtMGCode.TabIndex = 1;
            // 
            // txtMGName
            // 
            this.txtMGName.Location = new System.Drawing.Point(324, 11);
            this.txtMGName.Name = "txtMGName";
            this.txtMGName.Size = new System.Drawing.Size(176, 21);
            this.txtMGName.TabIndex = 2;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(16, 110);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(484, 91);
            this.txtComment.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(247, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 14);
            this.label6.TabIndex = 29;
            this.label6.Text = "* 상위시설";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(13, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 14);
            this.label3.TabIndex = 29;
            this.label3.Text = "* 사용유무";
            // 
            // lblMGrade
            // 
            this.lblMGrade.AutoSize = true;
            this.lblMGrade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(227)))));
            this.lblMGrade.Location = new System.Drawing.Point(506, 217);
            this.lblMGrade.Name = "lblMGrade";
            this.lblMGrade.Size = new System.Drawing.Size(0, 14);
            this.lblMGrade.TabIndex = 27;
            this.lblMGrade.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(13, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 14);
            this.label4.TabIndex = 27;
            this.label4.Text = "* 시설설명";
            // 
            // btnMDelete
            // 
            this.btnMDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.btnMDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnMDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMDelete.Image = global::CompanyManager.Properties.Resources.Cancel_16x16;
            this.btnMDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMDelete.Location = new System.Drawing.Point(1027, 3);
            this.btnMDelete.Name = "btnMDelete";
            this.btnMDelete.Size = new System.Drawing.Size(57, 23);
            this.btnMDelete.TabIndex = 7;
            this.btnMDelete.Text = "    삭제";
            this.btnMDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMDelete.UseVisualStyleBackColor = false;
            this.btnMDelete.Click += new System.EventHandler(this.btnMDelete_Click);
            // 
            // dgvMachine
            // 
            this.dgvMachine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMachine.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMachine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMachine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMachine.Location = new System.Drawing.Point(3, 29);
            this.dgvMachine.Name = "dgvMachine";
            this.dgvMachine.RowTemplate.Height = 23;
            this.dgvMachine.Size = new System.Drawing.Size(1141, 334);
            this.dgvMachine.TabIndex = 19;
            this.dgvMachine.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMachine_CellClick);
            // 
            // btnMRegister
            // 
            this.btnMRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.btnMRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnMRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMRegister.Image = global::CompanyManager.Properties.Resources.pencil_16;
            this.btnMRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMRegister.Location = new System.Drawing.Point(965, 3);
            this.btnMRegister.Name = "btnMRegister";
            this.btnMRegister.Size = new System.Drawing.Size(56, 23);
            this.btnMRegister.TabIndex = 5;
            this.btnMRegister.Text = "    등록";
            this.btnMRegister.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMRegister.UseVisualStyleBackColor = false;
            this.btnMRegister.Click += new System.EventHandler(this.btnMRegister_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Image = global::CompanyManager.Properties.Resources.AlignJustify_16x16;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "      설비";
            // 
            // lblMgradeN
            // 
            this.lblMgradeN.AutoSize = true;
            this.lblMgradeN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(227)))));
            this.lblMgradeN.Location = new System.Drawing.Point(1162, 624);
            this.lblMgradeN.Name = "lblMgradeN";
            this.lblMgradeN.Size = new System.Drawing.Size(0, 14);
            this.lblMgradeN.TabIndex = 27;
            this.lblMgradeN.Visible = false;
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcelExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.btnExcelExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnExcelExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcelExport.Image = global::CompanyManager.Properties.Resources.New_16x16;
            this.btnExcelExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcelExport.Location = new System.Drawing.Point(572, 3);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(54, 23);
            this.btnExcelExport.TabIndex = 32;
            this.btnExcelExport.Text = "    엑셀";
            this.btnExcelExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcelExport.UseVisualStyleBackColor = false;
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // btnExcelExport1
            // 
            this.btnExcelExport1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcelExport1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(209)))), ((int)(((byte)(219)))));
            this.btnExcelExport1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(162)))), ((int)(((byte)(175)))));
            this.btnExcelExport1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcelExport1.Image = global::CompanyManager.Properties.Resources.New_16x16;
            this.btnExcelExport1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcelExport1.Location = new System.Drawing.Point(1090, 3);
            this.btnExcelExport1.Name = "btnExcelExport1";
            this.btnExcelExport1.Size = new System.Drawing.Size(54, 23);
            this.btnExcelExport1.TabIndex = 32;
            this.btnExcelExport1.Text = "    엑셀";
            this.btnExcelExport1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcelExport1.UseVisualStyleBackColor = false;
            this.btnExcelExport1.Click += new System.EventHandler(this.btnExcelExport1_Click);
            // 
            // FrmMachineGrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1168, 647);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.lblMgradeN);
            this.Name = "FrmMachineGrade";
            this.Load += new System.EventHandler(this.FrmMachineGrade_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMachineGrade)).EndInit();
            this.pnlMGrade.ResumeLayout(false);
            this.pnlMGrade.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMachine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvMachineGrade;
        private System.Windows.Forms.Button btnMGRegister;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvMachine;
        private System.Windows.Forms.Button btnMRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboUse;
        private System.Windows.Forms.TextBox txtUpEmp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMGName;
        private System.Windows.Forms.TextBox txtMGCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMGCRU;
        private System.Windows.Forms.Button btnCencel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlMGrade;
        private System.Windows.Forms.Label lblMGrade;
        private System.Windows.Forms.Button btnMGDelete;
        private System.Windows.Forms.Button btnMDelete;
        private System.Windows.Forms.Label lblMgradeN;
        private System.Windows.Forms.ComboBox cboParent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnExcelExport;
        private System.Windows.Forms.Button btnExcelExport1;
    }
}
