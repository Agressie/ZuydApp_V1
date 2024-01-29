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

        private static void Refresh()
        {
            Activiteiten = App.ActiviteitRepo.GetEntities();
        }
    }
}
