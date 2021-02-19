using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class GrandianPanel : Panel
    {
        public Color ColorTop { get; set; }
        public Color ColorBotton { get; set; }
        
        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, ColorTop, ColorBotton, 90F);
            g.FillRectangle(lgb, this.ClientRectangle);
            base.OnPaint(pe);
        }
    }
}
