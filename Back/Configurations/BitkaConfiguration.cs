using Neo4j.Berries.OGM.Interfaces;
//using Neo4j.Berries.OGM.Configuration;
using Neo4j.Berries.OGM;
using KrvNijeVoda.Back.Models;
using Neo4j.Berries.OGM.Models.Config;
using Neo4j.Berries.OGM.Enums;


//using Neo4j.Berries.OGM.Models.Config.NodeTypeBuilder;

namespace KrvNijeVoda.Back.Configurations;

public class BitkaConfiguration : INodeConfiguration<Bitka>
{
    public void Configure(NodeTypeBuilder<Bitka> builder)
    {
        builder.HasRelationWithSingle(x => x.Godina, "DESILA_SE", RelationDirection.Out);
        builder.HasRelationWithSingle(x => x.Rat, "PRIPADA", RelationDirection.Out);

        builder.HasIdentifier(x => x.ID);
    }
}