using System;
using System.Configuration;
using System.Data.Common;

namespace DbProviderFactoryDemo
{
    class Program
    {
        public static DbProviderFactory dataFactory =
DbProviderFactories.GetFactory(
ConfigurationManager.AppSettings["provider"]);
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
