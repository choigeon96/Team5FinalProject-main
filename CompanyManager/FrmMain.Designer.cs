using System.Drawing;

namespace CompanyManager
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSortName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.customTabControl1 = new CompanyManager.CustomControl.CustomTabControl();
            this.titleBar1 = new CompanyManager.TitleBar();
            this.grandianPanel1 = new CompanyManager.GrandianPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCommonM = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnEmployeeM = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grandianPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(178, 800);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenu.Location = new System.Drawing.Point(-1, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(198, 706);
            this.pnlMenu.TabIndex = 10;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(178, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1172, 149);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pnlMenu);
            this.panel1.Location = new System.Drawing.Point(0, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 706);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 55);
            this.label1.TabIndex = 8;
            this.label1.Text = "LOGO";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Open2_16x16.png");
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblSortName);
            this.panel2.Location = new System.Drawing.Point(179, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1173, 24);
            this.panel2.TabIndex = 16;
            // 
            // lblSortName
            // 
            this.lblSortName.AutoSize = true;
            this.lblSortName.Location = new System.Drawing.Point(6, 4);
            this.lblSortName.Name = "lblSortName";
            this.lblSortName.Size = new System.Drawing.Size(0, 14);
            this.lblSortName.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(227)))));
            this.label3.Location = new System.Drawing.Point(180, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1169, 3);
            this.label3.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.customTabControl1);
            this.panel3.Location = new System.Drawing.Point(180, 120);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1172, 29);
            this.panel3.TabIndex = 20;
            // 
            // customTabControl1
            // 
            this.customTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customTabControl1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.customTabControl1.Location = new System.Drawing.Point(-1, 4);
            this.customTabControl1.Name = "customTabControl1";
            this.customTabControl1.Size = new System.Drawing.Size(1171, 25);
            this.customTabControl1.TabIndex = 0;
            // 
            // titleBar1
            // 
            this.titleBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(160)))), ((int)(((byte)(185)))));
            this.titleBar1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleBar1.HeaderText = "";
            this.titleBar1.Location = new System.Drawing.Point(0, 0);
            this.titleBar1.Name = "titleBar1";
            this.titleBar1.Size = new System.Drawing.Size(1350, 33);
            this.titleBar1.TabIndex = 13;
            // 
            // grandianPanel1
            // 
            this.grandianPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grandianPanel1.ColorBotton = System.Drawing.Color.White;
            this.grandianPanel1.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(160)))), ((int)(((byte)(185)))));
            this.grandianPanel1.Controls.Add(this.pictureBox1);
            this.grandianPanel1.Controls.Add(this.btnCommonM);
            this.grandianPanel1.Controls.Add(this.btnLogout);
            this.grandianPanel1.Controls.Add(this.btnEmployeeM);
            this.grandianPanel1.Location = new System.Drawing.Point(0, 30);
            this.grandianPanel1.Name = "grandianPanel1";
            this.grandianPanel1.Size = new System.Drawing.Size(1350, 66);
            this.grandianPanel1.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CompanyManager.Properties.Resources.LOGO_T;
            this.pictureBox1.Location = new System.Drawing.Point(16, -7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // btnCommonM
            // 
            this.btnCommonM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommonM.BackColor = System.Drawing.Color.Transparent;
            this.btnCommonM.FlatAppearance.BorderSize = 0;
            this.btnCommonM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCommonM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommonM.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCommonM.Image = ((System.Drawing.Image)(resources.GetObject("btnCommonM.Image")));
            this.btnCommonM.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCommonM.Location = new System.Drawing.Point(1185, 7);
            this.btnCommonM.Name = "btnCommonM";
            this.btnCommonM.Size = new System.Drawing.Size(64, 55);
            this.btnCommonM.TabIndex = 20;
            this.btnCommonM.Text = "공통관리";
            this.btnCommonM.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCommonM.UseVisualStyleBackColor = false;
            this.btnCommonM.Visible = false;
            this.btnCommonM.Click += new System.EventHandler(this.btnCommonM_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLogout.Location = new System.Drawing.Point(1263, 7);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(64, 57);
            this.btnLogout.TabIndex = 19;
            this.btnLogout.Text = "로그아웃";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnEmployeeM
            // 
            this.btnEmployeeM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmployeeM.BackColor = System.Drawing.Color.Transparent;
            this.btnEmployeeM.FlatAppearance.BorderSize = 0;
            this.btnEmployeeM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnEmployeeM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeM.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEmployeeM.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployeeM.Image")));
            this.btnEmployeeM.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEmployeeM.Location = new System.Drawing.Point(1107, 7);
            this.btnEmployeeM.Name = "btnEmployeeM";
            this.btnEmployeeM.Size = new System.Drawing.Size(64, 55);
            this.btnEmployeeM.TabIndex = 18;
            this.btnEmployeeM.Text = "직원관리";
            this.btnEmployeeM.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmployeeM.UseVisualStyleBackColor = false;
            this.btnEmployeeM.Visible = false;
            this.btnEmployeeM.Click += new System.EventHandler(this.btnEmployeeM_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("돋움체", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.Image = global::CompanyManager.Properties.Resources.Add_32x32;
            this.button4.Location = new System.Drawing.Point(360, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(56, 78);
            this.button4.TabIndex = 11;
            this.button4.Text = "추가";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("돋움체", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Image = global::CompanyManager.Properties.Resources.Add_32x32;
            this.button3.Location = new System.Drawing.Point(304, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 78);
            this.button3.TabIndex = 10;
            this.button3.Text = "추가";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("돋움체", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Image = global::CompanyManager.Properties.Resources.Add_32x32;
            this.button2.Location = new System.Drawing.Point(248, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 78);
            this.button2.TabIndex = 9;
            this.button2.Text = "추가";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("돋움체", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Image = global::CompanyManager.Properties.Resources.Add_32x32;
            this.button1.Location = new System.Drawing.Point(192, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 78);
            this.button1.TabIndex = 4;
            this.button1.Text = "추가";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 800);
            this.Controls.Add(this.titleBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.grandianPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MdiChildActivate += new System.EventHandler(this.FrmMain_MdiChildActivate);
            this.SizeChanged += new System.EventHandler(this.FrmMain_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.grandianPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Button button1;
       
        private System.Windows.Forms.Label label1;
      
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel panel1;
        private TitleBar titleBar1;
        private GrandianPanel grandianPanel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSortName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private CustomControl.CustomTabControl customTabControl1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnEmployeeM;
        private System.Windows.Forms.Button btnCommonM;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

