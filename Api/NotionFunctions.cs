using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Notion.Client;

namespace ApiIsolated;

public class NotionFunctions
{
    readonly ILogger logger;
    
    public NotionFunctions(ILoggerFactory loggerFactory)
    {
        logger = loggerFactory.CreateLogger<NotionFunctions>();
    }
    
    [Function("GetNotionDatabase")]
    public async Task<PaginatedList<Page>> FetchDatabase(string databaseId)
    {
        var client = NotionClientFactory.Create(new ClientOptions
        {
            AuthToken = "secret_15KdBxAtSa1EsAQbYYzc5yr8fmecioC5oVtHuEZKkNV"
        });
        
        var databaseQueryParameters = new DatabasesQueryParameters();

        var queryResult = await client.Databases.QueryAsync(databaseId, databaseQueryParameters);
        return queryResult;
    }

    [Function("GetNotionPage")]
    public async Task FetchPage()
    {
        
    }
}