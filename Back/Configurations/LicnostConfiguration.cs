using Neo4j.Berries.OGM.Interfaces;
//using Neo4j.Berries.OGM.Configuration;
using Neo4j.Berries.OGM;
using KrvNijeVoda.Back.Models;
using Neo4j.Berries.OGM.Models.Config;
using Neo4j.Berries.OGM.Enums;


//using Neo4j.Berries.OGM.Models.Config.NodeTypeBuilder;

namespace KrvNijeVoda.Back.Configurations;

public class LicnostConfiguration : INodeConfiguration<Licnost>
{
    public void Configure(NodeTypeBuilder<Licnost> builder)
    {
        //builder.HasRelationWithMultiple(x => (IEnumerable<Godina>)x.GodinaRodjenja, "RODJEN", RelationDirection.Out);
        builder.HasRelationWithSingle(x => x.GodinaRodjenja, "RODJEN", RelationDirection.Out);
        //builder.HasRelationWithSingle(x => (IEnumerable<Godina>)x.GodinaSmrti, "UMRO", RelationDirection.Out);
        
    }   
}