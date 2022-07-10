using System;
using Grpc.Net.Client;
using GrpcServiceClient;

namespace ConsoleClient.Clients
{
    public class GrpcClient : IClient
    {


        private readonly Itemer.ItemerClient grpcClient;

        public string Name => "GRPC";

        public GrpcClient(string baseUrl)
        {
            var channel = GrpcChannel.ForAddress(baseUrl, new GrpcChannelOptions()
            {
                Credentials = Grpc.Core.ChannelCredentials.Insecure
            });

            grpcClient = new Itemer.ItemerClient(channel);

        }

        public async Task<string> Post(string message)
        {

            var result = await grpcClient.PostItemAsync(
                new PostItemRequest() { Message = message }
                );
            return result.Id;

        }

        public async Task<string> GetItem(string id)
        {
            var result = await grpcClient.GetItemAsync(
                new ItemRequest() { Id = id });


            return result.Message;

        }


    }
}

