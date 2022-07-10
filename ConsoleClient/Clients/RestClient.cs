using System;
namespace ConsoleClient.Clients
{
    public class RestClient : IClient
    {

        const string baseUri = "/api/items/";

        private readonly HttpClient httpClient;

        public string Name => "REST";

        public RestClient(string baseUrl)
        {

            httpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl)
            };

        }

        public async Task<string> GetItem(string id)
        {

            var response = await
                httpClient
                    .GetAsync(baseUri + id);
            var result = await
                response
                .Content
                .ReadAsAsync<GetItemResponse>();

            return result.Message;


        }

        public async Task<string> Post(string message)
        {
            var response = await
                httpClient
                .PostAsJsonAsync(baseUri, new { message });

            var result = await
                response
                .Content
                .ReadAsAsync<PostItemResponse>();


            return result.Id;

        }

        private class GetItemResponse
        {
            public string Message { get; }

            public GetItemResponse(string message)
            {
                Message = message;
            }
        }


        private class PostItemResponse
        {
            public string Id { get; }

            public PostItemResponse(string id)
            {
                Id = id;
            }
        }
    }
}

