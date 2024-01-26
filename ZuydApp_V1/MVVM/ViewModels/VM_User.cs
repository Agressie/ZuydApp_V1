using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydApp_V1.MVVM.Models;

namespace ZuydApp_V1.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class VM_User
    {
        public User? Currentuser { get; set; }
        public List<User>? Users = new List<User>();
    }
}
