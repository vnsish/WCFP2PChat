using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFChatForms
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IChatService" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IChatService))]
    public interface IChatService
    {
        [OperationContract(IsOneWay = true)]
        void recvMessage(CompositeType composite);
        [OperationContract(IsOneWay = true)]
        void sysMessage(String str);
    }

    [DataContract]
    public class CompositeType
    {
        string usrValue = "";
        string msgValue = "";

        public CompositeType()
        {

        }

        public CompositeType(string usr, string msg)
        {
            usrValue = usr;
            msgValue = msg;
        }

        [DataMember]
        public string usr
        {
            get { return usrValue; }
            set { usrValue = value; }
        }

        [DataMember]
        public string msg
        {
            get { return msgValue; }
            set { msgValue = value; }
        }
    }

}
