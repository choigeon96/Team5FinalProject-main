using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using VO;

namespace CompanyManager
{
    public partial class PopupCommon : CompanyManager.PopupBaseForm
    {

        List<MenuVO> menuAllList;
        List<CodeVO> codeAllList;

        TreeNode selectedNdoe = null;
        public PopupCommon()
        {
            InitializeComponent();
            popupTitleBar1.HeaderText = "공통관리";
            lbForm.Enabled = false;
            btnLink.Enabled = false;
        }

        private void PopupCommon_Load(object sender, EventArgs e)
        {
            //메뉴관리
            LoadMenuList();


            LoadFormList();

            //공통코드관리
            dataGridView1.AutoGenerateColumns = false;

            Image img = Properties.Resources.Edit_16x16;
            Util.CommonUtil.SetDGVDesign_Num(dataGridView1);
            Util.CommonUtil.AddGridCheckColumn(dataGridView1, "", 20);
            Util.CommonUtil.AddGridImageColumn(dataGridView1, img, "Edit", 40);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "코드", "code", 80);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "카테고리", "category", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "코드명", "name", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "pCode", "pcode", 80);


            Service.EmployeeService service = new Service.EmployeeService();
            clbdept.DataSource = service.GetDept();
            clbdept.DisplayMember = "dept_name";
            clbdept.ValueMember = "dept_id";

        }

        private void LoadCommonCode()
        {
            Service.CodeService service = new Service.CodeService();
            codeAllList = service.GetAllCommonCode();
            dataGridView1.DataSource = codeAllList;
            //체크박스 초기값
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                item.Cells[0].Value = false;
            }
        }

        private void LoadFormList()
        {
            List<string> temp = new List<string>();
            foreach (var item in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
            {
                string formName = item.ToString().Split('.')[1];
                if (formName.ToLower().StartsWith("frm"))
                {
                    temp.Add(formName);
                }
            }
            lbForm.DataSource = temp;
            lbForm.SelectedItem = null;
        }

        //메뉴리스트 불러오기
        private void LoadMenuList()
        {
            lbForm.Enabled = false;
            btnLink.Enabled = false;

            treeView1.Nodes.Clear();

            Service.MenuService service = new Service.MenuService();
            menuAllList = service.GetMenus(0);

            menuAllList.ForEach(p =>
            {
                TreeNode tn = null;
                if (p.INFO.Trim().StartsWith("▶"))
                {
                    tn = new TreeNode(p.INFO.Trim().Substring(1));
                    tn.Tag = "Large";
                    treeView1.Nodes.Add(tn);
                }


                menuAllList.ForEach(T =>
                {
                    //현재 메뉴버튼의 소메뉴이면 
                    if (T.INFO.Trim().StartsWith("L") && T.SortName.StartsWith(p.INFO.Trim().Substring(1)))
                    {
                        TreeNode tnc;
                        string[] names = T.SortName.Split('>');
                        tnc = new TreeNode(T.INFO.Trim().Substring(1));
                        tnc.Name = names[names.Length - 1];
                        tnc.Tag = "Small";
                        if (names.Length == 2)
                            tn.Nodes.Add(tnc);
                        else
                        {
                            TreeNode ptn = treeView1.Nodes.Find(names[names.Length - 2], true)[0];
                            ptn.Nodes.Add(tnc);
                        }


                        if (selectedNdoe != null)
                        {
                            if (tn.Text.Trim() == selectedNdoe.Text.Trim())
                            {
                                selectedNdoe = tn;
                            }
                            if (tnc.Text.Trim() == selectedNdoe.Text.Trim())
                            {
                                selectedNdoe = tnc;
                            }
                            selectedNdoe.BackColor = SystemColors.MenuHighlight;
                            selectedNdoe.ForeColor = Color.White;
                        }
                    }
                });
            });

            treeView1.ExpandAll();
            treeView1.SelectedNode = selectedNdoe;
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                this.Size = new Size(874, 548);
            }
            else if(tabControl1.SelectedIndex == 1)
            {
                this.Size = new Size(594, 608);
                LoadCommonCode();
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //이전 노드 색상 원래대로
            if (selectedNdoe != null)
            {
                selectedNdoe.ForeColor = Color.Black;
                selectedNdoe.BackColor = Color.White;
            }

            selectedNdoe = e.Node;
            treeView1.SelectedNode = e.Node;
            e.Node.BackColor = SystemColors.MenuHighlight;
            e.Node.ForeColor = Color.White;



            //대메뉴 클릭시
            if (e.Node.Tag.ToString() == "Large")
            {
                clbdept.Enabled = true;
                btndeptadd.Enabled = true;
                lbForm.Enabled = false;
                btnLink.Enabled = false;

                for (int i = 0; i < clbdept.Items.Count; i++)
                {
                    clbdept.SetItemChecked(i, false);
                }

                Service.MenuService service = new Service.MenuService();
                List<int> dept = service.GetMenuAccess(e.Node.Text.Trim());


                for (int i = 0; i < clbdept.Items.Count; i++)
                {
                    foreach (int no in dept)
                    {
                        if(((DeptVO)clbdept.Items[i]).dept_id == no)
                        {
                            clbdept.SetItemChecked(i, true);
                        }
                    }
                    
                } 

                return;
            }

            clbdept.Enabled = false;
            btndeptadd.Enabled = false;
            lbForm.Enabled = true;
            btnLink.Enabled = true;

            
            //폼 연결되있으면 리스트박스에서 선택
            MenuVO menu = menuAllList.Find(p => p.SortName.Split('>')[p.SortName.Split('>').Length - 1].Equals(treeView1.SelectedNode.Text.Trim()));
            if (menu == null||menu.FormName == null)
            {
                lbForm.SelectedItem = null;
                return;
            }
            
            foreach (var item in lbForm.Items)
            {
                if (item.ToString() == menu.FormName)
                {
                    lbForm.SelectedItem = item;
                    return;
                }
            }


            lbForm.SelectedItem = null;

        }

        //대메뉴 추가
        private void btnLargeMenu_Click(object sender, EventArgs e)
        {
            PopupMenu pop = new PopupMenu();
            if (pop.ShowDialog() == DialogResult.OK)
            {
                Service.MenuService service = new Service.MenuService();
                if (service.AddLargeMenu(pop.MenuName))
                    MessageBox.Show("메뉴가 등록되었습니다.");
                else
                    MessageBox.Show("이미 존재하는 메뉴명입니다.");
            }

            LoadMenuList();
        }

        //소메뉴 추가
        private void btnSmallMenu_Click(object sender, EventArgs e)
        {

            //메뉴 선택
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("메뉴를 선택해주세요");
                return;
            }

            PopupMenu pop = new PopupMenu();
            if (pop.ShowDialog() == DialogResult.OK)
            {
                Service.MenuService service = new Service.MenuService();
                if (service.AddSmallMenu(pop.MenuName, treeView1.SelectedNode.Text.Trim()))
                    MessageBox.Show("메뉴가 등록되었습니다.");
                else
                    MessageBox.Show("이미 존재하는 메뉴명입니다.");
            }
            LoadMenuList();

        }

        //메뉴 삭제
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("메뉴를 선택해주세요");
                return;
            }

            //대메뉴 삭제시도시 소메뉴가 있으면 못하게 막아야함
            if (treeView1.SelectedNode.Nodes.Count > 0)
            {
                MessageBox.Show("메뉴 삭제 전 하위 메뉴를 모두 삭제해야 합니다.");
                return;
            }

            Service.MenuService service = new Service.MenuService();
            if (service.DeleteMenu(treeView1.SelectedNode.Text.Trim()))
                MessageBox.Show("메뉴가 삭제되었습니다.");
            else
                MessageBox.Show("존재하지 않는 메뉴입니다.");

            LoadMenuList();
        }

        //메뉴와 폼 연결
        private void btnLink_Click(object sender, EventArgs e)
        {
            Service.MenuService service = new Service.MenuService();
            if (service.LinkMenuToForm(treeView1.SelectedNode.Text.Trim(),lbForm.SelectedItem.ToString()))
                MessageBox.Show("적용되었습니다.");
            else
                MessageBox.Show("적용중 오류가 발생하였습니다.");
        }

        //메뉴 순서 위로
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("메뉴를 선택해주세요");
                return;
            }

            Service.MenuService service = new Service.MenuService();
            if (!service.MenuUpOrder(treeView1.SelectedNode.Text.Trim()))
            {
                MessageBox.Show("순서를 변경하지 못했습니다.");
            }
            else
            {
                LoadMenuList();
            }


        }

        //메뉴 순서 아래로 
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("메뉴를 선택해주세요");
                return;
            }

            Service.MenuService service = new Service.MenuService();
            if (!service.MenuDownOrder(treeView1.SelectedNode.Text.Trim()))
            {
                MessageBox.Show("순서를 변경하지 못했습니다.");
            }
            else
            {
                LoadMenuList();
            }
        }


        //공통코드 추가 이벤트
        private void btnAdd_Click(object sender, EventArgs e)
        {
            PopupCode pop = new PopupCode();
            if (pop.ShowDialog() == DialogResult.OK)
            {
                Service.CodeService service = new Service.CodeService();
                if(!service.AddCommonCode(new CodeVO 
                {
                    code = pop.Code,
                    category = pop.Category,
                    name = pop.CodeName,
                    pcode = pop.Pcode
                }))
                {
                    MessageBox.Show("코드등록 중 오류가 발생하였습니다.");
                }
                else
                {
                    LoadCommonCode();
                }
                

            }

        }

        //수정 이미지 클릭시 수정 메서드 발생
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                EditCode(e);
            }
        }

        private void EditCode(DataGridViewCellEventArgs e)
        {
            //수정할 코드 정보 팝업창에 로드
            PopupCode pop = new PopupCode();
            pop.Code = dataGridView1[2, e.RowIndex].Value.ToString();
            pop.Category = dataGridView1[3, e.RowIndex].Value.ToString();
            pop.CodeName = dataGridView1[4, e.RowIndex].Value.ToString();
            pop.Pcode = dataGridView1[5, e.RowIndex].Value == null ? "": dataGridView1[5, e.RowIndex].Value.ToString();


            //수정할 값 가져ㅑ와서 수정
            if (pop.ShowDialog() == DialogResult.OK)
            {
                Service.CodeService service = new Service.CodeService();

                if (!service.EditCommonCode(new CodeVO
                {
                    code = pop.Code,
                    category = pop.Category,
                    name = pop.CodeName,
                    pcode = pop.Pcode
                }))
                {
                    MessageBox.Show("코드수정 중 오류가 발생하였습니다.");
                }
                else
                {
                    LoadCommonCode();
                }
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            List<String> codeList = new List<string>();

            //체크된 공통코드의 코드값 읽어오기
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if ((bool)item.Cells[0].Value)
                {
                    codeList.Add(item.Cells[2].Value.ToString());
                }
            }

            //선택이 되지 않았으면 return
            if (codeList.Count < 1)
            {
                MessageBox.Show("삭제할 공통코드를 선택해주세요");
                return;
            }

            //코드 리스트를 받아 삭제
            if (MessageBox.Show($"총 {codeList.Count}개의 코드를 삭제하시겠습니까?","메뉴삭제",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Service.CodeService service = new Service.CodeService();
                if (!service.DeleteCommonCode(codeList))
                {
                    MessageBox.Show("코드삭제 중 오류가 발생하였습니다.");
                }
                else
                {
                    LoadCommonCode();
                }
            }

        }

        //공통코드 검색 
        private void btnSearch_Click(object sender, EventArgs e)
        {
           

            //모든컬럼에 or로 검색
            var result = from code in codeAllList
                         where code.code.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                                code.category.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                                code.name.ToLower().Contains(txtSearch.Text.Trim().ToLower()) ||
                                code.pcode != null && code.pcode.ToLower().Contains(txtSearch.Text.Trim().ToLower())
                         select code;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = result.ToList();

            txtSearch.Text = "";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSearch.PerformClick();
            }
        }

        private void clbdept_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void clbdept_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void clbdept_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clbdept.SetItemChecked(clbdept.SelectedIndex, true);

            //if (clbdept.GetItemChecked(clbdept.SelectedIndex))
            //    clbdept.SetItemChecked(clbdept.SelectedIndex, true);
            //else
            //    clbdept.SetItemChecked(clbdept.SelectedIndex, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> temp = new System.Collections.Generic.List<int>();

            foreach (DeptVO vo in clbdept.CheckedItems)
            {
                temp.Add(vo.dept_id);
            }
            Service.MenuService service = new Service.MenuService();
            if(!service.AddMenuAccess(treeView1.SelectedNode.Text.Trim(), temp))
                MessageBox.Show("메뉴권한 등록 중 오류가 발생했습니다.");
            else
                MessageBox.Show("적용되었습니다.");
        }
    }
}
