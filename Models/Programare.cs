using proiect_clinica.Models;
using System.ComponentModel.DataAnnotations;

public class Programare
{
    public int ID { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Data Programare")]
    public DateTime Data { get; set; }

    // Cheia străină pentru Client
    public int? ClientID { get; set; }
    // Proprietatea de navigare pentru Client
    public Client? Client { get; set; }

    // Proprietățile existente pentru Serviciu rămân neschimbate
    public int? ServiciuID { get; set; }
    public Serviciu? Serviciu { get; set; }
}
