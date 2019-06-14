using Grpc.Core;
using NetStudy.Core;
using System;
using System.Threading.Tasks;

namespace Greeter
{
    public class GrpcServerRunner : IRunner
    {
        const int Port = 50051;
        const int Port2 = 50052;

        public void Run()
        {
            Task.Run(() => //Task used only for testing, this does not require when server and client run in different process.
            {
                Server server = new Server
                {
                    Services = { Helloworld.Greeter.BindService(new GreeterImpl { Message = "Hello from server1 " }) },
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                };
                Server server2 = new Server
                {
                    Services = { Helloworld.Greeter.BindService(new GreeterImpl { Message = "Hello from server2 " }) },
                    Ports = { new ServerPort("localhost", Port2, ServerCredentials.Insecure) }
                };

                server.Start();
                server2.Start();
                Console.WriteLine("Greeter server listening on port " + Port);
                Console.WriteLine("Greeter server listening on port " + Port2);
                Console.WriteLine("Press any key to stop the server...");
                Console.ReadKey();

                server.ShutdownAsync().Wait();
            });
        }
    }
}