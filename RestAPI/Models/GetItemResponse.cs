using System;
namespace RestAPI.Models
{
    public class GetItemResponse
    {
        public GetItemResponse(string message)
        {
            Message = message;
        }

        public string Message { get; }


    }
}

