using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace POP
{
    public partial class frmLogViewer : Form
    {
        bool dirty = false;
        string editingFileName = string.Empty;
        string notDirthCaptionFormat = "{0} - Log Viewer";
        string dirthCaptionFormat = "*{0} - Log Viewer";

        public string OpenFileName
        { 
            get { return editingFileName; }
            set { editingFileName = value; }
        }

        public frmLogViewer()
        {
            InitializeComponent();
        }

        private void frmLogViewer_Load(object sender, EventArgs e)
        {
            OpenLogFile();
        }

        private void OpenLogFile()
        {
            if (!string.IsNullOrEmpty(editingFileName))
            {
                if (File.Exists(editingFileName))
                {
                    textBox1.TextChanged -= textBox1_TextChanged;
                    try
                    {
                        StreamReader sr = new StreamReader(editingFileName, Encoding.Default);
                        textBox1.Text = sr.ReadToEnd();
                        sr.Close();

                        dirty = false;
                        UpdateFormText();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                    finally
                    {
                        textBox1.TextChanged += textBox1_TextChanged;
                        textBox1.Select(0, 0);
                    }
                }
            }
        }

        private void UpdateFormText()
        {
            string filename = string.Empty;
            if (editingFileName.Length > 1)
            {
                filename = editingFileName.Substring(editingFileName.LastIndexOf("\\") + 1);
            }
            else
            {
                filename = "제목없음";
            }

            if (dirty)
            {
                this.Text = string.Format(dirthCaptionFormat, filename);
            }
            else
            {
                this.Text = string.Format(notDirthCaptionFormat, filename);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!dirty)
            {
                dirty = true;
                UpdateFormText();
            }
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\stonegram\source\repos\PLCTask\PLCTask\bin\Debug\Logs";

            openFileDialog1.Filter = "log files (*.log)|*.log|txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                editingFileName = openFileDialog1.FileName;

                OpenLogFile();
            }
        }

        private void 새로고침ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLogFile();
        }

        private void 닫기ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 닫기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "log files (*.log)|*.log|txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                editingFileName = saveFileDialog1.FileName;

                try
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default);
                    sw.Write(textBox1.Text);
                    sw.Flush();
                    sw.Close();

                    dirty = false;
                    UpdateFormText();
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }
    }
}
