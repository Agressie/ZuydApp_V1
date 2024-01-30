using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydApp_V1.MVVM.Models;

namespace ZuydApp_V1.MVVM.ViewModels
{
    public class VM_Activities
    {
        public static Activiteit? Currentactiviteit { get; set; }
        public static List<Activiteit>? Activiteiten = new List<Activiteit>();

        // Function to add a new Activiteit. Make sure to check in Page logic all paremeters are filled.
        public static void CreateNewActiviteit(string name, string description, DateTime datetime)
        {
            Refresh();
            Activiteit activiteit = new Activiteit();
            activiteit.Name = name;
            activiteit.description = description;
            activiteit.dateTime = datetime;
            activiteit.users = new List<User>();
            App.ActiviteitRepo.SaveEntity(activiteit);
            Console.WriteLine(App.ActiviteitRepo.statusMessage);
        }

        // Make sure the Activiteit is set before its deleted
        // Deletes the selected Activiteit. (Before you delete an activiteit set it first with the set current activiteit function!!)
        public void DeleteCurrentActiviteit()
        {
            App.ActiviteitRepo.DeleteEntity(Currentactiviteit);
            Console.WriteLine(App.ActiviteitRepo.statusMessage);
            Refresh();
        }

        // When you want to make an edit to the activiteit that is not an User call this function. When calling make sure you give 4 parameters.
        public static void EditActiviteit(string name = null, string description = null, DateTime? dateTime = null, int? lokaalid = null, int? Eventid = null)
        {
            if (name != null)
                Currentactiviteit.Name = (string)name;
            if (description != null)
                Currentactiviteit.description = (string)description;
            if (dateTime != null)
                Currentactiviteit.dateTime = (DateTime)dateTime;
            if (lokaalid != null)
                if (lokaalid != Currentactiviteit.LokaalId)
                { 
                    VM_Lokaal.SetCurrentLokaal(VM_Lokaal.GetSpecificLokaal((int)Currentactiviteit.LokaalId));
                    VM_Lokaal.RemoveActiviteit(Currentactiviteit);
                    VM_Lokaal.SetCurrentLokaal(VM_Lokaal.GetSpecificLokaal((int)lokaalid));
                    VM_Lokaal.AddActiviteit(Currentactiviteit);
                    Currentactiviteit.LokaalId = (int)lokaalid;
                }
            if (Eventid != null)
                if (Eventid != Currentactiviteit.EvenementId)
                {
                    VM_Evenement.SetCurrentEvenement(VM_Evenement.GetSpecificEvenement((int)Currentactiviteit.EvenementId));
                    VM_Evenement.RemoveActivity(Currentactiviteit);
                    VM_Evenement.SetCurrentEvenement(VM_Evenement.GetSpecificEvenement((int)Eventid));
                    VM_Evenement.AddActivity(Currentactiviteit);
                    Currentactiviteit.EvenementId = (int)Eventid;
                }
            Savechanges();
        }

        // When you want to get a list with all actviteiten call this function.
        public List<Activiteit> GetActiviteit()
        {
            Refresh();
            return Activiteiten;
        }
        // When you want one specific actviteit call this function and make sure you give the right Event ID.
        public Activiteit GetSpecificActiviteit(int id)
        {
            return App.ActiviteitRepo.GetSpecificEntity(id);
        }

        // Very important function!! When you want to set the current actvitieit you call this event.
        public static void SetCurrentActiviteit(Activiteit activiteit)
        {
            Currentactiviteit = activiteit;
        }

        // These functions are for the functions above to save and get events.
        private static void Refresh()
        {
            Activiteiten = App.ActiviteitRepo.GetEntities();
        }
        private static void Savechanges()
        {
            App.ActiviteitRepo.SaveEntity(Currentactiviteit);
            Console.WriteLine(App.ActiviteitRepo.statusMessage);
        }



        // When you want to add an activiteit to an event call this function.
        public static void AddUser(User user, bool loop = false)
        {
            if (loop == false)
            {
                VM_User.SetCurrentUser(user);
                VM_User.AddActiviteit(Currentactiviteit, true);
            }
            Currentactiviteit.users.Add(user);
            Savechanges();
        }
        // When you want to remove an user to an actviteit call this function.
        public static void RemoveUser(User user, bool loop = false)
        {
            if (loop == false)
            {
                VM_User.SetCurrentUser(user);
                VM_User.RemoveActiviteit(Currentactiviteit, true);
            }
            Currentactiviteit.users.Remove(user);
            Savechanges();
        }

        public static void SetEvent(int? eventid, bool loop = false)
        {
            if (loop == false)
            {
                if (Currentactiviteit.EvenementId != null)
                {
                    VM_Evenement.SetCurrentEvenement(VM_Evenement.GetSpecificEvenement((int)Currentactiviteit.EvenementId));
                    VM_Evenement.RemoveActivity(Currentactiviteit, true);
                }                
                VM_Evenement.SetCurrentEvenement(VM_Evenement.GetSpecificEvenement((int)eventid));
                VM_Evenement.AddActivity(Currentactiviteit, true);
            }
            Currentactiviteit.EvenementId = eventid;
            Savechanges();
        }
        public static void SetLokaal(int? lokaalid, bool loop = false)
        {
            if (loop == false)
            {
                if (Currentactiviteit.LokaalId != null)
                {
                    VM_Lokaal.SetCurrentLokaal(VM_Lokaal.GetSpecificLokaal((int)Currentactiviteit.LokaalId));
                    VM_Lokaal.RemoveActiviteit(Currentactiviteit, true);
                }
                VM_Lokaal.SetCurrentLokaal(VM_Lokaal.GetSpecificLokaal((int)lokaalid));
                VM_Lokaal.AddActiviteit(Currentactiviteit, true);
            }
            Currentactiviteit.LokaalId = lokaalid;
            Savechanges();
        }
    }
}
