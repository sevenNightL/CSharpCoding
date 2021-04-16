using ElasticsearchDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchDemo.ElasticeService
{
    public interface IElasticsearchService
    {
        Task<Person> ElasticsearchQuery();
        Task<int> ElasticsearchInsert();
        Task<int> ElasticsearchUpdate();
        Task<int> ElasticsearchDelete();
    }
}
