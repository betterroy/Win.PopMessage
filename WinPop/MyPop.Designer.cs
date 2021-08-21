
namespace WinPop
{
    partial class MyPop
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPop));
            this.MyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.panelFather = new System.Windows.Forms.Panel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btn_send = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btn_break = new System.Windows.Forms.Button();
            this.btn_link = new System.Windows.Forms.Button();
            this.panelTxt = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.MyMenu.SuspendLayout();
            this.panelFather.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.panelTxt.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyIcon
            // 
            this.MyIcon.ContextMenuStrip = this.MyMenu;
            this.MyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MyIcon.Icon")));
            this.MyIcon.Text = "报警工具";
            this.MyIcon.Visible = true;
            this.MyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.alermIcon_MouseClick);
            // 
            // MyMenu
            // 
            this.MyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Exit});
            this.MyMenu.Name = "MyMenu";
            this.MyMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(100, 22);
            this.Exit.Text = "退出";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // panelFather
            // 
            this.panelFather.Controls.Add(this.panelButton);
            this.panelFather.Controls.Add(this.panelTxt);
            this.panelFather.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFather.Location = new System.Drawing.Point(0, 0);
            this.panelFather.Name = "panelFather";
            this.panelFather.Size = new System.Drawing.Size(800, 450);
            this.panelFather.TabIndex = 2;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btn_send);
            this.panelButton.Controls.Add(this.txtSend);
            this.panelButton.Controls.Add(this.btn_break);
            this.panelButton.Controls.Add(this.btn_link);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 350);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(800, 100);
            this.panelButton.TabIndex = 4;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(616, 33);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(91, 40);
            this.btn_send.TabIndex = 5;
            this.btn_send.Text = "发送";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txtSend
            // 
            this.txtSend.Font = new System.Drawing.Font("宋体", 12F);
            this.txtSend.Location = new System.Drawing.Point(367, 40);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(243, 26);
            this.txtSend.TabIndex = 4;
            this.txtSend.Text = "ECHO kerry 123456 ";
            // 
            // btn_break
            // 
            this.btn_break.Location = new System.Drawing.Point(232, 33);
            this.btn_break.Name = "btn_break";
            this.btn_break.Size = new System.Drawing.Size(91, 40);
            this.btn_break.TabIndex = 3;
            this.btn_break.Text = "断开";
            this.btn_break.UseVisualStyleBackColor = true;
            this.btn_break.Click += new System.EventHandler(this.btn_break_Click);
            // 
            // btn_link
            // 
            this.btn_link.Location = new System.Drawing.Point(103, 33);
            this.btn_link.Name = "btn_link";
            this.btn_link.Size = new System.Drawing.Size(91, 40);
            this.btn_link.TabIndex = 2;
            this.btn_link.Text = "连接";
            this.btn_link.UseVisualStyleBackColor = true;
            this.btn_link.Click += new System.EventHandler(this.btn_link_Click);
            // 
            // panelTxt
            // 
            this.panelTxt.Controls.Add(this.txtMessage);
            this.panelTxt.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTxt.Location = new System.Drawing.Point(0, 0);
            this.panelTxt.Name = "panelTxt";
            this.panelTxt.Size = new System.Drawing.Size(800, 344);
            this.panelTxt.TabIndex = 3;
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(0, 0);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(800, 344);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.Text = "";
            // 
            // MyPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelFather);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MyPop";
            this.Text = "信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.MyMenu.ResumeLayout(false);
            this.panelFather.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            this.panelTxt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon MyIcon;
        private System.Windows.Forms.ContextMenuStrip MyMenu;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.Panel panelFather;
        private System.Windows.Forms.Panel panelTxt;
        private System.Windows.Forms.Button btn_link;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button btn_break;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.RichTextBox txtMessage;
    }
}

