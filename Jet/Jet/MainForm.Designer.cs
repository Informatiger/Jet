namespace Jet
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lvMessages = new System.Windows.Forms.ListView();
            this.colHeadUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSendMessage = new MetroFramework.Controls.MetroButton();
            this.btnSendImage = new MetroFramework.Controls.MetroButton();
            this.cbPorts = new MetroFramework.Controls.MetroComboBox();
            this.btnStartServer = new MetroFramework.Controls.MetroButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbEmoji = new MetroFramework.Controls.MetroComboBox();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tbFriedIP = new Jet.TextBoxWithPlaceHolder();
            this.tbLocalIP = new Jet.TextBoxWithPlaceHolder();
            this.tbMessage = new Jet.TextBoxWithPlaceHolder();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // lvMessages
            // 
            this.lvMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeadUsername,
            this.colHeadMessage,
            this.colHeadTime});
            this.lvMessages.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lvMessages.FullRowSelect = true;
            this.lvMessages.GridLines = true;
            this.lvMessages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvMessages.Location = new System.Drawing.Point(20, 122);
            this.lvMessages.Margin = new System.Windows.Forms.Padding(4);
            this.lvMessages.MultiSelect = false;
            this.lvMessages.Name = "lvMessages";
            this.lvMessages.Size = new System.Drawing.Size(552, 230);
            this.lvMessages.TabIndex = 1;
            this.lvMessages.UseCompatibleStateImageBehavior = false;
            this.lvMessages.View = System.Windows.Forms.View.Details;
            this.lvMessages.ItemActivate += new System.EventHandler(this.lvMessages_ItemActivate);
            // 
            // colHeadUsername
            // 
            this.colHeadUsername.Text = "Username";
            this.colHeadUsername.Width = 107;
            // 
            // colHeadMessage
            // 
            this.colHeadMessage.Text = "Message";
            this.colHeadMessage.Width = 335;
            // 
            // colHeadTime
            // 
            this.colHeadTime.Text = "Time";
            this.colHeadTime.Width = 80;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMessage.Location = new System.Drawing.Point(477, 360);
            this.btnSendMessage.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(96, 32);
            this.btnSendMessage.TabIndex = 5;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseSelectable = true;
            this.btnSendMessage.UseStyleColors = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnSendImage
            // 
            this.btnSendImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendImage.Enabled = false;
            this.btnSendImage.Location = new System.Drawing.Point(245, 323);
            this.btnSendImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendImage.Name = "btnSendImage";
            this.btnSendImage.Size = new System.Drawing.Size(96, 32);
            this.btnSendImage.TabIndex = 6;
            this.btnSendImage.Text = "Image";
            this.btnSendImage.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnSendImage.UseSelectable = true;
            this.btnSendImage.Visible = false;
            this.btnSendImage.Click += new System.EventHandler(this.btnSendImage_Click);
            // 
            // cbPorts
            // 
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.ItemHeight = 23;
            this.cbPorts.Items.AddRange(new object[] {
            "37337",
            "7337"});
            this.cbPorts.Location = new System.Drawing.Point(20, 55);
            this.cbPorts.Margin = new System.Windows.Forms.Padding(4);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(268, 29);
            this.cbPorts.TabIndex = 7;
            this.cbPorts.UseSelectable = true;
            this.cbPorts.UseStyleColors = true;
            // 
            // btnStartServer
            // 
            this.btnStartServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartServer.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnStartServer.Location = new System.Drawing.Point(296, 55);
            this.btnStartServer.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(276, 29);
            this.btnStartServer.TabIndex = 8;
            this.btnStartServer.Text = "Start Local Server";
            this.btnStartServer.UseSelectable = true;
            this.btnStartServer.UseStyleColors = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipTitle = "New message arrived";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Jet";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 26);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // cbEmoji
            // 
            this.cbEmoji.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbEmoji.Enabled = false;
            this.cbEmoji.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmoji.FormattingEnabled = true;
            this.cbEmoji.ItemHeight = 23;
            this.cbEmoji.Items.AddRange(new object[] {
            "",
            "🤣",
            "☺",
            "🙂",
            "🙃",
            "🤡",
            "🤠",
            "🙁",
            "☹",
            "😣",
            "😫",
            "😩",
            "😤",
            "😠",
            "😡",
            "😶",
            "😯",
            "😦",
            "😧",
            "😮",
            "😲",
            "😵",
            "😳",
            "😱",
            "😨",
            "😰",
            "😢",
            "😥",
            "🤤",
            "😭",
            "😪",
            "😴",
            "🙄",
            "😪",
            "😴",
            "🙄",
            "🤥",
            "😬",
            "🤢",
            "🤧",
            "😷",
            "👿",
            "👹",
            "👺",
            "💩",
            "👻",
            "💀",
            "☠",
            "👽",
            "👾",
            "🎃",
            "😺",
            "😸",
            "😹",
            "😻",
            "😼",
            "😽",
            "🙀",
            "😿",
            "😾",
            "👐",
            "🙌",
            "👏",
            "🙏",
            "👍",
            "👎",
            "👊",
            "👌",
            "👈",
            "👉",
            "👆",
            "👇",
            "🖖",
            "👋",
            "💪",
            "🖕"});
            this.cbEmoji.Location = new System.Drawing.Point(20, 360);
            this.cbEmoji.Margin = new System.Windows.Forms.Padding(4);
            this.cbEmoji.Name = "cbEmoji";
            this.cbEmoji.Size = new System.Drawing.Size(71, 29);
            this.cbEmoji.TabIndex = 10;
            this.cbEmoji.UseSelectable = true;
            this.cbEmoji.UseStyleColors = true;
            this.cbEmoji.SelectedIndexChanged += new System.EventHandler(this.cbEmoji_SelectedIndexChanged);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // tbFriedIP
            // 
            this.tbFriedIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbFriedIP.CustomButton.Image = null;
            this.tbFriedIP.CustomButton.Location = new System.Drawing.Point(256, 2);
            this.tbFriedIP.CustomButton.Name = "";
            this.tbFriedIP.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.tbFriedIP.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbFriedIP.CustomButton.TabIndex = 1;
            this.tbFriedIP.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbFriedIP.CustomButton.UseSelectable = true;
            this.tbFriedIP.CustomButton.Visible = false;
            this.tbFriedIP.Lines = new string[0];
            this.tbFriedIP.Location = new System.Drawing.Point(296, 92);
            this.tbFriedIP.Margin = new System.Windows.Forms.Padding(4);
            this.tbFriedIP.MaxLength = 32767;
            this.tbFriedIP.Name = "tbFriedIP";
            this.tbFriedIP.PasswordChar = '\0';
            this.tbFriedIP.PlaceHolderText = "Friends IP";
            this.tbFriedIP.ReadOnly = true;
            this.tbFriedIP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbFriedIP.SelectedText = "";
            this.tbFriedIP.SelectionLength = 0;
            this.tbFriedIP.SelectionStart = 0;
            this.tbFriedIP.ShortcutsEnabled = true;
            this.tbFriedIP.Size = new System.Drawing.Size(276, 22);
            this.tbFriedIP.TabIndex = 4;
            this.tbFriedIP.UseSelectable = true;
            this.tbFriedIP.UseStyleColors = true;
            this.tbFriedIP.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbFriedIP.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbFriedIP.Enter += new System.EventHandler(this.tbRemoteIP_Enter);
            this.tbFriedIP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFriedIP_KeyDown);
            this.tbFriedIP.Leave += new System.EventHandler(this.tbRemoteIP_Leave);
            // 
            // tbLocalIP
            // 
            // 
            // 
            // 
            this.tbLocalIP.CustomButton.Image = null;
            this.tbLocalIP.CustomButton.Location = new System.Drawing.Point(248, 2);
            this.tbLocalIP.CustomButton.Name = "";
            this.tbLocalIP.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.tbLocalIP.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbLocalIP.CustomButton.TabIndex = 1;
            this.tbLocalIP.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLocalIP.CustomButton.UseSelectable = true;
            this.tbLocalIP.CustomButton.Visible = false;
            this.tbLocalIP.Lines = new string[0];
            this.tbLocalIP.Location = new System.Drawing.Point(20, 92);
            this.tbLocalIP.Margin = new System.Windows.Forms.Padding(4);
            this.tbLocalIP.MaxLength = 32767;
            this.tbLocalIP.Name = "tbLocalIP";
            this.tbLocalIP.PasswordChar = '\0';
            this.tbLocalIP.PlaceHolderText = "Your IP";
            this.tbLocalIP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbLocalIP.SelectedText = "";
            this.tbLocalIP.SelectionLength = 0;
            this.tbLocalIP.SelectionStart = 0;
            this.tbLocalIP.ShortcutsEnabled = true;
            this.tbLocalIP.Size = new System.Drawing.Size(268, 22);
            this.tbLocalIP.TabIndex = 2;
            this.tbLocalIP.UseSelectable = true;
            this.tbLocalIP.UseStyleColors = true;
            this.tbLocalIP.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbLocalIP.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbLocalIP.Enter += new System.EventHandler(this.tbLocalIP_Enter);
            this.tbLocalIP.Leave += new System.EventHandler(this.tbLocalIP_Leave);
            // 
            // tbMessage
            // 
            this.tbMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            // 
            // 
            // 
            this.tbMessage.CustomButton.Image = null;
            this.tbMessage.CustomButton.Location = new System.Drawing.Point(346, 2);
            this.tbMessage.CustomButton.Name = "";
            this.tbMessage.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbMessage.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbMessage.CustomButton.TabIndex = 1;
            this.tbMessage.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbMessage.CustomButton.UseSelectable = true;
            this.tbMessage.CustomButton.Visible = false;
            this.tbMessage.Enabled = false;
            this.tbMessage.Lines = new string[0];
            this.tbMessage.Location = new System.Drawing.Point(99, 363);
            this.tbMessage.Margin = new System.Windows.Forms.Padding(4);
            this.tbMessage.MaxLength = 32767;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.PasswordChar = '\0';
            this.tbMessage.PlaceHolderText = "Enter to Send";
            this.tbMessage.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbMessage.SelectedText = "";
            this.tbMessage.SelectionLength = 0;
            this.tbMessage.SelectionStart = 0;
            this.tbMessage.ShortcutsEnabled = true;
            this.tbMessage.Size = new System.Drawing.Size(370, 26);
            this.tbMessage.TabIndex = 0;
            this.tbMessage.UseSelectable = true;
            this.tbMessage.UseStyleColors = true;
            this.tbMessage.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbMessage.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbMessage.Enter += new System.EventHandler(this.tbMessage_Enter);
            this.tbMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMessage_KeyDown);
            this.tbMessage.Leave += new System.EventHandler(this.tbMessage_Leave);
            // 
            // MainForm
            // 
            this.ApplyImageInvert = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = ((System.Drawing.Image)(resources.GetObject("$this.BackImage")));
            this.BackImagePadding = new System.Windows.Forms.Padding(5);
            this.BackLocation = MetroFramework.Forms.BackLocation.TopRight;
            this.ClientSize = new System.Drawing.Size(597, 404);
            this.Controls.Add(this.cbEmoji);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.cbPorts);
            this.Controls.Add(this.btnSendImage);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.tbFriedIP);
            this.Controls.Add(this.tbLocalIP);
            this.Controls.Add(this.lvMessages);
            this.Controls.Add(this.tbMessage);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(597, 404);
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "Jet";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBoxWithPlaceHolder tbMessage;
        private System.Windows.Forms.ListView lvMessages;
        private TextBoxWithPlaceHolder tbLocalIP;
        private System.Windows.Forms.ColumnHeader colHeadUsername;
        private System.Windows.Forms.ColumnHeader colHeadMessage;
        private System.Windows.Forms.ColumnHeader colHeadTime;
        private TextBoxWithPlaceHolder tbFriedIP;
        private MetroFramework.Controls.MetroButton btnSendMessage;
        private MetroFramework.Controls.MetroButton btnSendImage;
        private MetroFramework.Controls.MetroComboBox cbPorts;
        private MetroFramework.Controls.MetroButton btnStartServer;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private MetroFramework.Controls.MetroComboBox cbEmoji;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
    }
}

