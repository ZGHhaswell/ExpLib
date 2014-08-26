#define Security


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WcfLib;
using System.ServiceModel.Description;
using System.Security.Permissions;

#if Security
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution = true)]
#endif
namespace WcfHost
{
    class Program
    {
        static void Main(string[] args)
        {
#if Security
            // First procedure:
            // create a WSHttpBinding that uses Windows credentials and message security
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.Windows;

            // 2nd Procedure:
            // Use the binding in a service
            // Create the Type instances for later use and the URI for 
            // the base address.
            Type contractType = typeof(IService);
            Type serviceType = typeof(Service);
            Uri baseAddress = new
                Uri("http://localhost:8000/Service/");

            // Create the ServiceHost and add an endpoint, then start
            // the service.
            ServiceHost myServiceHost =
                new ServiceHost(serviceType, baseAddress);
            myServiceHost.AddServiceEndpoint
                (contractType, myBinding, "Service");

            //enable metadata
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myServiceHost.Description.Behaviors.Add(smb);

            myServiceHost.Open();
            Console.WriteLine("Listening");
            Console.WriteLine("Press Enter to close the service");
            Console.ReadLine();
            myServiceHost.Close();





#else

            // Step 1 Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:8000/Service/");

            // Step 2 Create a ServiceHost instance
            ServiceHost selfHost = new ServiceHost(typeof(Service), baseAddress);

            try
            {
                // Step 3 Add a service endpoint.
                selfHost.AddServiceEndpoint(typeof(IService), new WSHttpBinding(), "Service");

                // Step 4 Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Step 5 Start the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
#endif



        }
    }
}
