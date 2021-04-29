using Dse;
using NetStudy.Core;
using System;
using System.Linq;

namespace Cassandra_Practice
{
    public class CassandraRunner : IRunner
    {
        public void Run()
        {
            IDseCluster cluster = DseCluster.Builder()
                .AddContactPoint("127.0.0.1")
                .WithPort(4200)
                .Build();
            IDseSession session = cluster.Connect();
            Dse.Row row = session.Execute("select * from system.local").First();
            Console.WriteLine(row.GetValue<string>("cluster_name"));
        }
    }
}
