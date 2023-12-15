namespace proiect_clinica.Models
{
    public class AngajatCalificare
    {
        public int ID { get; set; }
        public int AngajatID { get; set; }
        public Angajat Angajat { get; set; }
        public int CalificareID { get; set; }
        public Calificare Calificare { get; set; }
    }
}
