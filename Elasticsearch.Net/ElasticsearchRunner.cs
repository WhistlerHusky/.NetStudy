using Elasticsearch.Net;
using NetStudy.Core;
using NetSutdy.DesignPattern.Creational.Prototype;
using System.Threading.Tasks;

namespace Elasticsearch_Demo
{
    public class ElasticsearchRunner : IRunner
    {
        public void Run()
        {
            //var uris = new[]
            //{
            //    new Uri("http://localhost:9200"),
            //    new Uri("http://localhost:9201"),
            //    new Uri("http://localhost:9202"),
            //};

            //var connectionPool = new SniffingConnectionPool(uris);
            //var settings = new ConnectionConfiguration(connectionPool);

            var lowLevelClient = new ElasticLowLevelClient();

            var marine1 = new Marine();
            marine1.Name = "ElasticMarine";
            marine1.CurrentHp = 35;
            marine1.MaxHp = 40;
            var indexResponse = lowLevelClient.Index<BytesResponse>("marine1", "marine", "1", PostData.Serializable(marine1));

            byte[] responseBytes = indexResponse.Body;
            Task.Run(async () =>
            {
                marine1.Name = "ElasticMarine2";
                var asyncIndexResponse = await lowLevelClient.IndexAsync<StringResponse>("marine1", "marine", "2",
                        PostData.Serializable(marine1));

                string responseString = asyncIndexResponse.Body;

            }).Wait();

            var searchResponse = lowLevelClient.Search<StringResponse>("marine1", "marine", PostData.Serializable(new
            {
                from = 0,
                size = 10,
            }));

            Task.Run(async () =>
            {
                var searchResponse2 = await lowLevelClient.SearchAsync<StringResponse>("marine1", "marine",
                    PostData.Serializable(new
                    {
                        from = 0,
                        size = 10,
                    }));

                var body = searchResponse2.Body;
                //TODO 나중에 어떻게 다시 오브젝트로 찾는지 찾아볼것
                
            }).Wait();

        
        }
    }
}