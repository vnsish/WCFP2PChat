using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading.Tasks;

namespace WCFChatForms
{
    class Chat
    {
        public IChatService Channel;
        public IChatService Host;
        private DuplexChannelFactory<IChatService> factory;

        FormChat form;


        public Chat(FormChat chat)
        {
            form = chat;
        }

        public void StartService()
        {

            Host = new ChatService(form);
         
            factory = new DuplexChannelFactory<IChatService>(new InstanceContext(Host), "P2PChatEndpointC");

            var channel = factory.CreateChannel();

            ((ICommunicationObject)channel).Open();

            Channel = channel;

        }

        public void StopService()
        {

            ((ICommunicationObject)Channel).Close();
            if (factory != null)
                factory.Close();


        }

        public void Run()
        {

            StartService();

        }
    }
}
