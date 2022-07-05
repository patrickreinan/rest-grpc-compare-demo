using System;
using Domain;
using Grpc.Core;
using GrpcService;

namespace GrpcService.Services
{
	public class ItemerService  : Itemer.ItemerBase	{
        private readonly Service service;

        public ItemerService(Service service)
		{
            this.service = service;
        }


        public override Task<ItemReply> GetItem(ItemRequest request, ServerCallContext context)
        {

            var item = service.GetItem(request.Id);

            return Task.FromResult( new ItemReply()
            {
                Id = item.Id
            });
        }


    }
}

