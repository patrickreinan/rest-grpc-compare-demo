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
                return new PostItemReply() {
                    Id = service.PostItem(request.Message)
                };
            });


        }



        public override Task<ItemReply> GetItem(ItemRequest request, ServerCallContext context)
        {
            return Task.Run(() =>
            {
                var item = service.GetById(request.Id);


                return new ItemReply()
                {
                    Message = item.Message
                };
            });
        }


    }
}

