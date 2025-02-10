using Neo4j.Berries.OGM.Contexts;
using Neo4j.Berries.OGM.Models.Sets;
using KrvNijeVoda.Back.Models;

public class MyGraphContext(Neo4jOptions options): GraphContext(options) 
{
    public NodeSet<Bitka> Bitke { get; private set; }
    public NodeSet<Dinastija> Dinastije { get; private set; }
    public NodeSet<Dogadjaj> Dogadjaji { get; private set; }
    public NodeSet<Godina> Godine { get; private set; }
    public NodeSet<Licnost> Licnosti { get; private set; }
    public NodeSet<Lokacija> Lokacije { get; private set; }
    public NodeSet<Mesto> Mesta { get; private set; }
    public NodeSet<Rat> Ratovi { get; private set; }
    public NodeSet<Vladar> Vladari { get; private set; }
    public NodeSet<Zemlja> Zemlje { get; private set; }

}