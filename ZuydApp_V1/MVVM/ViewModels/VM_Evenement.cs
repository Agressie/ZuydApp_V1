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

        public static void CreateNewEvenement(string name, string description)
        {
            Refresh();
            Evenement evenement = new Evenement();
            evenement.Name = name;
            evenement.description = description;
            App.EvenementRepo.SaveEntity(evenement);
            Console.WriteLine(App.EvenementRepo.statusMessage);
            Refresh();
        }

        // Make sure the Event is set before its deleted
        public void DeleteCurrentEventement()
        {
            App.EvenementRepo.DeleteEntity(Currentevenement);
            Console.WriteLine(App.EvenementRepo.statusMessage);
            Refresh();
        }

        private static void Refresh()
        {
            Evenementen = App.EvenementRepo.GetEntities();
        }

        public void ToggleEvenpublicity()
        {
            Currentevenement.eventpublic = !Currentevenement.eventpublic;
            Savechanges();
        }

        public void EditEvenement(string name = null, string description = null, DateTime? dateTime = null, string locatie = null)
        {
            if (name != null)
                Currentevenement.Name = (string)name;
            if (description != null)
                Currentevenement.description = (string)description;
            if (dateTime != null)
                Currentevenement.dateTime = (DateTime)dateTime;
            if (locatie != null)
                Currentevenement.location = (string)locatie;
            Savechanges();
        }
        public void AddActivity(Activiteit activiteit)
        {
            Currentevenement.activities.Add(activiteit);
            Savechanges();
        }
        public void RemoveActivity(Activiteit activiteit)
        {
            Currentevenement.activities.Remove(activiteit);
        }
        public void AddUser(User user)
        {
            Currentevenement.users.Add(user);
            Savechanges();
        }
        public void RemoveUser(User user)
        {
            Currentevenement.users.Remove(user);
            Savechanges();
        }

        public void Savechanges()
        {
            App.EvenementRepo.SaveEntity(Currentevenement);
            Console.WriteLine(App.EvenementRepo.statusMessage);
        }

        public List<Evenement> GetEvenementen()
        {
            Refresh();
            return Evenementen;
        }

        public Evenement GetSpecificEvenement(int id)
        {
            return App.EvenementRepo.GetSpecificEntity(id);
        }

        public static void SetCurrentEvenement(Evenement evenement)
        {
            Currentevenement = evenement;
        }
    }
}
