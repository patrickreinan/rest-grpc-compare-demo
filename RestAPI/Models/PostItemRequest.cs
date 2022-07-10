using System;

namespace RestAPI.Models
{
    public class PostItemRequest
    {
        public PostItemRequest(string message)
        {

            Message = message;
        }

        public string Message { get; }
 
    }
}

