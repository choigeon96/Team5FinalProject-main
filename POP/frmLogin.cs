using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VO;

namespace POP
{
    public partial class FrmLogin : Form
    {
        // 직접 입력 버튼 클릭 여부
        private bool direct = false;
        // 직접 입력 버튼 클릭시 바뀌는 폼 높이
        private const int D_HEIGHT = 285;

        public FrmLogin()
        {
            InitializeComponent();
        }

        // 폼 로드 이벤트 컨트롤 상태 변경
        private void frmLogin_Load(object sender, EventArgs e)
        {           
            UpdateControls();
            //titleBar1.HeaderText = "로그인";
            txtID.Text = "123";
            txtPassWord.Text = "123";
        }

        // 직접 입력 버튼 클릭시 발생하는 이벤트 컨트롤 상태 변경, 폼 크기 조정
        private void btnDirect_Click(object sender, EventArgs e)
        {
            direct = true;
            UpdateControls();
            this.Height = D_HEIGHT;
        }

        // 컨트롤 상태 변경 메서드
        private void UpdateControls()
        {
            panDirectLogin.Visible = panDirectLogin.Enabled = direct;
            panBarCode.Visible = panBarCode.Enabled = !direct;
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Length < 1 || txtPassWord.Text.Length < 1)
            {
                MessageBox.Show("아이디 또는 비밀번호를 확인해주세요.");
                return;
            }
            EmployeeService emp = new EmployeeService();
            (bool result, EmployeeVO employee) = emp.GetLogin(txtID.Text, txtPassWord.Text);

            if (!result)
            {

                MessageBox.Show("아이디 또는 비밀번호가 일치하지 않습니다. 다시 확인해 주세요.");
                return;
            }
            else
            {
                //txtID.Text = "";
                //txtPassWord.Text = "";
                //this.Hide();
                FrmMain2 main = new FrmMain2(employee);
                main.Show();
            }
         

        }

        private void titleBar1_Load(object sender, EventArgs e)
        {

        }

        private void grandianPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
