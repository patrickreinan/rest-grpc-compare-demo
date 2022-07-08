

using System.Diagnostics;
using System.Text.Json;
using Grpc.Net.Client;
using GrpcServiceClient;

const int count = 50;


const string RESTBaseURL = "http://localhost:6001";
const string GRPCBaseURL = "dns:///localhost:6002";

var stopWatch = new Stopwatch();

using var httpClient = new HttpClient()
{
    BaseAddress = new Uri(RESTBaseURL)
};


using var channel = GrpcChannel.ForAddress(GRPCBaseURL, new GrpcChannelOptions()
{
    Credentials = Grpc.Core.ChannelCredentials.Insecure
});
var grpcClient = new Itemer.ItemerClient(channel);

Console.Clear();


Console.WriteLine($"REST\t\tGRPC\t\tRESULT");


for (int current = 0; current < count; current++)
{
    /*
    var uri = $"/api/items/{current}";
    stopWatch.Start();
    var restResult = httpClient.GetAsync(uri).Result;
    stopWatch.Stop();
    var rest = stopWatch.Elapsed.TotalMilliseconds;

    stopWatch.Reset();

    var request = new ItemRequest() { Id = current };
    stopWatch.Start();
    var grpcResult = grpcClient.GetItem(request);
    stopWatch.Stop();
    var grpc = stopWatch.Elapsed.TotalMilliseconds;

    var compare =
        rest == grpc ? "EQUAL" :
        rest < grpc ? "REST" : "GRPC";
    Console.WriteLine($"{rest}\t\t{grpc}\t\t{compare}");

    stopWatch.Reset();
    */


    var uri = $"/api/items/";
    var item = new
    {
        Id = current,
        Message = "Posting message",
        Field1 = "field1",
        Field2 = "field2",
        Field3 = "field3",
        Field4 = "field4",
        Field5 = "field5"
    };
    var json = JsonSerializer.Serialize(item);

    stopWatch.Start();
    var restResult = httpClient.PostAsync(uri, new StringContent(json)).Result;
    stopWatch.Stop();
    var rest = stopWatch.Elapsed.TotalMilliseconds;
    stopWatch.Reset();



    var request = new PostItemRequest()
    {
        Id = current,
        Message = "Posting message",
        Field1 = "field1",
        Field2 = "field2",
        Field3 = "field3",
        Field4 = "field4",
        Field5 = "field5"
    };

    stopWatch.Start();
    var grpcResult = grpcClient.PostItem(request);
    stopWatch.Stop();

    var grpc = stopWatch.Elapsed.TotalMilliseconds;

    var compare =
        rest == grpc ? "EQUAL" :
        rest < grpc ? "REST" : "GRPC";
    Console.WriteLine($"{rest}\t\t{grpc}\t\t{compare}");

    stopWatch.Reset();

}







