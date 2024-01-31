using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydApp_V1.MVVM.Models
{
    public class UserEvent
    {
        [ForeignKey(typeof(Event))]
        public int EvenementId { get; set; }

        [ForeignKey(typeof(User))]
        public int UserId { get; set;  }
    }
}
