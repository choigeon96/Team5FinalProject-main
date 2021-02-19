using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class TitleBar : UserControl
    {
        //public event EventHandler ButtonClick;

        //타이틀바 움직이기
        Point lastLocation;
        bool fMove = false;

        public Color BColor { set { this.BackColor = value; } }

        public string HeaderText 
        {
            get {return label1.Text; }
            set { label1.Text = value; }
        }

        public TitleBar()
        {
            InitializeComponent();
        }

        private void TitleBar_Load(object sender, EventArgs e)
        {
            label1.ForeColor = Color.FromArgb(43, 43, 50);
        }

        private void cancelButton1_Leave(object sender, EventArgs e)
        {
            //cancelButton1.ForeColor = Color.Black;
        }

        private void cancelButton1_MouseUp(object sender, MouseEventArgs e)
        {
            this.ParentForm.Close();
            
        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
            fMove = true;
        }

        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            fMove = false;
        }

        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (fMove)
            {
                Point temp = new Point();
                temp.X = this.ParentForm.Location.X - (lastLocation.X - e.Location.X) / 2;
                temp.Y = this.ParentForm.Location.Y - (lastLocation.Y - e.Location.Y) / 2;

                this.ParentForm.Location = temp;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form)this.Parent).Close();
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            if (((Form)this.Parent).WindowState == FormWindowState.Normal)
            {

                ((Form)this.Parent).WindowState = FormWindowState.Maximized;
                btnSize.BackgroundImage = global::CompanyManager.Properties.Resources.Min;
            }
            else if(((Form)this.Parent).WindowState == FormWindowState.Maximized)
            {

                ((Form)this.Parent).WindowState = FormWindowState.Normal;
                btnSize.BackgroundImage = global::CompanyManager.Properties.Resources.Max;

            }
        }

        private void TitleBar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnSize.PerformClick();
        }
    }
}
