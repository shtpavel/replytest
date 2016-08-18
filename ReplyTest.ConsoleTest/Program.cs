using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReplyTest.Http;

namespace ReplyTest.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var client = new MattersHttpClient();
                var result = await client.GetTopRatedAppsAsync(11);

                Console.WriteLine(result.NumberResults);
                foreach (var app in result.Results)
                {
                    Console.WriteLine(app.Title);
                }
            }).Wait();
        }
    }
}
