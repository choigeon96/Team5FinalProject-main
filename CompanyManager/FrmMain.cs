//using Microsoft.Office.Interop.Excel;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Forms;
using VO;

namespace CompanyManager
{
    public partial class FrmMain : Form
    {
        FrmLogin login;
        List<MenuVO> menuAllList;
        Color buttonColor = Color.FromArgb(142, 160, 185);
        Color selectedColor = Color.Blue;
        Button selectedBtn;


        //VO 형식 관리자 
        private EmployeeVO loginInfo = new EmployeeVO { emp_id = 10 ,emp_name = "직원1" };

        public EmployeeVO LoginInfo
        {
            get { return loginInfo; }
           
        }


        public string Admin { get; set; }


        public FrmMain(EmployeeVO emp, FrmLogin login)
        {
            loginInfo = emp;
            this.login = login;
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            //메인폼 실행
            Program.Log.WriteInfo("CompanyManager_FrmMain 시작");

            //메뉴 리스트 가져오기
            MenuService service = new MenuService();
            menuAllList = service.GetMenus(loginInfo.emp_id);

            //메뉴 생성
            CreatMenu();

            //폼(Home)열기
            string formName = "FrmHome";
            string appName = Assembly.GetEntryAssembly().GetName().Name;
            Type frmType = Type.GetType($"{appName}.{formName}");


            Util.CommonUtil.OpenCreateForm(this, frmType);
            if(loginInfo.dept_no == "9")
            {
                btnCommonM.Visible = true;
                btnEmployeeM.Visible = true;
            }
        }

        //메뉴 생성
        private void CreatMenu()
        {
            //빈값 생성
            selectedBtn = new Button(); 

            int count = 0;
            menuAllList.ForEach(p =>
            {
                //▶로 시작하는 메뉴는 대메뉴 버튼 생성
                if (p.INFO.Trim().StartsWith("▶"))
                {
                    Button btn = new Button();
                    btn.Name = p.INFO.Trim().Substring(1);
                    btn.Text = btn.Name;
                    btn.Tag = "Large";
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = buttonColor;
                    btn.Location = new Point(-1, -1+ (42 * count));
                    btn.Size = new Size(180, 45);
                    btn.Click += Btn_Click;
                    pnlMenu.Controls.Add(btn);
                    count++;
                }
            });
        }

        //메뉴버튼 클릭 이벤트
        //소메뉴 생성
        private void Btn_Click(object sender, EventArgs e)
        {
            ////메뉴 중복선택 확인
            //if (selectedBtn == ((Button)sender))
            //    return;

            //메뉴 위치 복구 (이미 선택된 메뉴가 있다면)
            foreach (Control ctrl in pnlMenu.Controls)
            {
                if (ctrl is TreeView)
                {
                    pnlMenu.Controls.Remove(ctrl);

                    foreach (Control btn in pnlMenu.Controls)
                    {
                        if (btn is Button)
                        {
                            if (btn.Location.Y > selectedBtn.Location.Y)
                            {
                                btn.Location = new Point(-1, btn.Location.Y - 300);
                            }
                        }
                    }
                    //메뉴 중복선택 확인
                    if (selectedBtn == ((Button)sender))
                        return;

                    break;
                }
            }

            
            selectedBtn = ((Button)sender);

            //메뉴 위치 변경
            foreach (Control btn in pnlMenu.Controls)
            {
                if (btn is Button)
                {
                    if (btn.Location.Y > selectedBtn.Location.Y)
                    {
                        btn.Location = new Point(-1, btn.Location.Y + 300);
                    }
                }
            }



            //트리뷰 생성
            TreeView tv = new TreeView();
            tv.BorderStyle = BorderStyle.None;
            tv.Location = new Point(-1, selectedBtn.Location.Y+48);
            tv.Size = new Size(180, 300);
            tv.ImageList = imageList1;
            tv.DoubleClick += treeView_Click;
            pnlMenu.Controls.Add(tv);

            TreeNode tn = new TreeNode(selectedBtn.Text);
            tn.Tag = selectedBtn.Tag;
            tv.Nodes.Add(tn);
            TreeNode tnc;
            menuAllList.ForEach(p =>
            {
                //현재 메뉴버튼의 소메뉴이면 
                if (p.INFO.Trim().StartsWith("L") && p.SortName.StartsWith(selectedBtn.Text))
                {
                    string[] names = p.SortName.Split('>');
                    tnc = new TreeNode(p.INFO.Trim().Substring(1));
                    tnc.Tag = p.FormName + "@" + p.SortName;
                    tnc.Name = names[names.Length - 1];
                    if (names.Length == 2)
                        tn.Nodes.Add(tnc);
                    else
                    {
                        TreeNode ptn = tv.Nodes.Find(names[names.Length - 2], true)[0];
                        ptn.Nodes.Add(tnc);
                    }
                }
            });

            tv.ExpandAll();

        }


        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            //메인폼 종료 로그
            Program.Log.WriteInfo("CompanyManager_FrmMain 종료");
            Program.Log.WriteInfo("프로그램 종료");
            
        }

        //폼 열기
        private void treeView_Click(object sender, EventArgs e)
        {
            TreeView tv = (TreeView)sender;
            if (tv.SelectedNode == null)
                return;
            if (!tv.SelectedNode.Tag.ToString().StartsWith("@") && !tv.SelectedNode.Tag.ToString().StartsWith("Large"))
            {
                string formName = ((TreeView)sender).SelectedNode.Tag.ToString().Split('@')[0];
                string appName = Assembly.GetEntryAssembly().GetName().Name;
                Type frmType = Type.GetType($"{appName}.{formName}");

                Util.CommonUtil.OpenCreateForm(this, frmType);
            }
        }


        //Mdi폼이 열릴때마다 해당 폼의 SortName을 화면 상단에 표시
        private void FrmMain_MdiChildActivate(object sender, EventArgs e)
        {
            //MessageBox.Show(this.ActiveMdiChild.GetType().ToString());
            if (this.ActiveMdiChild.GetType().ToString().Split('.')[1] == "FrmHome")
            {
                lblSortName.Text = "Home";
                return;
            }


            string sortName = menuAllList.Find(p => 
            {
                if (p.FormName !=null)
                {
                    return p.FormName.Equals(this.ActiveMdiChild.GetType().ToString().Split('.')[1]);
                }
                return false;
                
            }).SortName;


            lblSortName.Text = sortName;

            string[] temp1 = sortName.Split('>');
            string[] temp2 = this.ActiveMdiChild.GetType().ToString().Split('.');

            customTabControl1.InsertTab(temp1[temp1.Length - 1], temp2[temp2.Length-1]);

           

            
        }

        //최대화 최소화
        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }
            foreach (Form item in this.MdiChildren)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    item.Size = new Size(1738, 927);
                }
                else
                {
                    item.Size = new Size(1168, 647);
                }
            }
            
            
            
        }

        private void btnCommonM_Click(object sender, EventArgs e)
        {
            PopupCommon frm = new PopupCommon();
            frm.ShowDialog();

            pnlMenu.Controls.Clear();
            this.Form1_Load(this,null);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("로그아웃 하시겠습니까?", "로그아웃 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                login.Show();
            }
            else
                e.Cancel = true;
        }

        private void btnEmployeeM_Click(object sender, EventArgs e)
        {
            FrmEmployee frm = new FrmEmployee(loginInfo.emp_id);
            frm.ShowDialog();
        }
    }
}
