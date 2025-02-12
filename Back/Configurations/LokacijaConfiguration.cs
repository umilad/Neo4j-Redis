using Neo4j.Berries.OGM.Interfaces;
using KrvNijeVoda.Back.Models;
using Neo4j.Berries.OGM.Models.Config;
using Neo4j.Berries.OGM.Enums;

namespace KrvNijeVoda.Back.Configurations;

public class LokacijaConfiguration : INodeConfiguration<Lokacija>
{
    public void Configure(NodeTypeBuilder<Lokacija> builder)
    {
        builder.HasIdentifier(x => x.ID);
    }
}