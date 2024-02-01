using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;
using (Py.GIL());

namespace ZuydApp_V1.API
{
    public class Dijkstra
    {
        public void getpy()
        {
            dynamic pythonModule = Py.Import("Algorithem"); // Vervang dit door de naam van jouw .py-bestand zonder de extensie
            pythonModule; // Vervang 'jouw_methode' door de naam van de methode die je wilt aanroepen

        }
    }
}

