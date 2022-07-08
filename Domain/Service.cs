using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Service
    {
        public Item GetItem(int id)
        {
            return new Item(id, "Message from item", "Field1", "Field2", "Field3", "Field4", "Field5");
        }

        public int PostItem(Item item)
        {
            return item.Id;
        }
    }
}

