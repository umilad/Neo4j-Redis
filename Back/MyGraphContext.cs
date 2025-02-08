using Neo4j.Berries.OGM.Contexts;
using Neo4j.Berries.OGM.Models.Sets;
using KrvNijeVoda.Back.Models;

public class MyGraphContext(Neo4jOptions options): GraphContext(options) 
{
    public NodeSet<Licnost> Licnosti { get; private set; }
    //public NodeSet<Person> People { get; private set; }
}