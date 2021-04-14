using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AwaitAsyncDemo1
{
    public static class AwaitDemoClass
    {

        private static async Task<int> DownloadDocsMainPageAsync()
        {
            Console.WriteLine($"{nameof(DownloadDocsMainPageAsync)}:About to start downloading");
            var client = new HttpClient();
            byte[] content = await client.GetByteArrayAsync("https://docs.microsoft.com/en-us/");
            Console.WriteLine($"{nameof(DownloadDocsMainPageAsync)}:Finished downloading");
            return content.Length;
        }
    }
}
