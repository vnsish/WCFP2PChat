using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFChatForms
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ChatService" in both code and config file together.
    public class ChatService : IChatService
    {
        FormChat form;

        public ChatService(FormChat form)
        {
            this.form = form;
        }

        public void recvMessage(CompositeType composite)
        {
            form.text += "\r\n" + composite.usr + ": " + composite.msg;
        }

        public void sysMessage(String str)
        {
            form.text += "\r\n" + str;
        }
    }
}

