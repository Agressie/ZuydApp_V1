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

        private static void Refresh()
        {
            Lokalen = App.LokaalRepo.GetEntities();
        }
    }
}
