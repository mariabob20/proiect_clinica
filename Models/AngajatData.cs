namespace proiect_clinica.Models
{
    public class AngajatData
    {
        public IEnumerable<Angajat> Angajati { get; set; }
        public IEnumerable<Calificare> Calificari { get; set; }
        public IEnumerable<AngajatCalificare> AngajatCalificari { get; set; }
    }
}
