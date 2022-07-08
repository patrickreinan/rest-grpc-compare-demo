using System;

namespace RestAPI.Models
{
    public class PostItemRequest
    {
        public PostItemRequest(int id, string message, string field1, string field2, string field3, string field4, string field5)
        {
            Id = id;
            Message = message;
            Field1 = field1;
            Field2 = field2;
            Field3 = field3;
            Field4 = field4;
            Field5 = field5;
        }

        public int Id { get; }

        public string Message { get; }

        public string Field1 { get; }

        public string Field2 { get; }

        public string Field3 { get; }

        public string Field4 { get; }

        public string Field5 { get; }
    }
}

