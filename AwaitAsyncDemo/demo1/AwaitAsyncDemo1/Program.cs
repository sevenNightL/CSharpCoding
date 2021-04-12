using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AwaitAsyncDemo1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Task<int> downloading = DownLoadDocsMainPageAsync();
            Console.WriteLine();
            Console.WriteLine("Hello World!");
        }

        private static async Task<int> DownLoadDocsMainPageAsync()
        {
            Console.WriteLine($"{nameof(DownLoadDocsMainPageAsync)}:About to start downloading.");

            var client = new HttpClient();
            byte[] content = await client.GetByteArrayAsync("https://docs.microsoft.com/en-us");
            Console.WriteLine($"{nameof(DownLoadDocsMainPageAsync)}:Finished downloading");
            return content.Length;
        }
    }
}
