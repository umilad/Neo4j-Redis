using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Neo4jService : IAsyncDisposable
{
    private readonly IDriver _driver;

    public Neo4jService(IDriver driver)
    {
        _driver = driver;
    }

    public Neo4jService(string uri, string username, string password)
    {
        try
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(username, password));
            Console.WriteLine("Connected to Neo4j successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to connect to Neo4j: {ex.Message}");
            throw;
        }
    }
    // Example: Run a Cypher query
    public async Task<List<string>> GetNodesAsync()
    {
        var nodes = new List<string>();

        // Open an async session
        await using var session = _driver.AsyncSession();

        // Execute a Cypher query
        var result = await session.RunAsync("MATCH (n) RETURN n.name AS name LIMIT 10");

        await result.ForEachAsync(record =>
        {
            nodes.Add(record["name"].As<string>());
        });

        return nodes;
    }
    public async Task AddNodeAsync(string name)
{
    await using var session = _driver.AsyncSession();

    await session.ExecuteWriteAsync(async tx =>
    {
        await tx.RunAsync("CREATE (n:Person {name: $name}) RETURN n", new { name });
    });
}

     // Dispose the driver properly
    public async ValueTask DisposeAsync()
    {
        await _driver.DisposeAsync();
    }

    //STARO




    // public Neo4jService(string uri, string user, string password)
    // {
    //     _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
    // }

    // public IAsyncSession GetSession()
    // {
    //     return _driver.AsyncSession();
    // }

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
