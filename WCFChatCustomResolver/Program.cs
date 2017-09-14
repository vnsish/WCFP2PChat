using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.PeerResolvers;
using System.Text;
using System.Threading.Tasks;

namespace WCFChatCustomResolver
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CustomPeerResolverService crs = new CustomPeerResolverService();
            crs.ControlShape = false;

            ServiceHost customResolver = new ServiceHost(crs);

            
            crs.Open();
            customResolver.Open();
            Console.WriteLine("Servidor custom resolver rodando");
            Console.ReadLine();
        }
    }
}
