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

        public static void CreateNewEvenement(string name)
        {
            Refresh();
            Activiteit activiteit = new Activiteit();
            activiteit.Name = name;
            App.ActiviteitRepo.SaveEntity(activiteit);
            Console.WriteLine(App.ActiviteitRepo.statusMessage);
        }

        private static void Refresh()
        {
            Activiteiten = App.ActiviteitRepo.GetEntities();
        }
    }
}
