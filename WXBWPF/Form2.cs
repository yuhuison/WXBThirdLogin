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
namespace WXBWPF
{
    public partial class Form2 : Form
    {
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader valve;
        private System.Windows.Forms.ColumnHeader zs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
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

                xmz.Add(Window1.GetValue(kcmc, xm, "", ve));
                lvi.SubItems.Add(Window1.GetValue(kcmc, xm, "", ve));
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



        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valve = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.zs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.valve,
            this.zs});
            this.listView1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.HideSelection = false;
            this.listView1.LabelEdit = true;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(5, 9);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(783, 389);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // name
            // 
            this.name.Text = "项目名";
            this.name.Width = 140;
            // 
            // valve
            // 
            this.valve.Text = "项目的值";
            this.valve.Width = 520;
            // 
            // zs
            // 
            this.zs.Text = "注释";
            this.zs.Width = 40;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(606, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 34);
            this.button1.TabIndex = 9;
            this.button1.Text = "启动";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(5, 409);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(489, 26);
            this.textBox1.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(500, 406);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 34);
            this.button2.TabIndex = 11;
            this.button2.Text = "修改";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(600, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 12;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Name = "Form2";
            this.Text = "高级模式";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form2_Load_2(object sender, EventArgs e)
        {

        }
    }
}
