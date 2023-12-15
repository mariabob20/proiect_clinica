using System.ComponentModel.DataAnnotations;

namespace proiect_clinica.Models
{
    public class AssignedCalificare
    {
        public int CalificareID { get; set; }
        [Display(Name = "Tipul Calificarii")]
        public string Tip { get; set; }
        public bool Assigned { get; set; }
    }
}
