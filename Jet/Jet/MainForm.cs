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
    struct MESSAGE_TYPE
    {
        public const string TEXT = "TEXT";

        public const string URL = "URL";
    }

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
            if (e.KeyCode == Keys.Enter && AllowSendMessage && (!String.IsNullOrEmpty(tbMessage.Text)))
            {
                foreach (var msg in tbMessage.Text.Split('\n'))
                {
                    messageBuilder.AppendLine(msg);
                }
                SendTextMessage(messageBuilder.ToString());
                messageBuilder.Clear();
            }
        }

        private void tbFriedIP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConnectToFriend();
                tbMessage.Enabled = true;
                btnSendImage.Enabled = true;
                cbEmoji.Enabled = true;
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

        /// <summary>
        /// Method to send messages
        /// </summary>
        /// <param name="message">message content</param>
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
                    item.Tag = MESSAGE_TYPE.URL;
                else
                    item.Tag = MESSAGE_TYPE.TEXT;

                AddItem(item);

                tbMessage.Text = String.Empty;
                tbMessage.Focus();
            }
            catch (Exception ex)
            {
                ShowAlert(ex.ToString());
            }
        }

        /// <summary>
        /// Connetcting to your friends server
        /// </summary>
        private void ConnectToFriend()
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
                ShowAlert(ex.ToString());
            }
        }

        /// <summary>
        /// CallBack for DataReceived
        /// </summary>
        /// <param name="ar">AsyncResult</param>
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

                var stringArray = new String[3];
                stringArray[0] = "Friend";
                stringArray[1] = ReplaceNonPrintableCharacters(receivedMessage);
                stringArray[2] = DateTime.Now.ToShortTimeString();

                var item = new ListViewItem(stringArray);
                if (IsUrlValid(receivedMessage))
                    item.Tag = MESSAGE_TYPE.URL;
                else
                    item.Tag = MESSAGE_TYPE.TEXT;
                AddItem(item);
                if (WindowState == FormWindowState.Minimized)
                    Notify(receivedMessage);

                var buffer = new Byte[4096 * 4];
                socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref remote,
                    new AsyncCallback(MessageCallBack), buffer);
            }
            catch (Exception ex)
            {
                ShowAlert(ex.ToString());
            }
        }

        /// <summary>
        /// Shows a messagebox
        /// </summary>
        /// <param name="value">message content</param>
        public void ShowAlert(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(ShowAlert), new object[] { value });
                return;
            }
            MetroFramework.MetroMessageBox.Show(this, value);
        }

        /// <summary>
        /// calls the NotifyMessage method (by invoke)
        /// </summary>
        /// <param name="message">Notify message</param>
        public void Notify(String message)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<String>(NotifyMessage), new object[] { message });
                return;
            }
            NotifyMessage(message);
        }

        /// <summary>
        /// shows a toast notification
        /// </summary>
        /// <param name="message">content of the toast notification</param>
        public void NotifyMessage(String message)
        {
            notifyIcon1.BalloonTipText = message;
            notifyIcon1.ShowBalloonTip(5000);
        }

        /// <summary>
        /// adds item to ListView (by invoke)
        /// </summary>
        /// <param name="itm">Item</param>
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

        /// <summary>
        /// check if url is vaild
        /// </summary>
        /// <param name="url">URL</param>
        /// <returns>URL valid?</returns>
        private bool IsUrlValid(string url)
        {
            string pattern = @"^(file|http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }

        /// <summary>
        /// removes non-printable characters
        /// </summary>
        /// <param name="s">text</param>
        /// <returns>text without non-printable characters</returns>
        string ReplaceNonPrintableCharacters(string s)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                var character = s[i];
                if (((byte)character) >= 32)
                    result.Append(character);
            }
            return result.ToString();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            var port = 0;

            int.TryParse(cbPorts.SelectedItem.ToString(), out port);

            if (port == 7337)
                remotePort = 37337;
            else
                remotePort = 7337;

            ShowAlert("Server started!\nPort: " + port + "\nRemotePort: " + remotePort);

            epLocal = new IPEndPoint(IPAddress.Parse(tbLocalIP.Text), port);
            socket.Bind(epLocal);

            cbPorts.Enabled = false;
            btnStartServer.Enabled = false;
            tbFriedIP.ReadOnly = false;
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
                ShowAlert(ex.ToString());
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
                WindowState = FormWindowState.Normal;
                Show();
            }
        }

        private void cbEmoji_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEmoji.SelectedIndex > 0)
            {
                if (tbMessage.Text == tbMessage.PlaceHolderText)
                    tbMessage.Text = String.Empty;
                tbMessage.Text += cbEmoji.SelectedItem.ToString();
            }
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
