namespace KrvNijeVoda.Models 
{
    public class Dinastija  {
        public Guid ID { get; set; }
        public string Vladavina { get; set; }
        public string Slika { get; set; }
        public List<Licnost> Clanovi { get; set; } = new List<Licnost>();
        
    }
}