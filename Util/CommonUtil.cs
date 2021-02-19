using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Drawing;
using System.ComponentModel;


namespace Util

{
    public class CommonUtil
    {
        public static string RoadApiKey
        {
            get
            {
                string RoadApiKey = string.Empty;
                XmlDocument configXml = new XmlDocument();
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) + "/CarProductionUtil_XML.xml";
                configXml.Load(path);

                XmlNodeList addNodes = configXml.SelectNodes("configuration/settings/add");

                foreach (XmlNode node in addNodes)
                {
                    if (node.Attributes["key"].InnerText == "RoadAPIKey")
                    {
                        RoadApiKey = (node.ChildNodes[0]).InnerText;
                        break;
                    }
                }
                return RoadApiKey;
            }
        }

        public static void BindingComboBox<T>(ComboBox cbo, List<T> vo, string valueMember, string displayMember)
        {

            cbo.DisplayMember = displayMember;
            cbo.ValueMember = valueMember;
            cbo.DataSource = vo;
        }

        #region 콤보
        public static void BindingComboBoxPart<T>(ComboBox cbo, List<T> vo, string displayMember)
        {


            cbo.DisplayMember = displayMember;
            cbo.DataSource = vo;
        }


        #endregion
        public static void SetInitGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        public static void AddGridTextColumn(
                            DataGridView dgv,
                            string headerText,
                            string dataPropertyName,
                            int colWidth = 100,
                            bool visibility = true,
                            DataGridViewContentAlignment textAlign = DataGridViewContentAlignment.MiddleLeft)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.SortMode = DataGridViewColumnSortMode.NotSortable;
            col.HeaderText = headerText;
            col.Name = dataPropertyName;
            col.DataPropertyName = dataPropertyName;
            col.Width = colWidth;
            col.DefaultCellStyle.Alignment = textAlign;
            col.Visible = visibility;
            col.ReadOnly = true;
            dgv.Columns.Add(col);
        }
        public static void AddGridButtonColumn(DataGridView dgv, string headerText, string columnName, string buttonText, int btnWidth = 50, int padding = 0)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.SortMode = DataGridViewColumnSortMode.NotSortable;
            btn.HeaderText = headerText;
            btn.Name = columnName;
            btn.Text = buttonText;
            btn.Width = btnWidth;
            btn.DefaultCellStyle.Padding = new Padding(padding);
            btn.UseColumnTextForButtonValue = true;
            dgv.Columns.Add(btn);
        }

        public static void AddGridImageColumn(DataGridView dgv, Image image, string columnName, int width = 50)
        {
            DataGridViewImageColumn col = new DataGridViewImageColumn();

            col.SortMode = DataGridViewColumnSortMode.NotSortable;
            col.Image = image;
            col.HeaderText = columnName;
            col.Name = columnName;
            col.Width = width;
            col.ImageLayout = DataGridViewImageCellLayout.Normal;
            dgv.Columns.Add(col);
        }


        public static void AddGridCheckColumn(DataGridView dgv, string columnName, int btnWidth = 20, int padding = 0, bool enable = true)
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.SortMode = DataGridViewColumnSortMode.NotSortable;
            chk.Name = columnName;
            chk.Width = btnWidth;
            chk.HeaderText = string.Empty;
            chk.DefaultCellStyle.Padding = new Padding(padding);
            dgv.Columns.Add(chk);
        }
        public static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// 그리드뷰 디자인 설정
        /// </summary>
        public static void SetDGVDesign(DataGridView dgv)
        {
            // TODO - 임시 주석 제거 // **// 
            // **// dgv.AutoGenerateColumns = false;
            // **// dgv.AllowUserToAddRows = false;

            dgv.AutoGenerateColumns = false;
            dgv.MultiSelect = false; //열하나만선택

            dgv.AllowUserToResizeColumns = true; // 칼럼 사용자 변경 o
            dgv.AllowUserToResizeRows = false; //사용자가임의로 로우의 크기를 변경시킬수 없게     

            dgv.RowHeadersVisible = false; // 맨왼쪽에 있는 컬럼 삭제
            // dgv.RowHeadersWidth = 20;     // 맨왼쪽에 있는 컬럼 사이즈 변경   

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // 한줄전체선택
            //dgv.CellBorderStyle = DataGridViewCellBorderStyle.None; //테두리삭제

            dgv.BackgroundColor = Color.White; // Color.FromArgb(248, 241, 233); //그리드뷰 배경색
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);   // 로우 해더 색설정     
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230); //홀수 행 색
            //dgv.DefaultCellStyle.BackColor = Color.FromArgb(248, 241, 233);//Color.FromArgb(248, 241, 233); // 전체 행 색
            //dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(145, 224, 244); // 선택 로우 색
            dgv.AllowUserToAddRows = false;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgv.SelectionChanged += Dgv_SelectionChanged;
        }

        /// <summary>
        /// 그리드뷰 디자인 설정
        /// </summary>
        public static void SetDGVDesign_Num(DataGridView dgv)
        {
            // TODO - 임시 주석 제거 // **// 
            // **// dgv.AutoGenerateColumns = false;
            // **// dgv.AllowUserToAddRows = false;

            dgv.AutoGenerateColumns = false;

            dgv.MultiSelect = false; //열하나만선택

            dgv.AllowUserToResizeColumns = true; // 칼럼 사용자 변경 o
            dgv.AllowUserToResizeRows = false; //사용자가임의로 로우의 크기를 변경시킬수 없게     

            dgv.RowHeadersVisible = false; // 맨왼쪽에 있는 컬럼 삭제
            // dgv.RowHeadersWidth = 20;     // 맨왼쪽에 있는 컬럼 사이즈 변경   

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // 한줄전체선택
            //dgv.CellBorderStyle = DataGridViewCellBorderStyle.None; //테두리삭제

            dgv.BackgroundColor = Color.White; // Color.FromArgb(248, 241, 233); //그리드뷰 배경색
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);   // 로우 해더 색설정     
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230); //홀수 행 색
            //dgv.DefaultCellStyle.BackColor = Color.FromArgb(248, 241, 233);//Color.FromArgb(248, 241, 233); // 전체 행 색
            //dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(145, 224, 244); // 선택 로우 색

            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgv.AllowUserToAddRows = false;
            dgv.RowPostPaint += Dgv_RowPostPaint;
            dgv.SelectionChanged += Dgv_SelectionChanged;
            dgv.Paint += CommonUtil_Paint;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        public static void SetDGVDesign_Num1(DataGridView dgv)
        {
            // TODO - 임시 주석 제거 // **// 
            // **// dgv.AutoGenerateColumns = false;
            // **// dgv.AllowUserToAddRows = false;

            dgv.AutoGenerateColumns = false;

            dgv.MultiSelect = false; //열하나만선택

            dgv.AllowUserToResizeColumns = true; // 칼럼 사용자 변경 o
            dgv.AllowUserToResizeRows = false; //사용자가임의로 로우의 크기를 변경시킬수 없게     

           
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // 한줄전체선택
            //dgv.CellBorderStyle = DataGridViewCellBorderStyle.None; //테두리삭제

            dgv.BackgroundColor = Color.White; // Color.FromArgb(248, 241, 233); //그리드뷰 배경색
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);   // 로우 해더 색설정     
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230); //홀수 행 색
            //dgv.DefaultCellStyle.BackColor = Color.FromArgb(248, 241, 233);//Color.FromArgb(248, 241, 233); // 전체 행 색
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(145, 224, 244); // 선택 로우 색

            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgv.AllowUserToAddRows = false;
            dgv.RowPostPaint += Dgv_RowPostPaint1;
            dgv.SelectionChanged += Dgv_SelectionChanged;
            dgv.Paint += CommonUtil_Paint;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private static void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            //((DataGridView)sender).ClearSelection();
        }

        public static void SetDGVDesign_CheckBox(DataGridView dgv)
        {
            //헤더 체크박스 생성
            CheckBox checkBox = new CheckBox();
            checkBox.Text = string.Empty;
            checkBox.BackColor = dgv.BackgroundColor;
            checkBox.Size = new Size(15, 15);
            checkBox.Location = new Point(dgv.Location.X + 54, dgv.Location.Y + 5);

            dgv.Parent.Controls.Add(checkBox);
            checkBox.BringToFront();
            //체크박스 컬럼 추가
            AddGridCheckColumn(dgv, "checkBox");
            dgv.Columns["checkBox"].ReadOnly = true;
            //스크롤 이벤트 등록
            dgv.Scroll += dgv_Scroll;
            void dgv_Scroll(object sender, ScrollEventArgs e)
            {
                if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                {
                    checkBox.Location = new Point(checkBox.Location.X - (e.NewValue - e.OldValue), checkBox.Location.Y);
                    checkBox.Visible = checkBox.Location.X > ((DataGridView)sender).Location.X + 50;
                }

            }
            //헤더 체크박스 클릭 이벤트 등록
            checkBox.Click += CheckBox_Click;
            void CheckBox_Click(object sender, EventArgs e)
            {
                dgv.CellValueChanged -= Dgv_CellValueChanged;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    ((DataGridViewCheckBoxCell)row.Cells["checkBox"]).Value = checkBox.Checked;
                }
                dgv.CellValueChanged += Dgv_CellValueChanged;
            }
            dgv.CellClick += RowCheckBox_Click;
            void RowCheckBox_Click(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex < 0 || e.ColumnIndex != 0)
                    return;
                if (dgv.Columns[e.ColumnIndex].Name.Equals("checkBox") && e.RowIndex >= 0)
                {
                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.Value = !Convert.ToBoolean(cell.Value);

                    bool isChecked = true;

                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        DataGridViewCheckBoxCell cell2 = (DataGridViewCheckBoxCell)dgv.Rows[i].Cells["checkBox"];
                        if (Convert.ToBoolean(cell2.EditedFormattedValue) == false)
                        {
                            isChecked = false;
                            break;
                        }
                    }

                    checkBox.Checked = false;
                    checkBox.Checked = isChecked;
                }
            }
            dgv.CellValueChanged += Dgv_CellValueChanged;

            void Dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex < 0 || e.ColumnIndex != 0)
                    return;
                bool IsAllChecked = true;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == false)
                    {
                        IsAllChecked = false;
                        break;
                    }
                }
                checkBox.Checked = IsAllChecked;
            }
        }


        //행번호 추가
        private static void Dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            

            ((DataGridView)sender).RowHeadersWidth = 50;
            ((DataGridView)sender).RowHeadersVisible = true;
            StringFormat drawFormat = new StringFormat();
            //drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            using (Brush brush = new SolidBrush(Color.Black))
            {

                //TextRenderer.DrawText(e.Graphics,"No.", e.InheritedRowStyle.Font,new Point(e.RowBounds.Location.X + 25, 5),Color.Black);
                //TextRenderer.DrawText(e.Graphics,"No.", e.InheritedRowStyle.Font,new Point(19,5),Color.Black);
                //e.Graphics.DrawString("No.", e.InheritedRowStyle.Font,brush, e.RowBounds.Location.X + 35, e.RowBounds.Location.Y -20, drawFormat);
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, brush, e.RowBounds.Location.X + 35, e.RowBounds.Location.Y + 4, drawFormat);
            }
        }
        private static void Dgv_RowPostPaint1(object sender, DataGridViewRowPostPaintEventArgs e)
        {


            ((DataGridView)sender).RowHeadersWidth = 100;
            ((DataGridView)sender).RowHeadersVisible = true;
            StringFormat drawFormat = new StringFormat();
            //drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            using (Brush brush = new SolidBrush(Color.Black))
            {

                //TextRenderer.DrawText(e.Graphics,"No.", e.InheritedRowStyle.Font,new Point(e.RowBounds.Location.X + 25, 5),Color.Black);
                //TextRenderer.DrawText(e.Graphics,"No.", e.InheritedRowStyle.Font,new Point(19,5),Color.Black);
                //e.Graphics.DrawString("No.", e.InheritedRowStyle.Font,brush, e.RowBounds.Location.X + 35, e.RowBounds.Location.Y -20, drawFormat);
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, brush, e.RowBounds.Location.X + 35, e.RowBounds.Location.Y + 4, drawFormat);
            }
        }

        private static void CommonUtil_Paint(object sender, PaintEventArgs e)
        {
            //데이터 바인딩이 ㅇ되지않으면 no출력 X
            if (((DataGridView)sender).Rows.Count < 1)
                return;

            TextRenderer.DrawText(e.Graphics, "No.", ((DataGridView)sender).Font, new Point(19, 5), Color.Black);
        }



        /// <summary>
        /// Form 실행 메서드
        /// </summary>
        /// <typeparam name="T">생성할 폼 타입</typeparam>
        /// <param name="owner">생성할 폼의 부모폼이 될 객체</param>
        /// <param name="openMdi">Mdi여부 true = Mdi, false = ShowDialog로 실행</param>
        public static void OpenCreateForm<T>(bool openMdi = false, Form owner = null) where T : Form, new()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(T))
                {
                    form.Activate();
                    return;
                }
            }

            T frm = new T();
            if (!openMdi)
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = owner;
                frm.Show();
            }
        }
        public static void OpenCreateFormPOP<T>(bool openMdi = false, Form owner = null) where T : Form, new()
        {
          
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(T))
                {
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.WindowState = FormWindowState.Maximized;
                    form.Location = new Point(0, 0);
                    form.Activate();
                    return;
                }
            }

            T frm = new T();
            if (!openMdi)
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.Location = new Point(0, 0);
                frm.ShowDialog();
            }
            else
            {
                frm.MdiParent = owner;
                frm.Show();
            }
        }

        public static void AddGridViewDetail<T1, T2>(DataGridView senderGrid, List<object> lists, string[] columnNames, string[] properties, int rowIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// parent 폼 받아서 type형식 폼 mdi로열기
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="type"></param>
        public static void OpenCreateForm(Form parent, Type type)
        {
            Size formSize = new Size(1168, 647);

            if (parent.WindowState == FormWindowState.Maximized)
            {
                formSize = new Size(1738, 927);
            }



            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == type)
                {
                    form.Size = formSize;
                    form.Activate();
                    return;
                }
            }
            Form frm = ((Form)Activator.CreateInstance(type));
            frm.MdiParent = parent;
            frm.Show();
            frm.Location = new Point(0, 0);
            frm.Size = formSize;
            //호출 한 뒤 parent폼의 mdichild폼 위치 재설정필요
        }

        /// <summary>
        /// parent 폼 받아서 type형식 폼 mdi로열기
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="type"></param>
        public static void OpenCreateForm_POP(Form parent, Type type)
        {
            Size formSize = new Size(1915, 1012);
            
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == type)
                {
                    form.Size = formSize;
                    form.Activate();
                    return;
                }
            }
            Form frm = ((Form)Activator.CreateInstance(type));
            frm.MdiParent = parent;
            frm.Show();
            frm.Location = new Point(0, 0);
            frm.Size = formSize;
            //호출 한 뒤 parent폼의 mdichild폼 위치 재설정필요
        }



        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        //이미지를 바이트로 바꿔서 리턴
        //바이트를 이미지로 바꿔서 리턴 
        public static Image ByteToImage(byte[] data)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
            return (Bitmap)(tc.ConvertFrom(data));
        }


        /// <summary>
        /// DataGridView의 상세 목록 DataGridView를 생성하는 메서드
        /// </summary>
        /// <typeparam name="P">부모 DataGridView에 바인딩된 DataSource의 타입</typeparam>
        /// <typeparam name="C">자식 DataGridView에 바인딩할 DataSource의 List</typeparam>
        /// <param name="parent">상세 목록을 보여줄 부모 DataGridView</param>
        /// <param name="childSource">바인딩할 DataSource</param>
        /// <param name="columnNames">바인딩할 ColumnName의 배열</param>
        /// <param name="properties">바인딩할 DataPropertyName의 배열</param>
        /// <param name="rowIndex">상세 목록을 생성할 부모의 rowIndex</param>
        /// <param name="startIndex">바인딩을 시작할 ColumnIndex</param>
        /// <param name="fontColor">폰트 색깔</param>
        /// <param name="backColor">배경 색깔</param>
        /// <param name="childEnable">자식 DataGridView의 Enable 여부</param>
        /// columnNames, properties의 순서는 같게 입력
        /// parent는 AutoScroll 속성이 있는 컨테이너에서 사용 ex)panel
        /// parent는 Docking X / 오른쪽 스크롤바 크기 이상 여백 두기
        /// 최종때는 컨트롤로 묶을 예정
        public static void AddGridViewDetail<P, C>
            (DataGridView parent, List<C> childSource, string[] columnNames, string[] properties, int rowIndex, int startIndex = -1,
            Color fontColor = default(Color), Color backColor = default(Color), bool childEnable = false) where P : new()
        {
            if (childSource.Count < 1)
                return;

            string newName = parent.Name + parent[0, rowIndex].Value.ToString();

            // 이미 생성된 상세 목록이 있는경우 목록 삭제 후 return
            DataGridView child = new DataGridView();
            foreach (Control item in parent.Parent.Controls)
            {
                if (item.Name.Equals(newName))
                {
                    child = (DataGridView)item;
                    // 부모 DataGridView에 추가했던 Row 삭제
                    List<P> list = (List<P>)parent.DataSource;
                    for (int i = 0; i < child.Rows.Count + 1; i++)
                    {
                        list.RemoveAt(rowIndex + 1);
                    }
                    // 다른 상세 목록 DataGridView 위치 조정
                    foreach (Control elem in parent.Parent.Controls)
                    {
                        if (elem.Location.Y > child.Location.Y)
                            elem.Location = new Point(elem.Location.X, elem.Location.Y - child.Height);
                    }
                    // 자식 DagaGridView 삭제
                    parent.Parent.Controls.Remove(child);
                    child.Dispose();
                    // 부다 DataGridView 다시 바인딩
                    parent.DataSource = null;
                    parent.DataSource = list;
                    return;
                }
            }

            // 추가할 자식 dgv 
            DataGridView dgv = new DataGridView();
            // 자식 dgv 초기화
            CommonUtil.SetInitGridView(dgv);
            Point pLocation = parent.Location;
            // 헤더 컬럼 추가
            DataGridViewTextBoxColumn header = new DataGridViewTextBoxColumn();
            header.Width = parent.RowHeadersWidth;
            dgv.Columns.Add(header);

            // 컬럼 추가(부모 그리드 뷰의 컬럼 크기와 동일) -> 추가
            foreach (DataGridViewColumn item in parent.Columns)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.Width = item.Width;
                dgv.Columns.Add(column);
            }
            // 그리드뷰 기본 속성
            dgv.Width = parent.Width - 3;
            dgv.Height = (parent.Rows[0].Height * (childSource.Count + 1)) + 1;
            dgv.ColumnHeadersVisible = true;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.Enabled = childEnable;
            dgv.ForeColor = Color.Equals(backColor, default(Color)) ? Color.Black : fontColor;
            dgv.RowsDefaultCellStyle.BackColor = dgv.RowHeadersDefaultCellStyle.BackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor =
                Color.Equals(backColor, default(Color)) ? Color.LightGray : backColor;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.Location = new Point(pLocation.X + 1, pLocation.Y + ((rowIndex + 2) * parent.Rows[0].Height));
            dgv.BorderStyle = BorderStyle.None;

            // 자식 그리드 뷰에 데이터 바인딩 startIndex가 -1(default)이면 오른쪽에 붙어서 바인딩
            int propCnt = properties.Length;
            int start = startIndex == -1 ? dgv.Columns.Count - propCnt : startIndex;
            for (int i = 0; i < propCnt; i++)
            {
                dgv.Columns[start + i].Name = columnNames[i];
                dgv.Columns[start + i].DataPropertyName = properties[i];
            }
            dgv.DataSource = childSource;


            // 컨트롤 추가
            dgv.Name = newName; // dgv이름 + rowindex
            parent.Parent.Controls.Add(dgv);
            dgv.ClearSelection();
            dgv.BringToFront();
            // 숫자는 오른쪽, 문자는 왼쪽 정렬
            for (int i = start; i < dgv.Columns.Count; i++)
            {

                dgv.Columns[i].HeaderCell.Style.Alignment = dgv.Columns[i].DefaultCellStyle.Alignment =
                    (dgv[i, 0].Value is int) ? DataGridViewContentAlignment.MiddleRight : DataGridViewContentAlignment.MiddleLeft;
            }
            // 부모 그리드 뷰에 빈 값 추가
            List<P> temp = (List<P>)parent.DataSource;
            for (int i = 0; i < childSource.Count + 1; i++)
            {
                temp.Insert(rowIndex + 1, new P());
            }
            parent.Height += dgv.Height;
            // 다른 상세 목록 DataGridView 위치 조정
            foreach (Control item in parent.Parent.Controls)
            {
                if (item.Location.Y > dgv.Location.Y)
                    item.Location = new Point(item.Location.X, item.Location.Y + dgv.Height);
            }
            // 부모 그리드 뷰 다시 바인딩
            parent.DataSource = null;
            parent.DataSource = temp;

        }

        public static void AddGridComboBoxColumn(DataGridView dgv, string headerText, string columnName, string displayMember, string valueMember, int cboWidth = 50)
        {
            DataGridViewComboBoxColumn cbo = new DataGridViewComboBoxColumn();
            cbo.HeaderText = headerText;
            cbo.Name = columnName;
            cbo.Width = cboWidth;
            cbo.DisplayMember = displayMember;
            //cbo.DataPropertyName = valueMember;
            cbo.ValueMember = valueMember;
            dgv.Columns.Add(cbo);
        }

        

    }
}
