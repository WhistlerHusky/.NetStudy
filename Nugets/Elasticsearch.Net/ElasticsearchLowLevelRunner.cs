using Elasticsearch.Net;
using NetStudy.Core;
using NetSutdy.DesignPattern.Creational.Prototype;
using System.Threading.Tasks;

namespace Elasticsearch_LowLevel
{
    public class ElasticsearchLowLevelRunner : IRunner
    {
        public void Run()
        {
            var lowLevelClient = new ElasticLowLevelClient();

            var marine1 = new Marine
            {
                Name = "ElasticMarine",
                CurrentHp = 35,
                MaxHp = 40
            };

            //Async 아니면 작동안함,, 원인은 담에 파악하는걸로~
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