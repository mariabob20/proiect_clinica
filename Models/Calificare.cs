namespace proiect_clinica.Models
{
    public class Calificare
    {
        public int ID { get; set; }
        public string CalificareTip { get; set; }
        public ICollection<AngajatCalificare>? AngajatCalificari { get; set; }
    }
}
