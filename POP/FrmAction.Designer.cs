
namespace POP
{
    partial class FrmAction
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
            this.timer_Connects = new System.Windows.Forms.Timer(this.components);
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtReadPLC = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox40 = new System.Windows.Forms.TextBox();
            this.textBox39 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox38 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer_Connects
            // 
            this.timer_Connects.Tick += new System.EventHandler(this.timer_Connects_Tick);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.BackColor = System.Drawing.Color.DimGray;
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(1676, 9);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(227, 26);
            this.lblVersion.TabIndex = 15;
            this.lblVersion.Text = "Version";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblVersion.Click += new System.EventHandler(this.lblVersion_Click);
            // 
            // txtReadPLC
            // 
            this.txtReadPLC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReadPLC.Location = new System.Drawing.Point(1480, 3);
            this.txtReadPLC.Name = "txtReadPLC";
            this.txtReadPLC.Size = new System.Drawing.Size(190, 32);
            this.txtReadPLC.TabIndex = 13;
            // 
            // lblPort
            // 
            this.lblPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblPort.Location = new System.Drawing.Point(1404, 14);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 14);
            this.lblPort.TabIndex = 12;
            this.lblPort.Text = "9999";
            // 
            // lblIP
            // 
            this.lblIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblIP.Location = new System.Drawing.Point(1291, 14);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(103, 14);
            this.lblIP.TabIndex = 11;
            this.lblIP.Text = "999.999.999.999";
            // 
            // lblState
            // 
            this.lblState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblState.BackColor = System.Drawing.Color.Yellow;
            this.lblState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblState.Location = new System.Drawing.Point(1253, 9);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(20, 23);
            this.lblState.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 847);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1915, 165);
            this.panel2.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("나눔고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button4.Location = new System.Drawing.Point(1459, 21);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(333, 131);
            this.button4.TabIndex = 3;
            this.button4.Text = "실적저장";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("나눔고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(981, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(333, 131);
            this.button3.TabIndex = 3;
            this.button3.Text = "작업중지";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("나눔고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(462, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(464, 131);
            this.button1.TabIndex = 3;
            this.button1.Text = "작업시작";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.progressBar1);
            this.panel9.Controls.Add(this.textBox28);
            this.panel9.Location = new System.Drawing.Point(12, 756);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1891, 79);
            this.panel9.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(135, 18);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1746, 39);
            this.progressBar1.TabIndex = 2;
            // 
            // textBox28
            // 
            this.textBox28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox28.Font = new System.Drawing.Font("나눔고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox28.ForeColor = System.Drawing.Color.White;
            this.textBox28.Location = new System.Drawing.Point(3, 18);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(133, 39);
            this.textBox28.TabIndex = 1;
            this.textBox28.Text = "진척률";
            this.textBox28.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.textBox8);
            this.panel5.Controls.Add(this.textBox21);
            this.panel5.Location = new System.Drawing.Point(937, 38);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(957, 291);
            this.panel5.TabIndex = 2;
            // 
            // textBox8
            // 
            this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox8.Font = new System.Drawing.Font("나눔고딕", 71.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox8.ForeColor = System.Drawing.Color.White;
            this.textBox8.Location = new System.Drawing.Point(14, 6);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(938, 118);
            this.textBox8.TabIndex = 1;
            this.textBox8.Text = "총 오더량";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox21
            // 
            this.textBox21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox21.BackColor = System.Drawing.Color.Gray;
            this.textBox21.Font = new System.Drawing.Font("나눔고딕", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox21.ForeColor = System.Drawing.Color.Lime;
            this.textBox21.Location = new System.Drawing.Point(14, 134);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(938, 145);
            this.textBox21.TabIndex = 1;
            this.textBox21.Text = "0";
            this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.textBox20);
            this.panel4.Controls.Add(this.textBox19);
            this.panel4.Controls.Add(this.textBox40);
            this.panel4.Controls.Add(this.textBox39);
            this.panel4.Controls.Add(this.textBox18);
            this.panel4.Controls.Add(this.textBox17);
            this.panel4.Controls.Add(this.textBox16);
            this.panel4.Controls.Add(this.textBox15);
            this.panel4.Controls.Add(this.textBox38);
            this.panel4.Controls.Add(this.textBox13);
            this.panel4.Controls.Add(this.textBox27);
            this.panel4.Controls.Add(this.textBox14);
            this.panel4.Location = new System.Drawing.Point(937, 338);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(957, 391);
            this.panel4.TabIndex = 2;
            // 
            // textBox20
            // 
            this.textBox20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox20.Font = new System.Drawing.Font("나눔고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox20.ForeColor = System.Drawing.Color.White;
            this.textBox20.Location = new System.Drawing.Point(700, 434);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(239, 39);
            this.textBox20.TabIndex = 1;
            this.textBox20.Text = "불량 수량";
            this.textBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox19
            // 
            this.textBox19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox19.BackColor = System.Drawing.Color.Gray;
            this.textBox19.Font = new System.Drawing.Font("나눔고딕", 36.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox19.ForeColor = System.Drawing.Color.Red;
            this.textBox19.Location = new System.Drawing.Point(700, 485);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(239, 64);
            this.textBox19.TabIndex = 1;
            this.textBox19.Text = "0100";
            this.textBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox40
            // 
            this.textBox40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox40.Font = new System.Drawing.Font("나눔고딕", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox40.ForeColor = System.Drawing.Color.Cyan;
            this.textBox40.Location = new System.Drawing.Point(563, 198);
            this.textBox40.Name = "textBox40";
            this.textBox40.Size = new System.Drawing.Size(376, 91);
            this.textBox40.TabIndex = 1;
            this.textBox40.Text = "불량 수량";
            this.textBox40.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox39
            // 
            this.textBox39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox39.BackColor = System.Drawing.Color.Gray;
            this.textBox39.Font = new System.Drawing.Font("나눔고딕", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox39.ForeColor = System.Drawing.Color.Red;
            this.textBox39.Location = new System.Drawing.Point(563, 295);
            this.textBox39.Name = "textBox39";
            this.textBox39.Size = new System.Drawing.Size(376, 91);
            this.textBox39.TabIndex = 1;
            this.textBox39.Text = "0";
            this.textBox39.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox18
            // 
            this.textBox18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox18.Font = new System.Drawing.Font("나눔고딕", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox18.ForeColor = System.Drawing.Color.Cyan;
            this.textBox18.Location = new System.Drawing.Point(563, 3);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(376, 91);
            this.textBox18.TabIndex = 1;
            this.textBox18.Text = "총 작업량";
            this.textBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox17
            // 
            this.textBox17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox17.BackColor = System.Drawing.Color.Gray;
            this.textBox17.Font = new System.Drawing.Font("나눔고딕", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox17.ForeColor = System.Drawing.Color.Black;
            this.textBox17.Location = new System.Drawing.Point(563, 100);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(376, 91);
            this.textBox17.TabIndex = 1;
            this.textBox17.Text = "0";
            this.textBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox16
            // 
            this.textBox16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox16.Font = new System.Drawing.Font("나눔고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox16.ForeColor = System.Drawing.Color.White;
            this.textBox16.Location = new System.Drawing.Point(14, 434);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(239, 39);
            this.textBox16.TabIndex = 1;
            this.textBox16.Text = "양품 수량";
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox15
            // 
            this.textBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox15.BackColor = System.Drawing.Color.Gray;
            this.textBox15.Font = new System.Drawing.Font("나눔고딕", 36.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox15.Location = new System.Drawing.Point(14, 485);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(239, 64);
            this.textBox15.TabIndex = 1;
            this.textBox15.Text = "0100";
            this.textBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox38
            // 
            this.textBox38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox38.Font = new System.Drawing.Font("나눔고딕", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox38.ForeColor = System.Drawing.Color.Cyan;
            this.textBox38.Location = new System.Drawing.Point(14, 197);
            this.textBox38.Name = "textBox38";
            this.textBox38.Size = new System.Drawing.Size(372, 91);
            this.textBox38.TabIndex = 1;
            this.textBox38.Text = "양품 수량";
            this.textBox38.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox13.Font = new System.Drawing.Font("나눔고딕", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox13.ForeColor = System.Drawing.Color.White;
            this.textBox13.Location = new System.Drawing.Point(14, 3);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(372, 91);
            this.textBox13.TabIndex = 1;
            this.textBox13.Text = "오더 잔량";
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox27
            // 
            this.textBox27.BackColor = System.Drawing.Color.Gray;
            this.textBox27.Font = new System.Drawing.Font("나눔고딕", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.textBox27.Location = new System.Drawing.Point(14, 295);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(372, 91);
            this.textBox27.TabIndex = 1;
            this.textBox27.Text = "0";
            this.textBox27.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox14
            // 
            this.textBox14.BackColor = System.Drawing.Color.Gray;
            this.textBox14.Font = new System.Drawing.Font("나눔고딕", 54.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox14.ForeColor = System.Drawing.Color.Yellow;
            this.textBox14.Location = new System.Drawing.Point(14, 100);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(372, 91);
            this.textBox14.TabIndex = 1;
            this.textBox14.Text = "0";
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.textBox3);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.textBox9);
            this.panel3.Controls.Add(this.textBox6);
            this.panel3.Controls.Add(this.textBox11);
            this.panel3.Controls.Add(this.textBox10);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Location = new System.Drawing.Point(12, 338);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(919, 391);
            this.panel3.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox3.Font = new System.Drawing.Font("나눔고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(14, 258);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(222, 63);
            this.textBox3.TabIndex = 1;
            this.textBox3.Text = "작업품목";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox2.Font = new System.Drawing.Font("나눔고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox2.ForeColor = System.Drawing.Color.Aqua;
            this.textBox2.Location = new System.Drawing.Point(14, 160);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(222, 63);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "작업자";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.Gray;
            this.textBox9.Font = new System.Drawing.Font("나눔고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox9.ForeColor = System.Drawing.Color.White;
            this.textBox9.Location = new System.Drawing.Point(242, 258);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(672, 63);
            this.textBox9.TabIndex = 1;
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.Color.Gray;
            this.textBox11.Font = new System.Drawing.Font("나눔고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox11.ForeColor = System.Drawing.Color.White;
            this.textBox11.Location = new System.Drawing.Point(242, 160);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(672, 63);
            this.textBox11.TabIndex = 1;
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.Gray;
            this.textBox10.Font = new System.Drawing.Font("나눔고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox10.ForeColor = System.Drawing.Color.White;
            this.textBox10.Location = new System.Drawing.Point(242, 65);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(672, 63);
            this.textBox10.TabIndex = 1;
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.Font = new System.Drawing.Font("나눔고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(15, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(221, 63);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "오더번호";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.textBox12);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Location = new System.Drawing.Point(12, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(919, 291);
            this.panel1.TabIndex = 2;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.Gray;
            this.textBox7.Font = new System.Drawing.Font("나눔고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox7.ForeColor = System.Drawing.Color.White;
            this.textBox7.Location = new System.Drawing.Point(258, 160);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(656, 63);
            this.textBox7.TabIndex = 1;
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.Gray;
            this.textBox5.Font = new System.Drawing.Font("나눔고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox5.ForeColor = System.Drawing.Color.White;
            this.textBox5.Location = new System.Drawing.Point(258, 19);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(656, 63);
            this.textBox5.TabIndex = 1;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox12.Font = new System.Drawing.Font("나눔고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox12.ForeColor = System.Drawing.Color.White;
            this.textBox12.Location = new System.Drawing.Point(15, 160);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(222, 63);
            this.textBox12.TabIndex = 1;
            this.textBox12.Text = "설비";
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox4.Font = new System.Drawing.Font("나눔고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(14, 19);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(222, 63);
            this.textBox4.TabIndex = 1;
            this.textBox4.Text = "작업장";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.Gray;
            this.textBox6.Font = new System.Drawing.Font("나눔고딕", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox6.ForeColor = System.Drawing.Color.White;
            this.textBox6.Location = new System.Drawing.Point(242, -4);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(672, 63);
            this.textBox6.TabIndex = 1;
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox6.Visible = false;
            // 
            // FrmAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(220)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(1915, 1012);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.txtReadPLC);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FrmAction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "rud";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAction_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAction_FormClosed);
            this.Load += new System.EventHandler(this.FrmAction_Load);
            this.panel2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox40;
        private System.Windows.Forms.TextBox textBox39;
        private System.Windows.Forms.TextBox textBox38;
        private System.Windows.Forms.TextBox textBox27;
        private System.Windows.Forms.Timer timer_Connects;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtReadPLC;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox6;
    }
}
