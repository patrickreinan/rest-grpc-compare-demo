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
            return new Item(id);
        }
    }
}

