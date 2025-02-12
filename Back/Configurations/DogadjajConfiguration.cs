using Neo4j.Berries.OGM.Interfaces;
using KrvNijeVoda.Back.Models;
using Neo4j.Berries.OGM.Models.Config;
using Neo4j.Berries.OGM.Enums;

namespace KrvNijeVoda.Back.Configurations;

public class DogadjajConfiguration : INodeConfiguration<Dogadjaj>
{
    public void Configure(NodeTypeBuilder<Dogadjaj> builder)
    {
        builder.HasRelationWithSingle(x => x.Godina, "DESIO_SE", RelationDirection.Out);
        builder.HasRelationWithSingle(x => x.Lokacija, "DESIO_SE_U", RelationDirection.Out);
        builder.HasRelationWithMultiple(x => x.Ucesnici, "UCESNICI", RelationDirection.Out);

        builder.HasIdentifier(x => x.ID);
    }
}