using Neo4j.Berries.OGM.Interfaces;
using Neo4j.Berries.OGM;
using KrvNijeVoda.Back.Models;
using Neo4j.Berries.OGM.Models.Config;
using Neo4j.Berries.OGM.Enums;


namespace KrvNijeVoda.Back.Configurations;

public class VladarConfiguration : INodeConfiguration<Vladar>
{
    public void Configure(NodeTypeBuilder<Vladar> builder)
    {
        builder.HasRelationWithSingle(x => x.Dinastija, "PRIPADA", RelationDirection.Out);
        builder.HasRelationWithSingle(x => x.PocetakVladavine, "VLADAO_OD", RelationDirection.Out);
        builder.HasRelationWithSingle(x => x.KrajVladavine, "VLADAO_DO", RelationDirection.Out);
        builder.HasRelationWithMultiple(x => x.Deca, "JE_RODITELJ", RelationDirection.Out);
        builder.HasRelationWithMultiple(x => x.Supruznici, "JE_SUPRUZNIK", RelationDirection.Out);
        builder.HasRelationWithMultiple(x => x.Dogadjaji, "JE_UCESTVOVAO", RelationDirection.Out);
        // builder.HasRelationWithSingle(x => x.MestoRodjenja, "RODJEN_U", RelationDirection.Out);
        // builder.HasRelationWithSingle(x => x.GodinaRodjenja, "RODJEN", RelationDirection.Out);
        // builder.HasRelationWithSingle(x => x.GodinaSmrti, "UMRO", RelationDirection.Out);
    }
}