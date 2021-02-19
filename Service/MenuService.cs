using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
namespace Service
{
    public class MenuService
    {
        public List<MenuVO> GetMenus(int emp_id)
        {
            MenuDAC dac = new MenuDAC();
            return dac.GetMenus(emp_id);
        }

        /// <summary>
        /// 대메뉴 등록
        /// </summary>
        /// <param name="menuName"></param>
        public bool AddLargeMenu(string menuName)
        {
            MenuDAC dac = new MenuDAC();
            return dac.AddLargeMenu(menuName);
        }

        public bool AddSmallMenu(string menuName, string parentName)
        {
            MenuDAC dac = new MenuDAC();
            return dac.AddSmallMenu(menuName, parentName);
        }

        public bool DeleteMenu(string menuName)
        {
            MenuDAC dac = new MenuDAC();
            return dac.DeleteMenu(menuName);
        }

        public bool LinkMenuToForm(string menuName, string formName)
        {
            MenuDAC dac = new MenuDAC();
            return dac.LinkMenuToForm(menuName, formName);
        }

        public bool MenuUpOrder(string menuName)
        {
            MenuDAC dac = new MenuDAC();
            return dac.MenuUpOrder(menuName);
        }

        public bool MenuDownOrder(string menuName)
        {
            MenuDAC dac = new MenuDAC();
            return dac.MenuDownOrder(menuName);
        }

        public List<int> GetMenuAccess(string menuName)
        {
            MenuDAC dac = new MenuDAC();
            return dac.GetMenuAccess(menuName);
        }

        public bool AddMenuAccess(string menuName, List<int> temp)
        {
            MenuDAC dac = new MenuDAC();
            return dac.AddMenuAccess(menuName, temp);
        }
    }
}
