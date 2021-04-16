using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElasticsearchDemoOne.common
{
    public class ElasticsearchHelper
    {
        public void esSearch(ElasticClient elasticClient)
        {
            var searchResponse = elasticClient.Search<Person>(s => s.From(0)
              .Size(10)
              .Query(q => q.Match(m => m.Field(f => f.FirstName).Query("Martijn"))));

            var people = searchResponse.Documents;
        }
    }
}
