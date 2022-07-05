

using System.Diagnostics;
using Grpc.Net.Client;
using GrpcServiceClient;

const int count = 100_000;
const string RESTBaseURL = "http://localhost:6001";
const string GRPCBaseURL = "dns:///localhost:6002";

Menu();

void Menu()
{

    Console.Clear();
    Console.WriteLine("1. REST");
    Console.WriteLine("2. GRPC");

    Console.WriteLine("Choose a option:");
    var option = Console.Read();

    var ch = Convert.ToChar(option);

    switch (ch)
    {
        case '1':
            REST();
            break;
        case '2':
            GRPC();
            break;
        default:
            Menu();
            break;
    }

}


void Run(Action action)
{
    var stopWatch = new Stopwatch();

    stopWatch.Start();

    action();

    stopWatch.Stop();

    Console.WriteLine($"{stopWatch.Elapsed.Seconds} sec");

}


void REST()
{

    Run(() =>
    {

        using var httpClient = new HttpClient()
        {
            BaseAddress = new Uri(RESTBaseURL)
        };

        for (int current = 0; current < count; current++)
        {
            httpClient.GetAsync($"/api/items/{current}").Wait();
        }

    });

}


void GRPC()
{


    Run(() =>
    {



        using var channel = GrpcChannel.ForAddress(GRPCBaseURL, new GrpcChannelOptions()
        {
            Credentials = Grpc.Core.ChannelCredentials.Insecure
        });

         var client = new Itemer.ItemerClient(channel);


        for (int current = 0; current < count; current++)
        {
            var result = client.GetItem(new ItemRequest() { Id = current });
        }

    }
    );

}
