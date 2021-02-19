namespace POP
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            POP.TitleBar titleBar1;
            this.grandianPanel1 = new POP.GrandianPanel();
            this.panBarCode = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDirect = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panDirectLogin = new System.Windows.Forms.Panel();
            this.txtPassWord = new POP.PlaceholderTextBox();
            this.txtID = new POP.PlaceholderTextBox();
            this.button1 = new System.Windows.Forms.Button();
            titleBar1 = new POP.TitleBar();
            this.grandianPanel1.SuspendLayout();
            this.panBarCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panDirectLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grandianPanel1
            // 
            this.grandianPanel1.ColorBotton = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(223)))), ((int)(((byte)(232)))));
            this.grandianPanel1.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(160)))), ((int)(((byte)(185)))));
            this.grandianPanel1.Controls.Add(this.panBarCode);
            this.grandianPanel1.Controls.Add(this.pictureBox1);
            this.grandianPanel1.Controls.Add(this.panDirectLogin);
            this.grandianPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grandianPanel1.Location = new System.Drawing.Point(0, 33);
            this.grandianPanel1.Name = "grandianPanel1";
            this.grandianPanel1.Size = new System.Drawing.Size(339, 252);
            this.grandianPanel1.TabIndex = 22;
            this.grandianPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.grandianPanel1_Paint);
            // 
            // panBarCode
            // 
            this.panBarCode.BackColor = System.Drawing.Color.Transparent;
            this.panBarCode.Controls.Add(this.label1);
            this.panBarCode.Controls.Add(this.btnDirect);
            this.panBarCode.Location = new System.Drawing.Point(27, 139);
            this.panBarCode.Name = "panBarCode";
            this.panBarCode.Size = new System.Drawing.Size(285, 49);
            this.panBarCode.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "바코드를 입력";
            // 
            // btnDirect
            // 
            this.btnDirect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(44)))));
            this.btnDirect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnDirect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDirect.ForeColor = System.Drawing.Color.White;
            this.btnDirect.Location = new System.Drawing.Point(212, 3);
            this.btnDirect.Name = "btnDirect";
            this.btnDirect.Size = new System.Drawing.Size(72, 42);
            this.btnDirect.TabIndex = 13;
            this.btnDirect.Text = "직접 입력";
            this.btnDirect.UseVisualStyleBackColor = false;
            this.btnDirect.Click += new System.EventHandler(this.btnDirect_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::POP.Properties.Resources.LOGO_T;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(285, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // panDirectLogin
            // 
            this.panDirectLogin.BackColor = System.Drawing.Color.Transparent;
            this.panDirectLogin.Controls.Add(this.txtPassWord);
            this.panDirectLogin.Controls.Add(this.txtID);
            this.panDirectLogin.Controls.Add(this.button1);
            this.panDirectLogin.Location = new System.Drawing.Point(27, 115);
            this.panDirectLogin.Name = "panDirectLogin";
            this.panDirectLogin.Size = new System.Drawing.Size(285, 131);
            this.panDirectLogin.TabIndex = 20;
            // 
            // txtPassWord
            // 
            this.txtPassWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(44)))));
            this.txtPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtPassWord.Location = new System.Drawing.Point(10, 47);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PlaceholderText = "비밀번호";
            this.txtPassWord.Size = new System.Drawing.Size(264, 31);
            this.txtPassWord.TabIndex = 17;
            this.txtPassWord.UseSystemPasswordChar = true;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(44)))));
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.txtID.Location = new System.Drawing.Point(10, 18);
            this.txtID.Name = "txtID";
            this.txtID.PlaceholderText = "ID";
            this.txtID.PlaceholderTextColor = System.Drawing.Color.Silver;
            this.txtID.Size = new System.Drawing.Size(264, 31);
            this.txtID.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(44)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(10, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(264, 41);
            this.button1.TabIndex = 16;
            this.button1.Text = "로그인";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // titleBar1
            // 
            titleBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(160)))), ((int)(((byte)(185)))));
            titleBar1.Dock = System.Windows.Forms.DockStyle.Top;
            titleBar1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            titleBar1.HeaderText = "Login";
            titleBar1.Location = new System.Drawing.Point(0, 0);
            titleBar1.Name = "titleBar1";
            titleBar1.Size = new System.Drawing.Size(339, 33);
            titleBar1.TabIndex = 21;
            titleBar1.Load += new System.EventHandler(this.titleBar1_Load);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(160)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(339, 285);
            this.Controls.Add(this.grandianPanel1);
            this.Controls.Add(titleBar1);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.Text = "로그인";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.grandianPanel1.ResumeLayout(false);
            this.panBarCode.ResumeLayout(false);
            this.panBarCode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panDirectLogin.ResumeLayout(false);
            this.panDirectLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panBarCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDirect;
        private System.Windows.Forms.Panel panDirectLogin;
        private System.Windows.Forms.Button button1;
        private PlaceholderTextBox txtPassWord;
        private PlaceholderTextBox txtID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private GrandianPanel grandianPanel1;
    }
}