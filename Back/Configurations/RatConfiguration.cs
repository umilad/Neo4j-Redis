using Neo4j.Berries.OGM.Interfaces;
using KrvNijeVoda.Back.Models;
using Neo4j.Berries.OGM.Models.Config;
using Neo4j.Berries.OGM.Enums;

namespace KrvNijeVoda.Back.Configurations;

public class RatConfiguration : INodeConfiguration<Rat>
{
    public void Configure(NodeTypeBuilder<Rat> builder)
    {
        builder.HasRelationWithSingle(x => x.GodinaDo, "TRAJAO_DO", RelationDirection.Out);
        builder.HasRelationWithMultiple(x => x.Pobednik, "POBEDILA_U", RelationDirection.In);
    }
}