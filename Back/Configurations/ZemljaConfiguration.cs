using Neo4j.Berries.OGM.Interfaces;
using KrvNijeVoda.Back.Models;
using Neo4j.Berries.OGM.Models.Config;
using Neo4j.Berries.OGM.Enums;

namespace KrvNijeVoda.Back.Configurations;

public class ZemljaConfiguration : INodeConfiguration<Zemlja>
{
    public void Configure(NodeTypeBuilder<Zemlja> builder)
    {
    }
}