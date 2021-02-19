using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;

namespace CompanyManager
{
    public partial class PopupPerformance : CompanyManager.PopupBaseForm
    {
        public PopupPerformance()
        {

            InitializeComponent();
            CommonUtil.SetInitGridView(dataGridView2);
            CommonUtil.SetDGVDesign_Num(dataGridView2);
            CommonUtil.AddGridTextColumn(dataGridView2, "시작일", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "시작시간", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "완료일", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "완료시간", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView2, "품명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView2, "규격", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView2, "상태", "CompanyName", 60);
            CommonUtil.AddGridTextColumn(dataGridView2, "작업시간(분)", "CompanyName", 80);
            CommonUtil.AddGridTextColumn(dataGridView2, "작업인원", "CompanyName", 60);
            CommonUtil.AddGridTextColumn(dataGridView2, "계획수", "CompanyName", 60);
            CommonUtil.AddGridTextColumn(dataGridView2, "총양품수", "CompanyName", 60);
            CommonUtil.AddGridTextColumn(dataGridView2, "총불량수", "CompanyName", 60);


            dataGridView2.Rows.Add("2020-01-25", "09:00:00", "2020-01-25", "13:00:00", "CHAIR_01", "나무 2인용 의자", "12 * 20 inch", "작업완료", "4", "100", "100", "0");

            CommonUtil.SetInitGridView(dataGridView1);
            CommonUtil.SetDGVDesign_Num(dataGridView1);
            CommonUtil.AddGridCheckColumn(dataGridView1, "");
            CommonUtil.AddGridTextColumn(dataGridView1, "생성일", "CompanyName", 160);
            CommonUtil.AddGridTextColumn(dataGridView1, "작업지시번호", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView1, "품목", "CompanyName", 100);
            CommonUtil.AddGridTextColumn(dataGridView1, "품명", "CompanyName", 120);
            CommonUtil.AddGridTextColumn(dataGridView1, "시작시간", "CompanyName", 160);
            CommonUtil.AddGridTextColumn(dataGridView1, "완료시간", "CompanyName", 160);
            CommonUtil.AddGridTextColumn(dataGridView1, "양품수", "CompanyName", 60);
            CommonUtil.AddGridTextColumn(dataGridView1, "불량수", "CompanyName", 60);
            CommonUtil.AddGridTextColumn(dataGridView1, "작업인원", "CompanyName", 60);

            dataGridView1.Rows.Add(null, "2020-01-25 13:10:25", "WO2020012301", "CHAIR_01", "나무 2인용 의자", "2020-01-25 09:00:00", "2020-01-25 13:00:00", "100", "0", "4");
        }
    }
}
