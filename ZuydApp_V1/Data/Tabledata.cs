using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydApp_V1.Data
{
    public class Tabledata
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("name"), Indexed, NotNull]
        public string? Name { get; set; }
    }
}
