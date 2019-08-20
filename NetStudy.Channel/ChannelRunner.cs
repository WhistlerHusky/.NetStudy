using NetStudy.Core;
using System;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace NetStudy.Channels
{
    public class ChannelRunner : IRunner
    {
        public void Run()
        {
            Console.WriteLine("Which sample do you want to run?");
            Console.WriteLine("1. Single producer, single consumer");
            Console.WriteLine("2. Multiple producers, single consumer");
            Console.WriteLine("3. Single producer, multiple consumers");
            Console.WriteLine("4. Multiple producers, multiple consumers");

            var key = Console.ReadKey();

            switch (key.KeyChar)
            {
                case '1':
                    Task.Run(async () => await SingleProducerSingleConsumer()).Wait();
                    break;

                case '2':
                    Task.Run(async () => await MultiProducerSingleConsumer()).Wait();
                    break;

                case '3':
                    Task.Run(async () => await SingleProduceMultipleConsumers()).Wait();
                    break;

                case '4':
                    Task.Run(async () => await MultiProducersMultiConsumers()).Wait();
                    break;

                default:
                    Console.WriteLine("That was an invalid choice!");
                    break;
            }
        }

        public async Task SingleProducerSingleConsumer()
        {
            var channel = Channel.CreateUnbounded<string>();

            // In this example, the consumer keeps up with the producer

            var producer1 = new Producer(channel.Writer, 1, 2000);
            var consumer1 = new Consumer(channel.Reader, 1, 1500);

            Task consumerTask1 = consumer1.ConsumeData(); // begin consuming
            Task producerTask1 = producer1.BeginProducing(); // begin producing

            await producerTask1.ContinueWith(_ => channel.Writer.Complete());

            await consumerTask1;
        }

        public async Task MultiProducerSingleConsumer()
        {
            var channel = Channel.CreateUnbounded<string>();

            // In this example, a single consumer easily keeps up with two producers

            var producer1 = new Producer(channel.Writer, 1, 2000);
            var producer2 = new Producer(channel.Writer, 2, 2000);
            var consumer1 = new Consumer(channel.Reader, 1, 250);

            Task consumerTask1 = consumer1.ConsumeData(); // begin consuming

            Task producerTask1 = producer1.BeginProducing();

            await Task.Delay(500); // stagger the producers

            Task producerTask2 = producer2.BeginProducing();

            await Task.WhenAll(producerTask1, producerTask2)
                .ContinueWith(_ => channel.Writer.Complete());

            await consumerTask1;
        }
        public async Task MultiProducersMultiConsumers()
        {
            var channel = Channel.CreateUnbounded<string>();

            var producer1 = new Producer(channel.Writer, 1, 1000);
            var producer2 = new Producer(channel.Writer, 2, 1000);
            var consumer1 = new Consumer(channel.Reader, 1, 5250);
            var consumer2 = new Consumer(channel.Reader, 2, 750);

            Task consumerTask1 = consumer1.ConsumeData(); // begin consuming
            Task consumerTask2 = consumer2.ConsumeData(); // begin consuming

            Task producerTask1 = producer1.BeginProducing();

            await Task.Delay(500); // stagger the producers

            Task producerTask2 = producer2.BeginProducing();

            await Task.WhenAll(producerTask1, producerTask2)
                .ContinueWith(_ => channel.Writer.Complete());

            await Task.WhenAll(consumerTask1, consumerTask2);
        }

        public async Task SingleProduceMultipleConsumers()
        {
            var channel = Channel.CreateUnbounded<string>();

            // In this example, multiple consumers are needed to keep up with a fast producer

            var producer1 = new Producer(channel.Writer, 1, 100);
            var consumer1 = new Consumer(channel.Reader, 1, 1500);
            var consumer2 = new Consumer(channel.Reader, 2, 1500);
            var consumer3 = new Consumer(channel.Reader, 3, 1500);

            Task consumerTask1 = consumer1.ConsumeData(); // begin consuming
            Task consumerTask2 = consumer2.ConsumeData(); // begin consuming
            Task consumerTask3 = consumer3.ConsumeData(); // begin consuming

            Task producerTask1 = producer1.BeginProducing();

            await producerTask1.ContinueWith(_ => channel.Writer.Complete());

            await Task.WhenAll(consumerTask1, consumerTask2, consumerTask3);
        }
    }
}
