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
        public static User? Currentuser { get; set; }
        public static List<User>? Users = new List<User>();

        // Function to add a new user. Make sure to check in Page logic all paremeters are filled and are not NULL!!
        public static void CreateNewUser(string username, string password)
        {
            Refresh();
            User user = new User();
            user.Name = username;
            user.Password = password;
            user.Evenements = new List<Evenement>();
            App.UserRepo.SaveEntity(user);
            Console.WriteLine(App.UserRepo.statusMessage);
        }

        // Make sure the user is set before its deleted
        // Deletes the selected user. (Before you delete an user set it first with the set current user function!!)
        public void DeleteCurrentUser()
        {
            App.UserRepo.DeleteEntity(Currentuser);
            Console.WriteLine(App.UserRepo.statusMessage);
            Refresh();
        }

        // Function to check username and or password.
        // True == Username check, False == Login check
        public static bool LoginCheckandUsernameCheck(bool type, string username, string password = null)
        {
            Refresh();
            bool result = false;
            foreach (var user in Users)
            {
                if (user.Name == username)
                    if (type == true)
                        result = true;
                    else if (type == false)
                        if (user.Password == password)
                        {
                            result = true;
                            SetCurrentUser(user);
                        }
            }
            return result;
        }

        // When you want to get a list with all users call this function.
        public List<User> GetUsers()
        {
            Refresh();
            return Users;
        }
        // When you want one specific user call this function and make sure you give the right user ID.
        public User GetSpecificUser(int id)
        {
            return App.UserRepo.GetSpecificEntity(id);
        }

        // Very important function!! When you want to set the current user you call this event.
        public static void SetCurrentUser(User user)
        {
            Currentuser = user;
        }

        // These functions are for the functions above to save and get events.
        private static void Refresh()
        {
            Users = App.UserRepo.GetEntities();
        }
        private static void Savechanges()
        {
            App.UserRepo.SaveEntity(Currentuser);
            Console.WriteLine(App.UserRepo.statusMessage);
        }
    }
}
