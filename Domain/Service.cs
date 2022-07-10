using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Service
    {
        private readonly Repository repository;

        public Service(Repository repository)
        {
            this.repository = repository;
        }

        public Item GetById(string id)
        {
            return repository.Get(id);           
        }

        public string PostItem(string message)
        {
            var item = new Item(message);
            repository.Insert(item);
            return item.Id;
        }
    }
}

