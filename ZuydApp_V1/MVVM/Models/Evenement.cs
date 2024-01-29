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
    [Table("Evenement")]
    public class Evenement : Tabledata
    {
        public string? description { get; set; }

        public bool eventpublic { get; set; } = false;

        public DateTime dateTime { get; set; }

        public Dictionary<string,> Weather { get; set; }


        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Activiteit> activities { get; set; }


        [ManyToMany((typeof(UserEvent)), CascadeOperations = CascadeOperation.All)]
        public List<User> users {  get; set; }
        
    }
}
