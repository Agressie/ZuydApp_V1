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
    [Table("Room")]
    public class Room : Tabledata
    {
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Undertaking>? Undertakings { get; set; }
    }
}
