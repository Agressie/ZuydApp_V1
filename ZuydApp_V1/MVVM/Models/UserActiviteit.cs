﻿using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydApp_V1.Data;

namespace ZuydApp_V1.MVVM.Models
{
    public class UserActviteit : Tabledata
    {
        [ForeignKey(typeof(Activiteit))]
        public int ActiviteitId { get; set; }

        [ForeignKey(typeof(User))]
        public int UserId { get; set; }
    }
}
