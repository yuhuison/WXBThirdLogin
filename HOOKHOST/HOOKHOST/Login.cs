using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace HOOKHOST
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public string ve;
        public string ve2;
        public MainForm mf;
        private void Login_Load(object sender, EventArgs e)
        {
            textBox1.Text= MainForm.GetValue("wxbfz","website","",ve2);
            textBox2.Text = MainForm.GetValue("wxbfz", "username", "", ve2);
            textBox3.Text = MainForm.GetValue("wxbfz", "password", "", ve2);

        }
        public static String string2MD5(String strSource)
        {
            byte[] result = Encoding.UTF8.GetBytes(strSource);
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }
        internal static string Utf2Ansi(string UtfString)
        {
            Byte[] change = System.Text.Encoding.UTF8.GetBytes(UtfString);
            Byte[] changde = Encoding.Convert(System.Text.Encoding.UTF8, System.Text.Encoding.Unicode, change);
            return Encoding.Unicode.GetString(changde);

        }
        private void Button2_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Headers.Add("UserAgent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            string username = textBox2.Text;
            string website = textBox1.Text;
            string password = textBox3.Text;

            string salt = MainForm.GetTimeStamp();
            string pwd = string2MD5(username+password+salt+"WINUPON");
            string pwd2 = string2MD5(username + string2MD5(password).ToLower() + salt + "WINUPON");
            string url = "http://"+website + "/courseList.action?uid=" + username;
            url = url + "&pwd=" + pwd.ToLower() + "&pwd2=" + pwd2.ToLower() + "&salt=" + salt + "&callfrom=vplogintool&mac=66:66:66:66:66:66";

            string iRet="";
            try
            {
               iRet = client.DownloadString(url);
            }
            catch {
                MessageBox.Show("无法访问"+website);
            }
            if (iRet.Length > 100)
            {
                MainForm.SetValue("wxbfz", "website", website, ve2);
                MainForm.SetValue("wxbfz", "username", username, ve2);
                MainForm.SetValue("wxbfz", "password", password, ve2);
                System.IO.File.WriteAllText(ve+".utf.ini", iRet);
                StreamReader sr = new StreamReader(ve + ".utf.ini");
                StreamWriter sw = new StreamWriter(ve, false, Encoding.Default);

                sw.WriteLine(sr.ReadToEnd());

                sw.Close();
                sr.Close();
                mf.RefreshClass();
                MessageBox.Show("登陆成功！");
                this.Dispose();
            }
            else {
                MessageBox.Show("登陆错误！");
            }

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
