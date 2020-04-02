/*
 * Created by SharpDevelop.
 * User: Sang
 * Date: 2020/3/16 星期一
 * Time: 8:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using MahApps.Metro.Controls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;

namespace WXBWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : MetroWindow
    {
        [DllImport("WXBCJ2.4.dll")]
        public static extern void WXBSB();
        [DllImport("WXBCJ2.4.dll")]
        public static extern void HouQiDonLoop();
        [DllImport("WXBCJ2.4.dll")]
        public static extern void PPTOUTPUT();
        [DllImport("WXBCJ2.4.dll")]
        public static extern void AutoCall();


        [DllImport("kernel32.dll")] 

        public static extern int VirtualAllocEx(IntPtr hwnd, int lpaddress, int size, int type, int tect);

        [DllImport("kernel32.dll")]
        public static extern int WriteProcessMemory(IntPtr hwnd, int baseaddress, string buffer, int nsize, int filewriten);

        [DllImport("kernel32.dll")]
        public static extern int GetProcAddress(int hwnd, string lpname);

        [DllImport("kernel32.dll")]
        public static extern int GetModuleHandleA(string name);

        [DllImport("kernel32.dll")]
        public static extern int CreateRemoteThread(IntPtr hwnd, int attrib, int size, int address, int par, int flags, int threadid);

        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        internal static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        string ve = Environment.GetEnvironmentVariable("LocalAppData") + "\\Winupon\\Vizpower\\tmp\\loginmeetinglist.ini";
        // ve 课堂配置文件路径
        string ve2 = Environment.GetEnvironmentVariable("LocalAppData") + "\\Winupon\\Vizpower\\logintool.ini";
        string dir = Environment.GetEnvironmentVariable("LocalAppData") + "\\Winupon\\Vizpower\\tmp";

        // ve2 登陆配置文件路径
        string pwxb = @"C:\Program Files (x86)\wxb\iMeeting2.exe#C:\Program Files (x86)\wxb\iMeeting.exe#C:\Program Files\wxb\iMeeting2.exe#C:\Program Files\wxb\iMeeting.exe#D:\Program Files (x86)\wxb\iMeeting2.exe#D:\Program Files (x86)\wxb\iMeeting.exe#D:\Program Files\wxb\iMeeting2.exe#D:\Program Files\wxb\iMeeting.exe#E:\Program Files\wxb\iMeeting2.exe#E:\Program Files\wxb\iMeeting.exe#E:\Program Files (x86)\wxb\iMeeting2.exe#E:\Program Files (x86)\wxb\iMeeting.exe#D:\iMeeting2.exe#D:\iMeeting.exe#D:\wxb\iMeeting2.exe#D:\wxb\iMeeting.exe#C:\wxb\iMeeting2.exe#C:\wxb\iMeeting.exe#F:\Program Files\wxb\iMeeting2.exe#F:\Program Files\wxb\iMeeting.exe#F:\Program Files (x86)\wxb\iMeeting2.exe#F:\Program Files (x86)\wxb\iMeeting.exe";
        //pwxb 以“#”分割的一段文本 储存了无限宝目录的可能值
        string xmwb = "AdURL#AutoRecordPrompt#AllowHLS#ClientType#ClassNoteURL#CameraRemind#ClassAutoLock#CCStudy#ClassRoom#DeanTeacher#exeurl#EditTestStdAns#FeedbackURL#GreenScreenURL#GiftURL#GiftToken#HtmPPT#InitialOpenVideoSend#InitialShowOwnerVideo#InviteCode#IPVCamera#Language#listenType#MeetId#MeetStartTime#MeetCurrTime#MaxOpenVideo#MaxOpenAudio#Meeting-Subject#Meeting-Chairman#Meeting-Duration#Meeting-BeforeTime#Meeting-AddTime#m_strEvaluateURL#m_strDocURL#MeetingQuitURL#MeetingQuitText#MeetingSwitchURL#MultiVideoChannels#NickName#NetTraffic#NeedSSR#NoVPLogo#NDConf#NoAppShare#NoNetDisk#NoPlayMedia#NetDiskProtocol#NetDiskUploadURL#NetDiskNotifyURL#NetDiskUserName#NetDiskUserPasswd#OnlyTeacherAudio#OemStringURL#ProjectName#Port#ProxyAllocType#RecordBlackList#RestVodURL#ServerIP#StuSchool#StuClass#StuPhone#SmsTempletURL#SmsInterval#SnapUploadURL#ShowVideoForP2P#SilenceMode#SilenceModeNotifyWindow#StudentDetailURL##ShowUserCount#STick#SKey#TeacherOverviewURL#TestResultURL#timesId#UseYaHei#userId#UDPPort#UIType#UserRosterURL#VoteResultURL#VerifyKey#VideoQualityLevel#VoteTemplateURL#WinAppTitle";
        //xmwb 以“#”分割的一段文本 储存了无限宝启动所需的所有参数
        string[] xmwbs;
        string[] kclb;
        string[] pwxbs;
        string dllidname = "WXBCJ2.4.dll";
        
        // GetValue(节名称,键名称，默认文本，INI文件路径) 从INI文件中读取指定项的值
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
        public void RefreshClass()
        {

            label2.Content = "";
            listbox1.Items.Clear();
            
            //获得当前已经登陆的用户名
            if (System.IO.File.Exists(ve2))
            {

                label2.Content = "当前已登陆账号:" + GetValue("wxbfz", "username", "未登录，请刷新课程", ve2);

            }
            //kclb 所有课程对应的ID列表
            kclb = (GetValue("list", "mtid", "", ve)).Split(',');
            foreach (string l in kclb)
            {
                //向列表框中加入课程
                listbox1.Items.Add(GetValue("mt" + l, "Meeting-Subject", "", ve));
            }
            //数组 无限宝目录的可能值
            pwxbs = pwxb.Split('#');
        }
        public Window1()
		{
            
			InitializeComponent();
		}

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }
        public static bool IsHasCHZN(string inputData)
        {

            Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }
        public static string DecodeBase64(string code_type, string code)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(code);
            try
            {
                decode = Encoding.GetEncoding(code_type).GetString(bytes);
            }
            catch
            {
                decode = code;
            }
            return decode;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login f = new Login();
            f.ve = ve;
            f.ve2 = ve2;
            f.mf = this;
            f.Show();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            stopImeeting();
            if (textBox2.Text != "")
            {
                bool run = true;
                if (File.Exists(textBox2.Text) == false) {
                    run = false;
                    MessageBox.Show("iMeeting.exe路径不正确");

                }
                string str = "94AEB546-26AE-48da-AC3A-B15BF1245699";
                //无限宝的 GUID
                if (listbox1.SelectedIndex != -1)
                {

                    string xml = "";
                    //MessageBox.Show("mt" + kclb[listBox1.SelectedIndex]);
                    foreach (string l in xmwbs)
                    {
                        //默认从配置文件中读取参数
                        string m = GetValue("mt" + kclb[listbox1.SelectedIndex], l, "", ve);
                        //修改参数
                        if ((bool)checkBox1.IsChecked)
                        {
                            if (l == "ClassAutoLock")
                            {
                                m = "0";
                            }
                        }
                        if ((bool)checkBox2.IsChecked)
                        {
                            if (l == "ShowUserCount")
                            {
                                m = "1";
                            }
                        }

                        if ((bool)checkBox4.IsChecked)
                        {
                            if (l == "RecordBlackList")
                            {
                                m = "";
                            }
                        }
                        if (l == "STick") {
                            if (m == "")
                            {
                                run = false;
                                MessageBox.Show("登陆过期~请重新登陆");
                            }
                            else {
                                int k = int.Parse(m);
                                int j = int.Parse(Login.GetTimeStamp());
                                if ((k - j) < -86400) {
                                    run = false;
                                    MessageBox.Show("登陆过期~请重新登陆");
                                }

                            }

                        }

                        xml = xml + "<" + str + l + ">" + m + "</" + str + ">";

                    }
                    if (run) {
                        //xml = xml + "<" + str + "UseYaHei>" + "1"+ "</" + str + ">";
                        //xml = xml + "<" + str + "Language>" + "2" + "</" + str + ">";
                        //xml = xml + "<" + str + "SilenceMode>" + "1" + "</" + str + ">";
                        //xml = xml + "<" + str + "listenType>" + "-2" + "</" + str + ">";
                        System.Diagnostics.Process.Start(textBox2.Text, xml);//启动无限宝
                    }
                    
                    //button5.Visible = true;

                }
                else
                {
                    MessageBox.Show("请先选择课程！");

                }
                if ((bool)checkBox5.IsChecked&&run)
                {
                    int ok1;

                    int baseaddress;
                    int temp = 0;
                    int hack;
                    int yan;
                    string dllname;

                    dllname = dllidname;
                    //MessageBox.Show(dllname);
                    int dlllength;
                    dlllength = dllname.Length + 1;
                    if (File.Exists(dllname) == false)
                    {
                        label4.Content = ("DLL不存在！");
                    }
                    Process[] pname = Process.GetProcesses(); //取得所有进程

                    foreach (Process name in pname) //遍历进程
                    {
                        //MessageBox.Show(name.ProcessName.ToLower());
                        if (name.ProcessName.ToLower().IndexOf("imeeting") != -1) //那么下面开始注入
                        {

                            baseaddress = VirtualAllocEx(name.Handle, 0, dlllength, 4096, 4);   //申请内存空间
                            if (baseaddress == 0) //返回0则操作失败，下面都是
                            {
                                label4.Content = ("申请内存空间失败！！");
                                
                            }

                            ok1 = WriteProcessMemory(name.Handle, baseaddress, dllname, dlllength, temp); //写内存
                            if (ok1 == 0)
                            {
                                label4.Content = ("写内存失败！！");
                                
                            }
                            // MessageBox.Show(GetModuleHandleA("kernel32.dll").ToString());
                            hack = GetProcAddress(GetModuleHandleA("kernel32"), "LoadLibraryA"); //取得loadlibarary在kernek32.dll地址

                            if (hack == 0)
                            {
                                label4.Content = ("无法取得函数的入口点！！");
                                
                            }

                            yan = CreateRemoteThread(name.Handle, 0, 0, hack, baseaddress, 0, temp); //创建远程线程。

                            if (yan == 0)
                            {
                                label4.Content = ("创建远程线程失败！！");
                                
                            }
                            else
                            {

                                label4.Content = ("已成功注入dll!!");

                                //SetWindowPos(WXBJB,(IntPtr)-1,0,0,0,0,);
                            }
                        }
                    }
                }
            }
            else
            {
                label4.Content = ("iMeeting.exe 未填写 程序无法启动");

            }
        }
        string GetMl()
        {
            return GetRegistryValue("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{4C26091B-502D-475F-94FF-1A26AF917645}", "InstallLocation");
        }
        protected string GetRegistryValue(string path, string paramName)
        {
            string value = string.Empty;
            RegistryKey root = Registry.LocalMachine;
            RegistryKey rk = root.OpenSubKey(path);
            if (rk != null)
            {
                value = (string)rk.GetValue(paramName, null);
            }
            return value;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
         
            button4.Visibility = Visibility.Hidden;
            
            if (IsHasCHZN(System.IO.Directory.GetCurrentDirectory())) {
                MessageBox.Show("检测到程序运行目录中含有中文，插件注入可能会失效");
            }
            Assembly assembly = GetType().Assembly;
            //这时候的路径是：命名空间+文件路径，以点相隔
            System.IO.Stream streamSmall = assembly.GetManifestResourceStream("WXBWPF.bg.png");

            //这个BitmapImage是wpf中的类
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();//开始初始化
            bitmap.StreamSource = streamSmall;
            bitmap.EndInit();//结束初始化
            SetValue("wxbfz", "modifyRenZhenRate", "0", ve2);
            this.bg.Source = bitmap;

            if (!Directory.Exists(dir))
            {//如果不存在就创建 dir 文件夹  
                Directory.CreateDirectory(dir);
            }
            RefreshClass();
            checkBox5.IsEnabled = File.Exists(dllidname);
            if (!System.IO.File.Exists(ve2))
            {

            }

            //读取配置文件 的目录
            if (GetValue("wxbfz", "mulu", "", ve2) != "")
            {
                textBox2.Text = GetValue("wxbfz", "mulu", "", ve2);
            }
            else
            {
                foreach (string l in pwxbs)
                {
                    if (System.IO.File.Exists(l))
                    {
                        textBox2.Text = l;
                        break;
                    }

                }
            }
            //如果找不到无限宝的目录 用注册表的方法寻找
            if (textBox2.Text == "")
            {
                if (GetMl() != "")
                {
                    textBox2.Text = GetMl() + "iMeeting.exe";
                }
                else
                {
                    MessageBox.Show("程序未能找到无限宝程序所在位置，请手动键入");
                }

            }
            xmwbs = xmwb.Split('#');
        }

        private void CheckBox5_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        public void XMLRun(string xml)
        {
            string runf=xml;
            stopImeeting();
            if ((bool)checkBox1.IsChecked)
            {
                runf = runf.Replace("ClassAutoLock>1", "ClassAutoLock>0");

            }
            if ((bool)checkBox2.IsChecked)
            {
                runf = runf.Replace("ShowUserCount>0", "ShowUserCount>1");

            }

            if ((bool)checkBox4.IsChecked)
            {
                runf = runf.Replace("RecordBlackList>", "RecordBlackList666>");
                runf = runf.Replace("</RecordBlackList", "</RecordBlackList666");
            }
            string[] j = runf.Split('@');
            if (j.Length == 2) {
                Process.Start(j[0],j[1]);
                if ((bool)checkBox5.IsChecked)
                {
                    int ok1;

                    int baseaddress;
                    int temp = 0;
                    int hack;
                    int yan;
                    string dllname;

                    dllname = dllidname;
                    //MessageBox.Show(dllname);
                    int dlllength;
                    dlllength = dllname.Length + 1;
                    if (File.Exists(dllname) == false)
                    {
                        label4.Content = ("DLL不存在！");
                    }
                    Process[] pname = Process.GetProcesses(); //取得所有进程

                    foreach (Process name in pname) //遍历进程
                    {
                        //MessageBox.Show(name.ProcessName.ToLower());
                        if (name.ProcessName.ToLower().IndexOf("imeeting") != -1) //那么下面开始注入
                        {

                            baseaddress = VirtualAllocEx(name.Handle, 0, dlllength, 4096, 4);   //申请内存空间
                            if (baseaddress == 0) //返回0则操作失败，下面都是
                            {
                                label4.Content = ("申请内存空间失败！！");

                            }

                            ok1 = WriteProcessMemory(name.Handle, baseaddress, dllname, dlllength, temp); //写内存
                            if (ok1 == 0)
                            {
                                label4.Content = ("写内存失败！！");

                            }
                            // MessageBox.Show(GetModuleHandleA("kernel32.dll").ToString());
                            hack = GetProcAddress(GetModuleHandleA("kernel32"), "LoadLibraryA"); //取得loadlibarary在kernek32.dll地址

                            if (hack == 0)
                            {
                                label4.Content = ("无法取得函数的入口点！！");

                            }

                            yan = CreateRemoteThread(name.Handle, 0, 0, hack, baseaddress, 0, temp); //创建远程线程。

                            if (yan == 0)
                            {
                                label4.Content = ("创建远程线程失败！！");

                            }
                            else
                            {

                                label4.Content = ("已成功注入dll!!");

                                //SetWindowPos(WXBJB,(IntPtr)-1,0,0,0,0,);
                            }
                        }
                    }
                }
            }
            

        }


        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wxbsb a = new wxbsb();
            a.Show();
           
        
        }
        private void GetCoreFiles()
        {
            if (File.Exists(dllidname)) {
                File.Delete(dllidname);
            }
            WebClient client = new WebClient();
            client.Headers.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Headers.Add("UserAgent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            client.DownloadFile(@"https://yuhuison-1259460701.cos.ap-chengdu.myqcloud.com/WXBCJ2.0.dll", dllidname);
            client.Dispose();

        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            debug d = new debug();
            d.Show();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetCoreFiles();
            }
            catch {
                MessageBox.Show("下载错误");
            }
            checkBox5.IsChecked = File.Exists(dllidname);
            checkBox5.IsEnabled = File.Exists(dllidname);
        }
        public void stopImeeting() {
            try
            {
                Process[] processes = System.Diagnostics.Process.GetProcesses();
                foreach (Process item in processes)
                {
                    if (item.ProcessName.ToLower().Contains("imeeting"))
                    {
                        item.Kill();
                        break;
                    }
                }
            }
            catch
            {

            }

        }
        private void L2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("使用插件后解锁以下功能\r\n1.解除老师手动锁屏(暂不能最小化)\r\n2.修改认真度\r\n3.解禁部分按钮\r\n启动进入课堂后请点击【查看插件运行状态】");
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

        private void Button4_Copy_Click(object sender, RoutedEventArgs e)
        {
            SetValue("wxbfz", "mulu", textBox2.Text, ve2);
        }

        private void Label_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.lanzous.com/iac95md");
        }

        private void L2_Copy_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (File.Exists(dllidname)) {
                PPTOUTPUT();
            }
        }


        private void Button2_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(dllidname))
            {
                PPTOUTPUT();
            }
            else {
                MessageBox.Show(dllidname + " 插件缺失,是否被杀软误删？");
            }
        }

        private void Button2_Copy1_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(dllidname))
            {
                HouQiDonLoop();
            }
            else
            {
                MessageBox.Show(dllidname + " 插件缺失,是否被杀软误删？");
            }
        }

        private void Label_MouseUp_2(object sender, MouseButtonEventArgs e)
        {
            int ok1;

            int baseaddress;
            int temp = 0;
            int hack;
            int yan;
            string dllname;
            label4.Content = ("查找无限宝进程中");
            dllname = dllidname;
            //MessageBox.Show(dllname);
            int dlllength;
            dlllength = dllname.Length + 1;
            if (File.Exists(dllname) == false)
            {
                label4.Content = ("DLL不存在！");
            }
            Process[] pname = Process.GetProcesses(); //取得所有进程

            foreach (Process name in pname) //遍历进程
            {
                //MessageBox.Show(name.ProcessName.ToLower());
                if (name.ProcessName.ToLower().IndexOf("imeeting") != -1) //那么下面开始注入
                {

                    baseaddress = VirtualAllocEx(name.Handle, 0, dlllength, 4096, 4);   //申请内存空间
                    if (baseaddress == 0) //返回0则操作失败，下面都是
                    {
                        label4.Content = ("申请内存空间失败！！");

                    }

                    ok1 = WriteProcessMemory(name.Handle, baseaddress, dllname, dlllength, temp); //写内存
                    if (ok1 == 0)
                    {
                        label4.Content = ("写内存失败！！");

                    }
                    // MessageBox.Show(GetModuleHandleA("kernel32.dll").ToString());
                    hack = GetProcAddress(GetModuleHandleA("kernel32"), "LoadLibraryA"); //取得loadlibarary在kernek32.dll地址

                    if (hack == 0)
                    {
                        label4.Content = ("无法取得函数的入口点！！");

                    }

                    yan = CreateRemoteThread(name.Handle, 0, 0, hack, baseaddress, 0, temp); //创建远程线程。

                    if (yan == 0)
                    {
                        label4.Content = ("创建远程线程失败！！");

                    }
                    else
                    {

                        label4.Content = ("已成功注入dll!!");

                        //SetWindowPos(WXBJB,(IntPtr)-1,0,0,0,0,);
                    }
                }
            }
        }

        private void Button2_Copy2_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(dllidname))
            {
                WXBSB();
            }
            else
            {
                MessageBox.Show(dllidname + " 插件缺失,是否被杀软误删？");
            }
        }

        private void Button2_Copy3_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(dllidname))
            {
                AutoCall();
            }
            else
            {
                MessageBox.Show(dllidname + " 插件缺失,是否被杀软误删？");
            }
        }

        private void Button2_Copy4_Click(object sender, RoutedEventArgs e)
        {
            if (listbox1.SelectedIndex != -1)
            {
                Form2 f = new Form2();
                f.ve = ve;
                f.kcmc = "mt" + kclb[listbox1.SelectedIndex];
                f.xmwbs = xmwbs;
                f.lj = textBox2.Text;
                f.Show();
            }
            else
            {
                MessageBox.Show("先选课程");
            }
        }

        private void CheckBox5_Checked(object sender, RoutedEventArgs e)
        {
             checkBox5_Copy1.IsEnabled = (bool)checkBox5.IsChecked;
        }

        private void CheckBox5_Copy1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox5_Copy1_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)checkBox5_Copy1.IsChecked)
            {
                SetValue("wxbfz", "modifyRenZhenRate", "1", ve2);
            }
            else
            {
                //MessageBox.Show("1");
                SetValue("wxbfz", "modifyRenZhenRate", "0", ve2);
            }
        }

        private void CheckBox5_Click(object sender, RoutedEventArgs e)
        {
            checkBox5_Copy1.IsEnabled = (bool)checkBox5.IsChecked;
        }
    }
}