using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/neo4j")]
[ApiController]
public class Neo4jController : ControllerBase
{
    private readonly Neo4jService _neo4jService;

    public Neo4jController(Neo4jService neo4jService)
    {
        _neo4jService = neo4jService;
    }

    // GET: api/neo4j/nodes
    [HttpGet("nodes")]
    public async Task<ActionResult<List<string>>> GetNodes()
    {
        var nodes = await _neo4jService.GetNodesAsync();
        return Ok(nodes);
    }

    // POST: api/neo4j/addNode
    [HttpPost("addNode")]
    public async Task<IActionResult> AddNode([FromBody] string nodeName)
    {
        await _neo4jService.AddNodeAsync(nodeName);
        return Ok($"Node '{nodeName}' added successfully.");
    }
}
