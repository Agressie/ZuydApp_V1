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
    [Table("Event")]
    public class Event : Tabledata
    {
        public string? Description { get; set; }

        public bool EventPublic { get; set; } = false;

        public DateTime DateTime { get; set; }

        public string? Location { get; set; }


        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Undertaking>? Undertakings { get; set; }


        [ManyToMany((typeof(UserEvent)), CascadeOperations = CascadeOperation.All)]
        public List<User>? Users {  get; set; }
        
    }
}
