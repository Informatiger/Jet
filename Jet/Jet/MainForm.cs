using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Jet
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        Socket socket;
        IPEndPoint epLocal;
        IPEndPoint epRemote;
        int remotePort = 0;

        StringBuilder messageBuilder = new StringBuilder();

        public bool ReallyClose { get; set; }

        public bool AllowSendMessage { get; set; }

        public MainForm(String[] args)
        {
            InitializeComponent();

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            tbMessage.Text = tbMessage.PlaceHolderText;
            tbLocalIP.Text = NetStuff.GetLocalIPAddress().ToString();
            tbFriedIP.Text = tbFriedIP.PlaceHolderText;
            ReallyClose = false;
        }

        private void tbLocalIP_Enter(object sender, EventArgs e)
        {
            if (tbLocalIP.Text == tbLocalIP.PlaceHolderText)
                tbLocalIP.Text = string.Empty;
        }

        private void tbLocalIP_Leave(object sender, EventArgs e)
        {
            if (tbLocalIP.Text == string.Empty)
                tbLocalIP.Text = tbLocalIP.PlaceHolderText;
        }

        private void tbRemoteIP_Enter(object sender, EventArgs e)
        {
            if (tbFriedIP.Text == tbFriedIP.PlaceHolderText)
                tbFriedIP.Text = string.Empty;
        }

        private void tbRemoteIP_Leave(object sender, EventArgs e)
        {
            if (tbFriedIP.Text == string.Empty)
                tbFriedIP.Text = tbFriedIP.PlaceHolderText;
        }

        private void tbMessage_Enter(object sender, EventArgs e)
        {
            if (tbMessage.Text == tbMessage.PlaceHolderText)
                tbMessage.Text = string.Empty;
        }

        private void tbMessage_Leave(object sender, EventArgs e)
        {
            if (tbMessage.Text == string.Empty)
                tbMessage.Text = tbMessage.PlaceHolderText;
        }

        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (var msg in tbMessage.Text.Split('\n'))
                {
                    messageBuilder.AppendLine(msg);
                }

                if (AllowSendMessage && (!String.IsNullOrEmpty(tbMessage.Text)))
                {
                    SendTextMessage(messageBuilder.ToString());
                    messageBuilder.Clear();
                }
            }
        }

        private void tbFriedIP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StartListening();
                tbMessage.Enabled = true;
                btnSendImage.Enabled = true;
                comboBox2.Enabled = true;
                tbFriedIP.Enabled = false;
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (AllowSendMessage && (!String.IsNullOrEmpty(tbMessage.Text)))
                SendTextMessage(tbMessage.Text);

        }
        private void btnSendImage_Click(object sender, EventArgs e)
        {
            var fileOpenDialog = new OpenFileDialog();
            fileOpenDialog.ShowDialog();

            if (String.IsNullOrEmpty(fileOpenDialog.FileName))
                return;

            if (System.IO.File.Exists(fileOpenDialog.FileName))
            {
                var fileContent = System.IO.File.ReadAllBytes(fileOpenDialog.FileName);
                var fileContentAsBase64 = Convert.ToBase64String(fileContent);

                SendTextMessage("IMAGE:" + fileContentAsBase64);
            }

        }

        private void SendTextMessage(String message)
        {
            if (String.IsNullOrEmpty(message))
                return;

            try
            {
                UnicodeEncoding eEncoding = new UnicodeEncoding();
                byte[] msg = new Byte[4096 * 4];

                msg = eEncoding.GetBytes(message);
                socket.Send(msg);

                var stringArray = new String[3];
                stringArray[0] = "You";
                stringArray[1] = ReplaceNonPrintableCharacters(message);
                stringArray[2] = DateTime.Now.ToShortTimeString();

                var item = new ListViewItem(stringArray);
                if (IsUrlValid(message))
                {
                    item.Tag = "URL";
                }
                else
                    item.Tag = "TEXT";
                AddItem(item);

                tbMessage.Text = String.Empty;
                tbMessage.Focus();
            }
            catch (Exception ex)
            {
                SetStatus(ex.ToString());
            }
        }

        private void StartListening()
        {
            try
            {
                epRemote = new IPEndPoint(IPAddress.Parse(tbFriedIP.Text), remotePort);
                socket.Connect(epRemote);
                EndPoint remote = epRemote;

                var buffer = new Byte[4096 * 4];
                socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref remote, new
                    AsyncCallback(MessageCallBack), buffer);

                AllowSendMessage = true;
                tbMessage.Focus();
            }
            catch (Exception ex)
            {
                SetStatus(ex.ToString());
            }
        }

        private void MessageCallBack(IAsyncResult ar)
        {
            try
            {
                EndPoint remote = epRemote;
                int size = socket.EndReceiveFrom(ar, ref remote);

                byte[] receivedData = new Byte[4096 * 4];
                receivedData = (byte[])ar.AsyncState;

                var eEncoding = new UnicodeEncoding();
                var receivedMessage = eEncoding.GetString(receivedData);

                //if (receivedMessage.StartsWith("IMAGE:"))
                //{
                //    var stringArray = new String[3];
                //    stringArray[0] = "Friend";
                //    stringArray[1] = "Double Click Me to Open";
                //    stringArray[2] = DateTime.Now.ToShortTimeString();

                //    var item = new ListViewItem(stringArray);
                //    item.Tag = receivedMessage;
                //    lvMessages.Items.Add(item);
                //}
                //else
                if (1==1)
                {
                    var stringArray = new String[3];
                    stringArray[0] = "Friend";
                    stringArray[1] = ReplaceNonPrintableCharacters(receivedMessage);
                    stringArray[2] = DateTime.Now.ToShortTimeString();

                    var item = new ListViewItem(stringArray);
                    if (IsUrlValid(receivedMessage))
                    {
                        item.Tag = "URL";
                    }
                    else
                        item.Tag = "TEXT";
                    AddItem(item);
                    if (WindowState == FormWindowState.Minimized)
                        Notify(receivedMessage);
                }

                var buffer = new Byte[1500];
                socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref remote,
                    new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception ex)
            {
                SetStatus(ex.ToString());
            }
        }

        public void SetStatus(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(SetStatus), new object[] { value });
                return;
            }
            MetroFramework.MetroMessageBox.Show(this, value);
        }

        public void Notify(String message)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<String>(NotifyMessage), new object[] { message });
                return;
            }
            NotifyMessage(message);
        }

        public void NotifyMessage(String message)
        {
            notifyIcon1.BalloonTipText = message;
            notifyIcon1.ShowBalloonTip(5000);
        }

        public void AddItem(ListViewItem itm)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<ListViewItem>(AddItem), new object[] { itm });
                return;
            }
            lvMessages.Items.Add(itm);

            var x = lvMessages.Items.Count - 1;
            lvMessages.EnsureVisible(x);
        }

        private bool IsUrlValid(string url)
        {

            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }

        string ReplaceNonPrintableCharacters(string s)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                byte b = (byte)c;
                if (b >= 32)
                    result.Append(c);
            }
            return result.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var port = 0;

            int.TryParse(comboBox1.SelectedItem.ToString(), out port);

            if (port == 7337)
                remotePort = 37337;
            else if (port == 37337)
                remotePort = 7337;

            MetroFramework.MetroMessageBox.Show(this, "Server started!\nPort: " + port + "\nRemotePort: " + remotePort);

            epLocal = new IPEndPoint(IPAddress.Parse(tbLocalIP.Text), port);
            socket.Bind(epLocal);
            comboBox1.Enabled = false;
            btnStartServer.Enabled = false;
            tbLocalIP.ReadOnly = true;
        }

        private void lvMessages_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                if (lvMessages.SelectedItems[0].Tag.Equals("URL"))
                {
                    var url = lvMessages.SelectedItems[0].SubItems[1].Text;

                    if (MessageBox.Show("Open " + url + "?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        Process.Start(url);
                }
                else if (lvMessages.SelectedItems[0].Tag.Equals("TEXT"))
                {
                    var tView = new MessageView(lvMessages.SelectedItems[0].SubItems[1].Text);
                    tView.Show();
                }
            }
            catch (Exception ex)
            {
                SetStatus(ex.ToString());
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ReallyClose)
            {
                WindowState = FormWindowState.Minimized;
                Hide();
                e.Cancel = true;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReallyClose = true;
            Close();
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex > 0)
            {
                if (tbMessage.Text == tbMessage.PlaceHolderText)
                    tbMessage.Text = String.Empty;
                tbMessage.Text += comboBox2.SelectedItem.ToString();
            }
        }

        private void lvMessages_ItemAdded(MetroFramework.Controls.MetroListView obj)
        {
            var x = lvMessages.Items.Count - 1;
            lvMessages.Items[x].Focused = false;
            lvMessages.Items[x].Selected = false;

            lvMessages.EnsureVisible(x);
            lvMessages.Items[x].Focused = true;
            lvMessages.Items[x].Selected = true;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    Show();
                    WindowState = FormWindowState.Normal;
                }
            }
        }

        //private void foo()
        //{
        //    else if (lvMessages.SelectedItems[0].SubItems[1].Text.StartsWith("IMAGE:"))
        //    {
        //        var Tag = Convert.ToString(lvMessages.SelectedItems[0].Tag).Substring(4);
        //        MetroFramework.MetroMessageBox.Show(this, Tag);

        //        byte[] bytes = Convert.FromBase64String(Tag);
        //        Image img;
        //        using (var memStream = new System.IO.MemoryStream(bytes))
        //        {
        //            img = Image.FromStream(memStream);
        //        }
        //        if (img != null)
        //        {
        //            var imgForm = new ImageViewer(img);
        //            imgForm.Show();
        //        }
        //    }
        //}
    }
}
