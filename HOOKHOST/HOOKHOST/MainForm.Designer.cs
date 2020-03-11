/*
 * Created by SharpDevelop.
 * User: Sang
 * Date: 2020/3/11 星期三
 * Time: 11:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace HOOKHOST
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
        	this.listBox1 = new System.Windows.Forms.ListBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.checkBox1 = new System.Windows.Forms.CheckBox();
        	this.checkBox2 = new System.Windows.Forms.CheckBox();
        	this.checkBox3 = new System.Windows.Forms.CheckBox();
        	this.checkBox4 = new System.Windows.Forms.CheckBox();
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	this.button1 = new System.Windows.Forms.Button();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.textBox2 = new System.Windows.Forms.TextBox();
        	this.pictureBox1 = new System.Windows.Forms.PictureBox();
        	this.linkLabel1 = new System.Windows.Forms.LinkLabel();
        	this.button2 = new System.Windows.Forms.Button();
        	this.button3 = new System.Windows.Forms.Button();
        	this.checkBox5 = new System.Windows.Forms.CheckBox();
        	this.label4 = new System.Windows.Forms.Label();
        	this.label5 = new System.Windows.Forms.Label();
        	this.button4 = new System.Windows.Forms.Button();
        	this.button5 = new System.Windows.Forms.Button();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// listBox1
        	// 
        	this.listBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.listBox1.FormattingEnabled = true;
        	this.listBox1.ItemHeight = 21;
        	this.listBox1.Location = new System.Drawing.Point(9, 204);
        	this.listBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        	this.listBox1.Name = "listBox1";
        	this.listBox1.Size = new System.Drawing.Size(242, 256);
        	this.listBox1.TabIndex = 0;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label1.Location = new System.Drawing.Point(5, 179);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(69, 20);
        	this.label1.TabIndex = 2;
        	this.label1.Text = "课程列表";
        	// 
        	// checkBox1
        	// 
        	this.checkBox1.AutoSize = true;
        	this.checkBox1.Checked = true;
        	this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.checkBox1.Location = new System.Drawing.Point(267, 254);
        	this.checkBox1.Name = "checkBox1";
        	this.checkBox1.Size = new System.Drawing.Size(84, 24);
        	this.checkBox1.TabIndex = 3;
        	this.checkBox1.Text = "解除锁屏";
        	this.checkBox1.UseVisualStyleBackColor = true;
        	// 
        	// checkBox2
        	// 
        	this.checkBox2.AutoSize = true;
        	this.checkBox2.Checked = true;
        	this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.checkBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.checkBox2.Location = new System.Drawing.Point(357, 254);
        	this.checkBox2.Name = "checkBox2";
        	this.checkBox2.Size = new System.Drawing.Size(112, 24);
        	this.checkBox2.TabIndex = 4;
        	this.checkBox2.Text = "显示在线人数";
        	this.checkBox2.UseVisualStyleBackColor = true;
        	// 
        	// checkBox3
        	// 
        	this.checkBox3.AutoSize = true;
        	this.checkBox3.Checked = true;
        	this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.checkBox3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.checkBox3.Location = new System.Drawing.Point(467, 254);
        	this.checkBox3.Name = "checkBox3";
        	this.checkBox3.Size = new System.Drawing.Size(154, 24);
        	this.checkBox3.TabIndex = 5;
        	this.checkBox3.Text = "解除聊天屏蔽字限制";
        	this.checkBox3.UseVisualStyleBackColor = true;
        	// 
        	// checkBox4
        	// 
        	this.checkBox4.AutoSize = true;
        	this.checkBox4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.checkBox4.Location = new System.Drawing.Point(267, 284);
        	this.checkBox4.Name = "checkBox4";
        	this.checkBox4.Size = new System.Drawing.Size(84, 24);
        	this.checkBox4.TabIndex = 6;
        	this.checkBox4.Text = "修改昵称";
        	this.checkBox4.UseVisualStyleBackColor = true;
        	// 
        	// textBox1
        	// 
        	this.textBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.textBox1.Location = new System.Drawing.Point(357, 284);
        	this.textBox1.Name = "textBox1";
        	this.textBox1.Size = new System.Drawing.Size(116, 26);
        	this.textBox1.TabIndex = 7;
        	this.textBox1.Text = "不修改";
        	// 
        	// button1
        	// 
        	this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.button1.Location = new System.Drawing.Point(267, 430);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(94, 34);
        	this.button1.TabIndex = 8;
        	this.button1.Text = "启动";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.Button1_Click);
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label2.Location = new System.Drawing.Point(263, 179);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(114, 20);
        	this.label2.TabIndex = 9;
        	this.label2.Text = "当前已登陆账号";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label3.Location = new System.Drawing.Point(263, 199);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(184, 20);
        	this.label3.TabIndex = 10;
        	this.label3.Text = "无限宝iMeeting.exe路径:";
        	// 
        	// textBox2
        	// 
        	this.textBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.textBox2.Location = new System.Drawing.Point(267, 222);
        	this.textBox2.Name = "textBox2";
        	this.textBox2.Size = new System.Drawing.Size(313, 26);
        	this.textBox2.TabIndex = 11;
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.Image = global::HOOKHOST.Resources.ed92db305ae43c7fc8a59b1789934caa2636b876;
        	this.pictureBox1.Location = new System.Drawing.Point(0, 0);
        	this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(674, 176);
        	this.pictureBox1.TabIndex = 1;
        	this.pictureBox1.TabStop = false;
        	// 
        	// linkLabel1
        	// 
        	this.linkLabel1.AutoSize = true;
        	this.linkLabel1.Location = new System.Drawing.Point(367, 447);
        	this.linkLabel1.Name = "linkLabel1";
        	this.linkLabel1.Size = new System.Drawing.Size(92, 17);
        	this.linkLabel1.TabIndex = 12;
        	this.linkLabel1.TabStop = true;
        	this.linkLabel1.Text = "以调试模式启动";
        	this.linkLabel1.Visible = false;
        	this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
        	// 
        	// button2
        	// 
        	this.button2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.button2.Location = new System.Drawing.Point(586, 216);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(58, 32);
        	this.button2.TabIndex = 13;
        	this.button2.Text = "保存";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.Button2_Click_1);
        	// 
        	// button3
        	// 
        	this.button3.Location = new System.Drawing.Point(80, 177);
        	this.button3.Name = "button3";
        	this.button3.Size = new System.Drawing.Size(171, 26);
        	this.button3.TabIndex = 14;
        	this.button3.Text = "刷新当前课程";
        	this.button3.UseVisualStyleBackColor = true;
        	this.button3.Visible = false;
        	this.button3.Click += new System.EventHandler(this.Button3_Click);
        	// 
        	// checkBox5
        	// 
        	this.checkBox5.AutoSize = true;
        	this.checkBox5.Enabled = false;
        	this.checkBox5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.checkBox5.Location = new System.Drawing.Point(267, 314);
        	this.checkBox5.Name = "checkBox5";
        	this.checkBox5.Size = new System.Drawing.Size(273, 24);
        	this.checkBox5.TabIndex = 15;
        	this.checkBox5.Text = "启用强力无比的DLL插件(需要额外下载)";
        	this.checkBox5.UseVisualStyleBackColor = true;
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(264, 341);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(368, 85);
        	this.label4.TabIndex = 16;
        	this.label4.Text = "使用插件获得以下功能\r\n·1.时刻保持“认真” \r\n关于该功能 : 启动之后，要先假装1分钟左右的认真，之后程序自动\r\n锁定认真，如果不这样做，老师统计那里会显示" +
	"你【当前】不认真，\r\n但是不认真时长并不会增加，认真度也不会下降";
        	// 
        	// label5
        	// 
        	this.label5.AutoSize = true;
        	this.label5.Location = new System.Drawing.Point(374, 358);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(234, 17);
        	this.label5.TabIndex = 17;
        	this.label5.Text = "2.解禁部分按钮 (可 看见聊天框旁边的送礼";
        	this.label5.Click += new System.EventHandler(this.Label5_Click);
        	// 
        	// button4
        	// 
        	this.button4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.button4.Location = new System.Drawing.Point(563, 314);
        	this.button4.Name = "button4";
        	this.button4.Size = new System.Drawing.Size(58, 32);
        	this.button4.TabIndex = 18;
        	this.button4.Text = "下载";
        	this.button4.UseVisualStyleBackColor = true;
        	this.button4.Click += new System.EventHandler(this.Button4_Click);
        	// 
        	// button5
        	// 
        	this.button5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.button5.Location = new System.Drawing.Point(467, 430);
        	this.button5.Name = "button5";
        	this.button5.Size = new System.Drawing.Size(177, 34);
        	this.button5.TabIndex = 19;
        	this.button5.Text = "载入插件窗口(需先启动)";
        	this.button5.UseVisualStyleBackColor = true;
        	this.button5.Visible = false;
        	this.button5.Click += new System.EventHandler(this.Button5_Click);
        	// 
        	// MainForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.SystemColors.ControlLightLight;
        	this.ClientSize = new System.Drawing.Size(656, 473);
        	this.Controls.Add(this.button5);
        	this.Controls.Add(this.button4);
        	this.Controls.Add(this.label5);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.checkBox5);
        	this.Controls.Add(this.button3);
        	this.Controls.Add(this.button2);
        	this.Controls.Add(this.linkLabel1);
        	this.Controls.Add(this.textBox2);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.textBox1);
        	this.Controls.Add(this.checkBox4);
        	this.Controls.Add(this.checkBox3);
        	this.Controls.Add(this.checkBox2);
        	this.Controls.Add(this.checkBox1);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.pictureBox1);
        	this.Controls.Add(this.listBox1);
        	this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        	this.MaximumSize = new System.Drawing.Size(672, 512);
        	this.MinimumSize = new System.Drawing.Size(672, 512);
        	this.Name = "MainForm";
        	this.ShowIcon = false;
        	this.Text = "无限宝第三方登陆工具 BiliBili 秋小十";
        	this.Load += new System.EventHandler(this.Form1_Load);
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
        

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

