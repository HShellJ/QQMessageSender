using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace QQMessageSend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);//用来获取窗口句柄
        string Form2text = "";
        IntPtr ChickH;//用来存放选定窗口的句柄
        [DllImport("User32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        private void Form1_Load(object sender, EventArgs e)
        {
            //从form2那里拿到对话框的句柄
            Form form = new Form2();
            form.ShowDialog();
            FileStream fileStream = new FileStream("log.txt",FileMode.Open,FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            Form2text = streamReader.ReadLine();
            streamReader.Close();
            form.Dispose();
            //判断form2
            IntPtr ParenthWnd;
            ParenthWnd = FindWindow(null, Form2text);
            //判断这个窗体是否有效 
            if (ParenthWnd != IntPtr.Zero)
            {
                MessageBox.Show("找到窗口，点击确定开始下一步");
                ChickH = ParenthWnd;
            }

            else
            {
                MessageBox.Show("没有找到窗口，是不是输错字了？");
                Environment.Exit(0);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //null
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("你要发送个寂寞");
            }
            else
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("你这是要发几次");
                }
                else
                {
                    ShowWindow(ChickH, 0);//控制窗口显示和隐藏，0是隐藏，1是显示
                    ShowWindow(ChickH, 1);
                    for (int i = 0; i < Convert.ToInt32(textBox2.Text); i++)
                    {
                        SendKeys.SendWait(textBox1.Text);//发送字
                        SendKeys.SendWait("{ENTER}");//回车
                        System.Threading.Thread.Sleep(Convert.ToInt32(textBox3.Text));
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("程序由Trevor开发，邮箱2519041062@qq.com\n禁止使用此软件进行违法活动，请严格遵守当地法律！","提示",MessageBoxButtons.OK);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            FileStream fileStream = new FileStream("log.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            Form2text = streamReader.ReadLine();
            ChickH = FindWindow(null, streamReader.ReadLine());
            streamReader.Close();
        }
    }
}
