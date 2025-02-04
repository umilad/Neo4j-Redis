namespace KrvNijeVoda.Models { 
    public class Bitka : Dogadjaj {
        public List<Zemlja> Pobednik { get; set; } = new List<Zemlja>();
        public Godina GodinaDo { get; set; }
        public Rat Rat { get; set; }

    }
}