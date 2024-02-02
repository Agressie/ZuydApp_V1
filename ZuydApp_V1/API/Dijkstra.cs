using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;

namespace ZuydApp_V1.API
{
    public class Dijkstra
    {
        private static dynamic pythonModule = Py.Import("Algorithem"); 

        public List<String> PyDijkstra(string start, string end, bool nood, bool handicap)
        {
            return pythonModule.Dijkstra(start, end);
        }
        public List<String> PyGrafenlijst()
        {
            return pythonModule.Grafenlijst();
        }
    }
}

