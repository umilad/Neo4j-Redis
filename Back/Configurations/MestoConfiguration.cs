using Neo4j.Berries.OGM.Interfaces;
using KrvNijeVoda.Back.Models;
using Neo4j.Berries.OGM.Models.Config;
using Neo4j.Berries.OGM.Enums;

namespace KrvNijeVoda.Back.Configurations;

public class MestoConfiguration : INodeConfiguration<Mesto>
{
    public void Configure(NodeTypeBuilder<Mesto> builder)
    {
        builder.HasRelationWithSingle(x => x.PripadaZemlji, "PRIPADA", RelationDirection.Out);

        builder.HasIdentifier(x => x.ID);
    }
}