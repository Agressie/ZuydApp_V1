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
    [Table("Activiteit")]
    public class Activiteit : Tabledata
    {
        public string description { get; set; }

        public DateTime dateTime { get; set; }


        [ForeignKey(typeof(Evenement))]
        public int? EvenementId { get; set; }

        [ForeignKey(typeof(Lokaal))]
        public int? LokaalId { get; set; }


        [ManyToMany((typeof(UserActviteit)), CascadeOperations = CascadeOperation.All)]
        public List<User> users { get; set; }
    }
}
