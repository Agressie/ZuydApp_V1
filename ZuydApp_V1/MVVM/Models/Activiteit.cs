using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydApp_V1.MVVM.Models
{
    internal class Activiteit
    {
        [Column("lokaal")]
        public Lokaal lokaal {  get; set; }
    }
}
