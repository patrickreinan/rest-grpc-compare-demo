using System;
using Domain;
using Grpc.Core;
using GrpcService;

namespace GrpcService.Services
{
    public class ItemerService : Itemer.ItemerBase
    {
        private readonly Service service;

        public ItemerService(Service service)
        {
            this.service = service;
        }

        public override Task<PostItemReply> PostItem(PostItemRequest request, ServerCallContext context)
        {
            return Task.Run(() =>
            {
                var item = new Item(request.Id, request.Message, request.Field1, request.Field2, request.Field3, request.Field4, request.Field5);
                return new PostItemReply() { Id = service.PostItem(item) };
            });


        }



        public override Task<ItemReply> GetItem(ItemRequest request, ServerCallContext context)
        {
            return Task.Run(() =>
            {
                var item = service.GetItem(request.Id);


                return new ItemReply()
                {
                    Id = item.Id,
                    Message = item.Message,
                    Field1 = item.Field1,
                    Field2 = item.Field2,
                    Field3 = item.Field3,
                    Field4 = item.Field4,
                    Field5 = item.Field5,
                };
            });
        }


    }
}

