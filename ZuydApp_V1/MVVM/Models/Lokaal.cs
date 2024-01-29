using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydApp_V1.Data;

namespace ZuydApp_V1.MVVM.Models
{
    [Table("Lokaal")]
    public class Lokaal : Tabledata
    {
        public string lokaal {  get; set; }
    }
}
