namespace ConsoleClient.Clients
{
    public interface IClient
    {
        Task<string> GetItem(string id);
        Task<string> Post(string message);

        string Name { get;  }
    }
}