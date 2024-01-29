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

        public List<string>? weather {  get; set; } // When API is added edit comment to show wich index is wich value.


        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Activiteit> activities { get; set; }


        [ManyToMany((typeof(UserEvent)), CascadeOperations = CascadeOperation.All)]
        public List<User> users {  get; set; }
        
    }
}
