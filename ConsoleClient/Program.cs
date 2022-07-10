

using System.Diagnostics;
using ConsoleClient.Clients;

const int count = 1000;
const int columnSize = 15;


var clients = new IClient[]
{
    new GrpcClient("http://localhost:6002"),
    new RestClient("http://localhost:6001")
};

var stopWatch = new Stopwatch();

Console.Clear();


foreach (var client in clients)
{

    Console.Write(client.Name.PadRight(columnSize));


    stopWatch.Start();

    for (int current = 0; current < count; current++)
    {

        var id =await client.Post($"Message #{current}");

        _ = await client.GetItem(id);

    }
    stopWatch.Stop();


    Console.Write($"\t{stopWatch.Elapsed.TotalMilliseconds}".PadRight(columnSize));

    stopWatch.Reset();

    Console.WriteLine();

}








