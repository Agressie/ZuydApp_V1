using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydApp_V1.MVVM.Models;

namespace ZuydApp_V1.MVVM.ViewModels
{
    public class VM_Evenement
    {
        public static Evenement? Currentevenement { get; set; }
        public static List<Evenement>? Evenementen = new List<Evenement>();

        // Function to add a new eventement. Make sure to check in Page logic all paremeters are filled and are not NULL!!
        public static void CreateNewEvenement(string name, string description, DateTime dateTime, string location)
        {
            Refresh();
            Evenement evenement = new Evenement();
            evenement.Name = name;
            evenement.description = description;
            evenement.dateTime = dateTime;
            evenement.location = location;
            evenement.users = new List<User>();
            evenement.activities = new List<Activiteit>();
            App.EvenementRepo.SaveEntity(evenement);
            Console.WriteLine(App.EvenementRepo.statusMessage);
            Refresh();
        }

        // Make sure the Event is set before its deleted
        // Deletes the selected Event. (Before you delete an event set it first with the set current event function!!)
        public void DeleteCurrentEventement()
        {
            App.EvenementRepo.DeleteEntity(Currentevenement);
            Console.WriteLine(App.EvenementRepo.statusMessage);
            Refresh();
        }

        // To toggle the publicity status of an event just call this function.
        public void ToggleEvenpublicity()
        {
            Currentevenement.eventpublic = !Currentevenement.eventpublic;
            Savechanges();
        }

        // When you want to make an edit to the Event that is not an User or an Activiteit call this function. When calling make sure you give 4 parameters.
        public void EditEvenement(string name = null, string description = null, DateTime? dateTime = null, string location = null)
        {
            if (name != null)
                Currentevenement.Name = (string)name;
            if (description != null)
                Currentevenement.description = (string)description;
            if (dateTime != null)
                Currentevenement.dateTime = (DateTime)dateTime;
            if (location != null)
                Currentevenement.location = (string)location;
            Savechanges();
        }

        //When you want to Add an Activity call this evefunctionnt.
        public void AddActivity(Activiteit activiteit)
        {
            activiteit.EvenementId = Currentevenement.Id;
            Currentevenement.activities.Add(activiteit);
            Savechanges();
        }
        // When you want to remove an Actvity call this function.
        public void RemoveActivity(Activiteit activiteit)
        {
            Currentevenement.activities.Remove(activiteit);
        }
        // When you want to add an user to an event call this function.
        public void AddUser(User user)
        {
            Currentevenement.users.Add(user);
            user.Evenements.Add(Currentevenement);
            Savechanges();
        }
        // When you want to remove an user to an event call this function.
        public void RemoveUser(User user)
        {
            Currentevenement.users.Remove(user);
            user.Evenements.Remove(Currentevenement);
            Savechanges();
        }

        // When you want to get a list with all event call this function.
        public List<Evenement> GetEvenementen()
        {
            Refresh();
            return Evenementen;
        }
        // When you want one specific event call this function and make sure you give the right Event ID.
        public Evenement GetSpecificEvenement(int id)
        {
            return App.EvenementRepo.GetSpecificEntity(id);
        }

        // Very important function!! When you want to set the current event you call this event.
        public static void SetCurrentEvenement(Evenement evenement)
        {
            Currentevenement = evenement;
        }
        
        // These functions are for the functions above to save and get events.
        private static void Refresh()
        {
            Evenementen = App.EvenementRepo.GetEntities();
        }
        private static void Savechanges()
        {
            App.EvenementRepo.SaveEntity(Currentevenement);
            Console.WriteLine(App.EvenementRepo.statusMessage);
        }
    }
}
