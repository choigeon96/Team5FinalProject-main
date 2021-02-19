using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net.Filter;
using System.Security.Cryptography.X509Certificates;
using Util;
using System.Reflection;

namespace POP
{   
    public partial class CustomTabControl : UserControl
    {
        private Dictionary<string, string> OpenForms; //메뉴이름, 폼이름
        private Dictionary<string, Button> tabList; //메뉴이름, 버튼

        public Button selectedButton;
        public CustomTabControl()
        {
            InitializeComponent();
            OpenForms = new Dictionary<string, string>();
            tabList = new Dictionary<string, Button>();

            //메인으로 나오는 폼, 버튼 딕셔너리에 추가
            OpenForms.Add("메인화면", "FrmPerformance");
            tabList.Add("메인화면", btnHome);

            //OpenForms.Add("설비관리", "FrmAllStatusBoard");
            //tabList.Add("설비관리", btnMachine);

            OpenForms.Add("검사", "FrmInspection");
            tabList.Add("검사", btnInspection);


            //OpenForms.Add("최종조립반", "FrmAction");
            //tabList.Add("최종조립반", button1);

            //OpenForms.Add("Leg_조립반", "FrmAction");
            //tabList.Add("Leg_조립반", button1);

            //OpenForms.Add("SEAT_가공", "FrmAction");
            //tabList.Add("SEAT_가공", button1);

            //OpenForms.Add("LEGS_홀 가공", "FrmAction");
            //tabList.Add("LEGS_홀 가공", button1);

            //OpenForms.Add("외주 작업장", "FrmAction");
            //tabList.Add("외주 작업장", button1);

        }

        //새로운 폼 열림
        public void InsertTab(string menuName, string formName)
        {

            if (!OpenForms.ContainsKey(menuName))
            {
                //열리지 않은 폼이면
                OpenForms.Add(menuName, formName);
                CreateTab(menuName, formName);


                //폼생성
                string appName = Assembly.GetEntryAssembly().GetName().Name;
                Type frmType = Type.GetType($"{appName}.{formName}");

                CommonUtil.OpenCreateForm_POP(ParentForm, frmType);

            }
            
            ((Button)tabList[menuName]).PerformClick();
                

        }

        private void CreateTab(string menuName, string formName)
        {
            Button btn = new Button();
            btn.Text = menuName;
            btn.Tag = formName;

            btn.Location = new Point(4 + (74 * (OpenForms.Count - 1)), 2);  //
            btn.Size = new Size(73, 25); //


            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.FromArgb(216, 220, 227);
            btn.FlatAppearance.BorderColor = Color.FromArgb(154, 161, 169);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(216, 220, 227);
            btn.TextAlign = ContentAlignment.MiddleLeft;

            btn.Click += button_Click;
            pnlTab.Controls.Add(btn);

            //텝리스트에 버튼 추가
            tabList.Add(menuName, btn);

            Button cBtn = new Button();
            cBtn.Text = "X";
            cBtn.Tag = menuName;
            cBtn.FlatStyle = FlatStyle.Flat;
            cBtn.BackColor = Color.FromArgb(216, 220, 227);
            cBtn.FlatAppearance.BorderSize = 0;
            cBtn.Cursor = Cursors.Hand;
            cBtn.ForeColor = Color.Black;

            cBtn.Location = new Point(4 + (74 * (OpenForms.Count - 1)) + 51, 3);
            cBtn.Size = new Size(19, 20);

            cBtn.Click += btnClose_Click;
            pnlTab.Controls.Add(cBtn);
            cBtn.BringToFront();

        }

        //텝/폼 종료버튼
        private void btnClose_Click(object sender, EventArgs e)
        {
            string menuName = ((Button)sender).Tag.ToString();
            foreach (Control item in pnlTab.Controls)
            {
                //해당 텝버튼 할당해제
                if (item.Text.ToString() == menuName)
                {
                    item.Dispose();
                    break;
                }
            }

            //열려있는 폼 닫기
            foreach (Form child in ParentForm.MdiChildren)
            {
                string formName = OpenForms[menuName];
                if (child.GetType().ToString().Split('.')[1] == formName)
                {
                    child.Close();
                    break;
                }
            }

            //openforms ,tablist에서 제거  
            OpenForms.Remove(menuName);
            tabList.Remove(menuName);


            //텝 위치조정
            foreach (Control item in pnlTab.Controls)
            {
                if (item.Location.X > ((Button)sender).Location.X)
                {
                    item.Location = new Point(item.Location.X-74,item.Location.Y);
                }
            }
            //x버튼 할당 해제
            ((Button)sender).Dispose();

            


            //홈버튼 복귀
            btnHome.PerformClick();

        }

        //텝버튼 클릭시 해당 버튼 화면 활성화
        private void button_Click(object sender, EventArgs e)
        {
            //열린폼이면
            
            foreach (Form child in ParentForm.MdiChildren)
            {
                string formName = OpenForms[((Button)sender).Text];
                if (child.GetType().ToString().Split('.')[1] == formName)
                {
                    Util.CommonUtil.OpenCreateForm_POP(ParentForm, child.GetType());
                    break;
                }
            }


            //파란색 위치 조정
            lblSelect.Location = new Point(((Button)sender).Location.X, lblSelect.Location.Y);
            lblSelect.Size = new Size(((Button)sender).Size.Width, lblSelect.Size.Height);


            //아래 검은색 맨위로 올리기
            label3.BringToFront();
            ((Button)sender).BringToFront();
            foreach (Control item in pnlTab.Controls)
            {
                if (item is Button)
                {
                    if (item.Location.X > (((Button)sender)).Location.X
                        && item.Location.X < (((Button)sender)).Location.X + (((Button)sender)).Size.Width)
                    {
                        item.BringToFront();
                    }
                }
            }
            lblSelect.BringToFront();
        }



    }
}
