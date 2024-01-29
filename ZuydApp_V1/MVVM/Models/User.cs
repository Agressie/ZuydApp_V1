using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydApp_V1.Data;

namespace ZuydApp_V1.MVVM.Models
{
    public class User : Tabledata
    {
        [Column("password")]
        public string Password { get; set; }
    }
}
