namespace KrvNijeVoda.Models { 

public class Licnost {
    public Guid ID { get; set;}
    public string Titula { get; set;}
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public DateTime DatumRodjenja { get; set; }
    public DateTime DatumSmrti { get; set; }
    public string Pol { get; set; }
    public string Slika { get; set; }
    public string MestoRodjenja { get; set; }
    
}

}