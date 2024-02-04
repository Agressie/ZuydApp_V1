using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;
using ZuydApp_V1.MVVM.ViewModels;
using ZuydApp_V1.MVVM.Views;

namespace ZuydApp_V1.API
{
    public class Dijkstra
    {
        private static dynamic pythonModule = Py.Import("Algorithem"); 

        public List<String> PyDijkstra(string start, string end, bool nood, bool handicap)
        {
            return pythonModule.Dijkstra(start, end);
        }
        public static List<String> PyGrafenlijst()
        {
            // This is not working but it's not an priority asof right now.
            //return pythonModule.geefGrafenlijst();
            List<string> Templist = ["B3.305", "B3.317","B3.325"];
            return Templist;
        }

        public static void FirstcreateRooms()
        {
            if (VM_Room.CheckRoomsEmpty() == true)
            {
                List<string> rooms = PyGrafenlijst();
                foreach (string room in rooms)
                {
                    VM_Room.CreateNewRoom(room);
                }
            }
        }
    }
}

