namespace Domain
{
    public class Item
    {
        public Item(string id, string message)
        {
            Id = id;
            Message = message;
        
        }

        public Item(string message) : this(Guid.NewGuid().ToString(), message) { }


        public string Id { get; }

        public string Message { get; }

      }

}
