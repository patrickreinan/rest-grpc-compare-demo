

using System.Diagnostics;
using System.Text.Json;
using ConsoleClient;
using Grpc.Net.Client;
using GrpcServiceClient;

const int count = 10;
const int columnSize = 15;


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

bool headerRendered = false;

for (int current = 0; current < count; current++)
{


    var executionPlan = new ExecutionPlan();

    var restGetUri = $"/api/items/{current}";
    var restPostUri = $"/api/items/";
    var restPostBodyObject = new
    {
        Id = current,
        Message = "Posting message",
        Field1 = "field1",
        Field2 = "field2",
        Field3 = "field3",
        Field4 = "field4",
        Field5 = "field5"
    };

    var grpcPostItem = new PostItemRequest()
    {
        Id = current,
        Message = "Posting message",
        Field1 = "field1",
        Field2 = "field2",
        Field3 = "field3",
        Field4 = "field4",
        Field5 = "field5"
    };

    var restPostBody = JsonSerializer.Serialize(restPostBodyObject);

    var grpcGetRequest = new ItemRequest() { Id = current };


    executionPlan
        .AddStep("REST-GetItem", () =>
        {
            _ = httpClient.GetAsync(restGetUri).Result;
        })
       
        .AddStep("GRPC-GetItem", () =>
        {
            _ = grpcClient.GetItem(grpcGetRequest);
        })
         .AddStep("REST-PostItem", () =>
         {
             _ = httpClient.PostAsync(restPostUri, new StringContent(restPostBody)).Result;
         })
        .AddStep("GRPC-PostItem", () =>
        {
            _ = grpcClient.PostItem(grpcPostItem);
        })
        .Execute();


    foreach (var item in executionPlan.Results)
    {
        if (!headerRendered)
        {
            foreach (var key in executionPlan.Results.Keys)
                Console.Write($"{key}\t".PadLeft(columnSize));  

            Console.WriteLine();
        }
        headerRendered = true;

        Console.Write($"{item.Value}\t".PadLeft(columnSize));
    }

    Console.WriteLine();

}








