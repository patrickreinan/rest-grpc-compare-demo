using System;
namespace RestAPI.dto
{
	public class PostItemResponse
	{
		public PostItemResponse(string id)
		{
            Id = id;
        }

        public string Id { get; }
    }
}

