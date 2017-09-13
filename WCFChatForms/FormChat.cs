using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.PeerResolvers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFChatForms
{
    public partial class FormChat : Form
    {

        public string text { get { return txtChat.Text; } set { txtChat.Text = value; } }
        Chat ch;
        string username;
        CustomPeerResolverService cprs = new CustomPeerResolverService();

        public FormChat(string usr)
        {
            username = usr;
            ch = new Chat(this);
            ch.Run();
            InitializeComponent();
            var customResolver = new ServiceHost(cprs);
            cprs.Open();
            customResolver.Open();
            Thread.Sleep(5000);
            ch.Channel.sysMessage(username + " entrou na sala.");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            CompositeType cmp = new CompositeType(username, txtMessage.Text);
            ch.Channel.recvMessage(cmp);
            txtMessage.Text = String.Empty;
        }

        private void FormChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            ch.Channel.sysMessage(username + " saiu da sala.");
            ch.StopService();
        }
    }
}
