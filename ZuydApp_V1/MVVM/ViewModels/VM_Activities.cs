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

        public void DeleteCurrentActiviteit()
        {
            App.ActiviteitRepo.DeleteEntity(Currentactiviteit);
            Console.WriteLine(App.ActiviteitRepo.statusMessage);
            Refresh();
        }

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
