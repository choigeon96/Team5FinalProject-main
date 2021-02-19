namespace POP
{
    partial class CustomTabControl
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.btnInspection = new System.Windows.Forms.Button();
            this.lblSelect = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panel1.Controls.Add(this.pnlTab);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 25);
            this.panel1.TabIndex = 0;
            // 
            // pnlTab
            // 
            this.pnlTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTab.Controls.Add(this.btnInspection);
            this.pnlTab.Controls.Add(this.lblSelect);
            this.pnlTab.Controls.Add(this.btnHome);
            this.pnlTab.Controls.Add(this.label3);
            this.pnlTab.Location = new System.Drawing.Point(22, 0);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Size = new System.Drawing.Size(635, 25);
            this.pnlTab.TabIndex = 2;
            // 
            // btnInspection
            // 
            this.btnInspection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(227)))));
            this.btnInspection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(161)))), ((int)(((byte)(169)))));
            this.btnInspection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInspection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInspection.Location = new System.Drawing.Point(81, 2);
            this.btnInspection.Name = "btnInspection";
            this.btnInspection.Size = new System.Drawing.Size(67, 25);
            this.btnInspection.TabIndex = 9;
            this.btnInspection.Text = "검사";
            this.btnInspection.UseVisualStyleBackColor = false;
            this.btnInspection.Click += new System.EventHandler(this.button_Click);
            // 
            // lblSelect
            // 
            this.lblSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(107)))), ((int)(((byte)(180)))));
            this.lblSelect.Location = new System.Drawing.Point(12, 1);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(67, 2);
            this.lblSelect.TabIndex = 7;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(227)))));
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(161)))), ((int)(((byte)(169)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(12, 2);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(67, 25);
            this.btnHome.TabIndex = 6;
            this.btnHome.Text = "메인화면";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.button_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(161)))), ((int)(((byte)(169)))));
            this.label3.Location = new System.Drawing.Point(-3, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(638, 1);
            this.label3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(161)))), ((int)(((byte)(169)))));
            this.label1.Location = new System.Drawing.Point(0, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 1);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(161)))), ((int)(((byte)(169)))));
            this.label2.Location = new System.Drawing.Point(429, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 1);
            this.label2.TabIndex = 4;
            // 
            // CustomTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "CustomTabControl";
            this.Size = new System.Drawing.Size(660, 25);
            this.panel1.ResumeLayout(false);
            this.pnlTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnInspection;
    }
}
