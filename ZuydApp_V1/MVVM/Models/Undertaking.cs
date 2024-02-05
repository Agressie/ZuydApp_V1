using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydApp_V1.MVVM.Models;
using ZuydApp_V1.Data;
using System.Diagnostics.CodeAnalysis;

namespace ZuydApp_V1.MVVM.Models
{
    [Table("Undertaking")]
    public class Undertaking : Tabledata
    {
        public string Description { get; set; }

        public DateTime DateTime { get; set; }


        [ForeignKey(typeof(Event))]
        public int? EventId { get; set; }

        [ForeignKey(typeof(Room))]
        public int? RoomId { get; set; }


        [ManyToMany((typeof(UserUndertaking)), CascadeOperations = CascadeOperation.All)]
        public List<User> Users { get; set; }
    }
}
