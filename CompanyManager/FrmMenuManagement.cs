using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VO;

namespace CompanyManager
{
    public partial class FrmMenuManagement : CompanyManager.MDIBaseForm
    {
        List<MenuVO> menuAllList;
        public FrmMenuManagement()
        {
            InitializeComponent();
        }

        private void FrmMenuManagement_Load(object sender, EventArgs e)
        {
            Service.MenuService service = new Service.MenuService();
            menuAllList = service.GetMenus(0);

            
            menuAllList.ForEach(p =>
            {
                TreeNode tn = null;
                if (p.INFO.Trim().StartsWith("▶"))
                {
                    tn = new TreeNode(p.INFO.Trim().Substring(1));
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
                        if (names.Length == 2)
                            tn.Nodes.Add(tnc);
                        else
                        {
                            
                            
                            TreeNode ptn = treeView1.Nodes.Find(names[names.Length - 2], true)[0];
                            ptn.Nodes.Add(tnc);
                        }
                    }
                });



            });

            treeView1.ExpandAll();
            
        }
    }
}
