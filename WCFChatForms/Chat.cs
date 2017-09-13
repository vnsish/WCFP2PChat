using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading.Tasks;
using System.ServiceModel.PeerResolvers;

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
            var binding = new NetPeerTcpBinding();
            binding.Security.Mode = SecurityMode.None;
            binding.Resolver.Mode = PeerResolverMode.Auto;

            var endpoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(IChatService)), binding, new EndpointAddress("net.p2p://P2PChatMesh/chat"));

            Host = new ChatService(form);

            factory = new DuplexChannelFactory<IChatService>(new InstanceContext(Host), endpoint);

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
