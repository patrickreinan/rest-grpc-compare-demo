using System;
namespace RestAPI.dto
{
	public class PostItemResponse
	{
		public PostItemResponse(int id)
		{
            Id = id;
        }

        public int Id { get; }
    }
}

