using Nest;
using SignUp.MessageHandlers.IndexProspect.Documents;
using System;

namespace SignUp.MessageHandlers.IndexProspect.Indexer
{
    public class Index
    {
        public static void Setup()
        {
            var node = new Uri(Config.ElasticsearchUrl);
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            client.CreateIndex("prospects");
        }

        public static void CreateDocument(Prospect prospect)
        {
            var node = new Uri(Config.ElasticsearchUrl);
            var client = new ElasticClient(node);
            client.Index(prospect, idx => idx.Index("prospects"));
        }
    }
}
