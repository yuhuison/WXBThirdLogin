using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WXBWPF
{
    public partial class debug : Form
    {
        string de = Environment.GetEnvironmentVariable("LocalAppData") + "\\Winupon\\Vizpower\\debug.txt";
        public debug()
        {
            InitializeComponent();
        }

        private void Debug_Load(object sender, EventArgs e)
        {
            if (File.Exists(de)==false) {
                MessageBox.Show("未接受到消息，插件可能未注入,请关闭杀毒软件再尝试，并不是所有的运行环境都能支持的");
                Dispose();
            }
            timer1.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (File.Exists(de))
            {
                string m="";
                try
                {
                    m = File.ReadAllText(de);
                    textBox1.Text = m;
                }
                catch {

                }
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }
    }
}
