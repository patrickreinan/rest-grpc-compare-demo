using System;
namespace Domain
{
	public class Repository
	{

		private List<Item> items;

		public Repository()
		{
			items = new List<Item>();
		}

		public void Insert(Item item)
        {
			items.Add(item);
        }

		public Item Get(string id)
        {
			return items.First(i => i.Id == id);
        }


	}
}

