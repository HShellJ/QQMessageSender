using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace QQMessageSend
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        private void Form2_Load(object sender, EventArgs e)
        {
           //null
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("打开聊天的窗口，一般是聊天对象的备注名（窗口上应该有显示）");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                FileStream fileStream = new FileStream("log.txt", FileMode.Create, FileAccess.ReadWrite);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(textBox1.Text);
                streamWriter.Close();
                this.Close();
                //判断这个窗体是否有效 
            }
            else
            {
                MessageBox.Show("你输了个寂寞");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //null
        }
    }
}
