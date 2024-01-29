using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydApp_V1.Data;

namespace ZuydApp_V1.MVVM.Models
{
    [Table("Lokalen")]
    public class Lokaal : Tabledata
    {
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Activiteit> activiteiten { get; set; }
    }
}
