using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydApp_V1.MVVM.Models
{
    public class Evenement : Tabledata
    {
        [Column("activities")]
        public List<Activiteit> activities { get; set; }
    }
}
