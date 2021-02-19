
namespace CompanyManager
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.Loginbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtID = new CompanyManager.CustomControl.PlaceholderTextBox();
            this.txtPassword = new CompanyManager.CustomControl.PlaceholderTextBox();
            this.grandianPanel1 = new CompanyManager.GrandianPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grandianPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // popupTitleBar1
            // 
            this.popupTitleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.popupTitleBar1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.popupTitleBar1.HeaderText = "Login";
            this.popupTitleBar1.Location = new System.Drawing.Point(0, 0);
            this.popupTitleBar1.Size = new System.Drawing.Size(339, 33);
            this.popupTitleBar1.TabStop = false;
            // 
            // Loginbtn
            // 
            this.Loginbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(44)))));
            this.Loginbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Loginbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Loginbtn.ForeColor = System.Drawing.Color.White;
            this.Loginbtn.Location = new System.Drawing.Point(10, 88);
            this.Loginbtn.Name = "Loginbtn";
            this.Loginbtn.Size = new System.Drawing.Size(264, 41);
            this.Loginbtn.TabIndex = 2;
            this.Loginbtn.Text = "로그인";
            this.Loginbtn.UseVisualStyleBackColor = false;
            this.Loginbtn.Click += new System.EventHandler(this.Loginbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CompanyManager.Properties.Resources.LOGO_T;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(285, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(44)))));
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtID.Location = new System.Drawing.Point(10, 18);
            this.txtID.Name = "txtID";
            this.txtID.PlaceholderText = "아이디";
            this.txtID.PlaceholderTextColor = System.Drawing.Color.Silver;
            this.txtID.Size = new System.Drawing.Size(264, 26);
            this.txtID.TabIndex = 24;
            this.txtID.TextColor = System.Drawing.Color.White;
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(44)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPassword.Location = new System.Drawing.Point(10, 47);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "비밀번호";
            this.txtPassword.PlaceholderTextColor = System.Drawing.Color.Silver;
            this.txtPassword.Size = new System.Drawing.Size(264, 26);
            this.txtPassword.TabIndex = 25;
            this.txtPassword.TextColor = System.Drawing.Color.White;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // grandianPanel1
            // 
            this.grandianPanel1.ColorBotton = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(223)))), ((int)(((byte)(232)))));
            this.grandianPanel1.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(160)))), ((int)(((byte)(185)))));
            this.grandianPanel1.Controls.Add(this.panel1);
            this.grandianPanel1.Controls.Add(this.pictureBox1);
            this.grandianPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grandianPanel1.Location = new System.Drawing.Point(0, 0);
            this.grandianPanel1.Name = "grandianPanel1";
            this.grandianPanel1.Size = new System.Drawing.Size(339, 290);
            this.grandianPanel1.TabIndex = 24;
            this.grandianPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.grandianPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.Loginbtn);
            this.panel1.Location = new System.Drawing.Point(27, 147);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 131);
            this.panel1.TabIndex = 27;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(160)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(339, 290);
            this.Controls.Add(this.grandianPanel1);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.SetChildIndex(this.grandianPanel1, 0);
            this.Controls.SetChildIndex(this.popupTitleBar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grandianPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Loginbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControl.PlaceholderTextBox txtID;
        private CustomControl.PlaceholderTextBox txtPassword;
        private GrandianPanel grandianPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}
