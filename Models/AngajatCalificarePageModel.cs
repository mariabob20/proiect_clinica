using Microsoft.AspNetCore.Mvc.RazorPages;
using proiect_clinica.Data;

namespace proiect_clinica.Models
{
    public class AngajatCalificarePageModel : PageModel
    {
        public List<AssignedCalificare> AssignedCalificareList;

        public void PopulateAssignedCalificare(proiect_clinicaContext context, Angajat angajat)
        {
            // Verifică dacă colecția AngajatCalificari este null și inițializează-o dacă este cazul
            if (angajat.AngajatCalificari == null)
            {
                angajat.AngajatCalificari = new List<AngajatCalificare>();
            }

            var allCalificari = context.Calificare;
            var angajatCalificari = new HashSet<int>(angajat.AngajatCalificari.Select(c => c.CalificareID));

            AssignedCalificareList = new List<AssignedCalificare>();
            foreach (var cal in allCalificari)
            {
                AssignedCalificareList.Add(new AssignedCalificare
                {
                    CalificareID = cal.ID,
                    Tip = cal.CalificareTip,
                    Assigned = angajatCalificari.Contains(cal.ID)
                });
            }
        }

        public void UpdateAngajatCalificare(proiect_clinicaContext context,
            string[] selectedCalificari, Angajat angajatToUpdate)
        {
            // Verifică dacă selectedCalificari este null și inițializează colecția AngajatCalificari dacă este cazul
            if (selectedCalificari == null)
            {
                angajatToUpdate.AngajatCalificari = new List<AngajatCalificare>();
                return;
            }

            var selectedCalificariHS = new HashSet<string>(selectedCalificari);
            var angajatCalificari = new HashSet<int>(angajatToUpdate.AngajatCalificari.Select(c => c.Calificare.ID));

            foreach (var cal in context.Calificare)
            {
                if (selectedCalificariHS.Contains(cal.ID.ToString()))
                {
                    if (!angajatCalificari.Contains(cal.ID))
                    {
                        angajatToUpdate.AngajatCalificari.Add(
                            new AngajatCalificare
                            {
                                AngajatID = angajatToUpdate.ID,
                                CalificareID = cal.ID
                            });
                    }
                }
                else
                {
                    if (angajatCalificari.Contains(cal.ID))
                    {
                        AngajatCalificare calificareToRemove = angajatToUpdate
                            .AngajatCalificari
                            .SingleOrDefault(i => i.CalificareID == cal.ID);

                        if (calificareToRemove != null)
                            context.Remove(calificareToRemove);
                    }
                }
            }
        }
    }
}
