using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using VO;

namespace CompanyManager
{
    public partial class rptPurchases : DevExpress.XtraReports.UI.XtraReport
    {
        private int pid;
        private int totPrice;
        CompanyVO company = new CompanyVO();
        public rptPurchases(int pid, int totPrice,CompanyVO company)
        {
            InitializeComponent();
            this.pid = pid;
            this.totPrice = totPrice;
            this.company = company;
            lblFooter.Text = $"발주번호 : {pid}     총액 : {totPrice.ToString("C")}";
            lblCEO.Text = company.company_ceo;
            lblCompanyName.Text = company.company_name;
            lblEMAIL.Text = company.company_email;
            lblPhone.Text = company.company_phone;
        }

    }
}
