using System;
using System.Threading.Tasks;
using Nest;
using NetStudy.Core;
using NetSutdy.DesignPattern.Creational.Prototype;

namespace Elasticsearch_HighLevel_NEST
{
    public class ElasticsearchHighLevelRunner : IRunner
    {
        public void Run()
        {
            var settings = new ConnectionSettings()
                .DefaultIndex("marine");

            //var resolver = new IndexNameResolver(settings);
            //var index = resolver.Resolve<Marine>();

            var client = new ElasticClient(settings);

            var marine1 = new Marine
            {
                Name = "ElasticMarine",
                CurrentHp = 35,
                MaxHp = 40
            };

            var indexResponse = client.IndexDocument(marine1);

            Task.Run(async () =>
            {
                var marine2 = new Marine
                {
                    Name = "ElasticMarine2",
                    CurrentHp = 35,
                    MaxHp = 40
                };
                var asyncIndexResponse = await client.IndexDocumentAsync(marine2);

            }).Wait();

            var searchResponse =
                client.Search<Marine>(s => s
                    .From(0)
                    .Size(10)
                    .Query(x => x
                        .Match(m => m
                            .Field(f => f.Name)
                            .Query("ElasticMarine")
                        )
                    )
                );

            foreach (var marine in searchResponse.Documents)
            {
                Console.WriteLine($"{marine.Name} {marine.MaxHp}: {marine.CurrentHp}");
            }

            Task.Run(async () =>
            {
                var searchResponse2 =
                    await client.SearchAsync<Marine>(x => x.From(0)
                    .Size(10)
                    .Query(y => y
                        .Match(m => m
                            .Field(f => f.Name)
                            .Query("ElasticMarine2")
                        )
                    )
                );

                foreach (var marine in searchResponse2.Documents)
                {
                    Console.WriteLine($"{marine.Name} {marine.MaxHp}: {marine.CurrentHp}");
                }
            }).Wait();
        }
    }
}