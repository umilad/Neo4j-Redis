using Neo4j.Berries.OGM.Interfaces;
using Neo4j.Berries.OGM;
using KrvNijeVoda.Back.Models;
using Neo4j.Berries.OGM.Models.Config;
using Neo4j.Berries.OGM.Enums;


namespace KrvNijeVoda.Back.Configurations;

public class LicnostConfiguration : INodeConfiguration<Licnost>
{
    public void Configure(NodeTypeBuilder<Licnost> builder)
    {
        builder.HasRelationWithSingle(x => x.MestoRodjenja, "RODJEN_U", RelationDirection.Out);
        // .OnMerge()
        // .Include(x => x.Id); ako menjamo objekat pa je povezan samo sa id?? new ZNAM FARHADE
        builder.HasRelationWithSingle(x => x.GodinaRodjenja, "RODJEN", RelationDirection.Out);
        builder.HasRelationWithSingle(x => x.GodinaSmrti, "UMRO", RelationDirection.Out);

        builder.HasIdentifier(x => x.ID);
    }
}