namespace KrvNijeVoda.Models 
{
    public class Vladar : Licnost {
        public Dinastija Dinastija { get; set; }
        public string Teritorija { get; set; }
        public string PeriodVladavine  { get; set; }
        public List<Licnost> Deca { get; set; } = new List<Licnost>();
        public List<Licnost> Supruznici { get; set; } = new List<Licnost>();
        public List<Dogadjaj> Dogadjaji { get; set; } = new List<Dogadjaj>();
    }
}