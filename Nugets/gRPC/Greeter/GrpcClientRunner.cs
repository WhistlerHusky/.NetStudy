// Copyright 2015 gRPC authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Grpc.Core;
using Helloworld;
using NetStudy.Core;
using System;

namespace Greeter
{
    public class GrpcClientRunner : IRunner
    {
        public void Run()
        {
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            Channel channel2 = new Channel("127.0.0.1:50052", ChannelCredentials.Insecure);

            var client = new Helloworld.Greeter.GreeterClient(channel);
            var client2 = new Helloworld.Greeter.GreeterClient(channel2);
            String user = "you from client";

            var reply = client.SayHello(new HelloRequestFromClient() { Name = user });
            var reply2 = client2.SayHello(new HelloRequestFromClient() { Name = user });

            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Greeting: " + reply2.Message);

            channel.ShutdownAsync().Wait();
            channel2.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
