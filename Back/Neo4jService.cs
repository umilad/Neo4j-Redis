using Neo4j.Driver;

public class Neo4jService
{
    private readonly IDriver _driver;

    public Neo4jService(string uri, string user, string password)
    {
        _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
    }

    public IAsyncSession GetSession()
    {
        return _driver.AsyncSession();
    }

    //Clean up resources
    // public void Dispose()
    // {
    //     _driver?.Dispose();
    // }
}
// using System;
// using System.Threading.Tasks;
// using Neo4j.Driver;

// public class Neo4jService : IDisposable
// {
//     private readonly IDriver _driver;

//     // Constructor to initialize the connection with the database
//     public Neo4jService(string uri, string user, string password)
//     {
//         _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
//     }

//     // Method to run a simple query (e.g., fetching nodes)
//     public async Task ReadDataAsync()
//     {
//         var session = _driver.AsyncSession();
//         try
//         {
//             var result = await session.RunAsync("MATCH (n) RETURN n LIMIT 5");
//             while (await result.FetchAsync())
//             {
//                 Console.WriteLine(result.Current["n"]);
//             }
//         }
//         finally
//         {
//             await session.CloseAsync();
//         }
//     }

//     // Clean up resources
//     public void Dispose()
//     {
//         _driver?.Dispose();
//     }
// }
