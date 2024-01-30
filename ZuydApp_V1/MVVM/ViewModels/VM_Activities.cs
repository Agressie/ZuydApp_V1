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
        public static void CreateNewActiviteit(string name, string description, DateTime datetime, int lokaalid)
        {
            Refresh();
            Activiteit activiteit = new Activiteit();
            activiteit.Name = name;
            activiteit.description = description;
            activiteit.dateTime = datetime;
            activiteit.LokaalId = lokaalid;
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
        public void EditActiviteit(string name = null, string description = null, DateTime? dateTime = null, int? lokaalid = null)
        {
            if (name != null)
                Currentactiviteit.Name = (string)name;
            if (description != null)
                Currentactiviteit.description = (string)description;
            if (dateTime != null)
                Currentactiviteit.dateTime = (DateTime)dateTime;
            if (lokaalid != null)
                Currentactiviteit.LokaalId = (int)lokaalid;
            Savechanges();
        }
        // When you want to add an activiteit to an event call this function.
        public void AddUser(User user)
        {
            Currentactiviteit.users.Add(user);
            Savechanges();
        }
        // When you want to remove an user to an actviteit call this function.
        public void RemoveUser(User user)
        {
            Currentactiviteit.users.Remove(user);
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
    }
}
