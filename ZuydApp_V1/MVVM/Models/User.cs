using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydApp_V1.MVVM.Models;
using ZuydApp_V1.Data;

namespace ZuydApp_V1.MVVM.Models
{
    [Table("User")]
    public class User : Tabledata
    {
        public string? Password { get; set; }

        [ManyToMany((typeof(UserEvent)), CascadeOperations = CascadeOperation.All)]
        public List<Event>? Events {  get; set; }

        [ManyToMany((typeof(UserUndertaking)), CascadeOperations = CascadeOperation.All)]
        public List<Undertaking>? Undertakings { get; set; }
    }
}
