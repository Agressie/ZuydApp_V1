using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydApp_V1.MVVM.Models;

namespace ZuydApp_V1.MVVM.ViewModels
{
    public class VM_Lokaal
    {
        public static Lokaal? Currentlokaal { get; set; }
        public static List<Lokaal>? Lokalen = new List<Lokaal>();

        public static void CreateNewLokaal(string name, string lokaal)
        {
            Refresh();
            Lokaal newlokaal = new Lokaal();
            newlokaal.Name = name;
            newlokaal.Name = lokaal;
            App.LokaalRepo.SaveEntity(newlokaal);
            Console.WriteLine(App.LokaalRepo.statusMessage);
        }
        public static void DeleteCurrentLokaal()
        {
            App.LokaalRepo.DeleteEntity(Currentlokaal);
            Console.WriteLine(App.LokaalRepo.statusMessage);
            Refresh();
        }
        // When you want to make an edit to the activiteit that is not an User call this function. When calling make sure you give 4 parameters.
        public static void EditActiviteit(string name = null, string description = null, DateTime? dateTime = null, int? lokaalid = null)
        {
            if (name != null)
                Currentlokaal.Name = (string)name;
            Savechanges();
        }
        // When you want to get a list with all actviteiten call this function.
        public static List<Lokaal> GetLokalen()
        {
            Refresh();
            return Lokalen;
        }
        // When you want one specific actviteit call this function and make sure you give the right Event ID.
        public static Lokaal GetSpecificLokaal(int id)
        {
            return App.LokaalRepo.GetSpecificEntity(id);
        }

        // Very important function!! When you want to set the current lokaal you call this event.
        public static void SetCurrentLokaal(Lokaal lokaal)
        {
            Currentlokaal = lokaal;
        }

        // These functions are for the functions above to save and get lokalen.
        private static void Refresh()
        {
            Lokalen = App.LokaalRepo.GetEntities();
        }
        private static void Savechanges()
        {
            App.LokaalRepo.SaveEntity(Currentlokaal);
            Console.WriteLine(App.LokaalRepo.statusMessage);
        }


        // When you want to add an activiteit to an event call this function.
        public static void AddActiviteit(Activiteit activiteit, bool loop = false)
        {
            if (loop = false)
            {
                VM_Activities.SetCurrentActiviteit(activiteit);
                VM_Activities.SetLokaal((int)Currentlokaal.Id, true);
            }
            Currentlokaal.activiteiten.Add(activiteit);
            Savechanges();
        }
        // When you want to remove an user to an actviteit call this function.
        public static void RemoveActiviteit(Activiteit activiteit, bool loop = false)
        {
            if (loop == false)
            {
                VM_Activities.SetCurrentActiviteit(activiteit);
                VM_Activities.SetLokaal(null, true);
            }
            Currentlokaal.activiteiten.Remove(activiteit);
            Savechanges();
        }
    }
}
