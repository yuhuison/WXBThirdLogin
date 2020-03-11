using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections; 
namespace HOOKHOST
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string[] xmwbs;
        public string ve;
        public string kcmc;
        public ArrayList xmz = new ArrayList();
        public string lj;
        private void Form2_Load(object sender, EventArgs e)
        {
            listView1.BeginUpdate();
            this.listView1.View = System.Windows.Forms.View.Details;
            foreach (string xm in xmwbs) {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = xm;

                xmz.Add(MainForm.GetValue(kcmc, xm, "", ve));
                lvi.SubItems.Add(MainForm.GetValue(kcmc, xm, "", ve));
                lvi.SubItems.Add("无");
                listView1.Items.Add(lvi);
            }
            listView1.EndUpdate();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string s = listView1.SelectedItems[0].Text;
                int i = 0;
                while (i < xmz.Count)
                {
                    if (xmwbs[i] == s)
                    {
                        textBox1.Text = (string)xmz[i];
                    }
                    i++;
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string s = listView1.SelectedItems[0].Text;
                int i = 0;
                while (i < xmz.Count)
                {
                    if (xmwbs[i] == s)
                    {
                        xmz[i] = textBox1.Text ;

                        listView1.Items[i].SubItems[1].Text = textBox1.Text;
                        listView1.Items[i].SubItems[0].Font=label1.Font;
                        break;
                    }
                    i++;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string str = "94AEB546-26AE-48da-AC3A-B15BF1245699";
                string xml = "";
            int i = 0;
                foreach (string l in xmwbs)
                {
                    string m = (string)xmz[i];
                    xml = xml + "<" + str + l + ">" + m + "</" + str + ">";
                i++;
                }
                System.Diagnostics.Process.Start(lj, xml);

        }
    }
}
