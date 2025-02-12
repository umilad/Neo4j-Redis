using Neo4j.Berries.OGM.Interfaces;
using KrvNijeVoda.Back.Models;
using Neo4j.Berries.OGM.Models.Config;
using Neo4j.Berries.OGM.Enums;

namespace KrvNijeVoda.Back.Configurations;

public class DinastijaConfiguration : INodeConfiguration<Dinastija>
{
    public void Configure(NodeTypeBuilder<Dinastija> builder)
    {
        builder.HasRelationWithSingle(x => x.PocetakVladavine, "VLADALA_OD", RelationDirection.Out);
        builder.HasRelationWithSingle(x => x.KrajVladavine, "VLADALA_DO", RelationDirection.Out);
        builder.HasRelationWithMultiple(x => x.Clanovi, "PRIPADNICI", RelationDirection.Out);

        builder.HasIdentifier(x => x.ID);
    }
}