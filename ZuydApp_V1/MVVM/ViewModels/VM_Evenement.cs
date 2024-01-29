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

        public static void CreateNewEvenement(string name)
        {
            Refresh();
            Evenement evenement = new Evenement();
            evenement.Name = name;
            App.EvenementRepo.SaveEntity(evenement);
            Console.WriteLine(App.EvenementRepo.statusMessage);
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

        public void Savechanges()
        {
            App.EvenementRepo.SaveEntity(Currentevenement);
            Console.WriteLine(App.EvenementRepo.statusMessage);
        }
    }
}
