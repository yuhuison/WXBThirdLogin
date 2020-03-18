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


namespace WXBWPF
{
    public partial class Login : Form
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public Login()
        {
            InitializeComponent();
        }
        public string ve;
        public string ve2;
        public Window1 mf;
        public string string2MD5(string a) {
            return MD5.MDString(a);
            

        }
        private void Login_Load(object sender, EventArgs e)
        {
            textBox1.Text = GetValue("wxbfz", "website", "", ve2);
            textBox2.Text = GetValue("wxbfz", "username", "", ve2);
            textBox3.Text = GetValue("wxbfz", "password", "", ve2);

        }
        public static bool SetValue(string Section, string Key, string Value, string iniFilePath)
        {
            var pat = Path.GetDirectoryName(iniFilePath);
            if (Directory.Exists(pat) == false)
            {
                Directory.CreateDirectory(pat);
            }
            if (File.Exists(iniFilePath) == false)
            {
                File.Create(iniFilePath).Close();
            }
            long OpStation = WritePrivateProfileString(Section, Key, Value, iniFilePath);
            if (OpStation == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static string GetValue(string Section, string Key, string defaultText, string iniFilePath)
        {
            if (File.Exists(iniFilePath))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, defaultText, temp, 1024, iniFilePath);
                return temp.ToString();
            }
            else
            {
                return defaultText;
            }
        }
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 8, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        internal static string Utf2Ansi(string UtfString)
        {
            Byte[] change = System.Text.Encoding.UTF8.GetBytes(UtfString);
            Byte[] changde = Encoding.Convert(System.Text.Encoding.UTF8, System.Text.Encoding.Unicode, change);
            return Encoding.Unicode.GetString(changde);

        }
        private void Button2_Click(object sender, EventArgs e)
        {


        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Headers.Add("UserAgent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            string username = textBox2.Text;
            string website = textBox1.Text;
            string password = textBox3.Text;

            string salt = GetTimeStamp();
            string pwd = string2MD5(username + password + salt + "WINUPON");
            string pwd2 = string2MD5(username + string2MD5(password).ToLower() + salt + "WINUPON");
            string url = "http://" + website + "/courseList.action?uid=" + username;
            url = url + "&pwd=" + pwd.ToLower() + "&pwd2=" + pwd2.ToLower() + "&salt=" + salt + "&callfrom=vplogintool";

            string iRet = "";
            try
            {
                iRet = client.DownloadString(url);
            }
            catch
            {
                MessageBox.Show("无法访问" + website);
            }
            if (iRet.Length > 100)
            {
                SetValue("wxbfz", "website", website, ve2);
                SetValue("wxbfz", "username", username, ve2);
                SetValue("wxbfz", "password", password, ve2);
                System.IO.File.WriteAllText(ve + ".utf.ini", iRet);
                StreamReader sr = new StreamReader(ve + ".utf.ini");
                StreamWriter sw = new StreamWriter(ve, false, Encoding.Default);

                sw.WriteLine(sr.ReadToEnd());

                sw.Close();
                sr.Close();
                MessageBox.Show("登陆成功！");
                this.Dispose();
                mf.RefreshClass();
            }
            else
            {
                MessageBox.Show("登陆错误！");
            }
        }
    }
}
