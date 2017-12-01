using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jet
{
    
    public partial class MessageView : MetroFramework.Forms.MetroForm
    {
        public string Message { get; set; }

        public MessageView(string message)
        {
            InitializeComponent();
            //InitCustomFont();
            textBox1.Text = message;
        }

        private void InitCustomFont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            string exePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            var font = System.IO.Path.Combine(exePath, "OpenSansEmoji.ttf");
            pfc.AddFontFile(font);
            textBox1.Font = new Font(pfc.Families[0], 32, FontStyle.Regular);
        }

        private void MessageView_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
