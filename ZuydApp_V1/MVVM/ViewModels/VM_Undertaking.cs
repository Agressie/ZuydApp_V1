using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydApp_V1.MVVM.Models;

namespace ZuydApp_V1.MVVM.ViewModels
{
    public class VM_Undertaking
    {
        public static Undertaking? CurrentUndertaking { get; set; }
        public static List<Undertaking>? Undertakings = new List<Undertaking>();

        // Function to add a new Activiteit. Make sure to check in Page logic all paremeters are filled.
        public static void CreateNewUndertaking(string name, string description, DateTime datetime)
        {
            Refresh();
            Undertaking undertaking = new Undertaking();
            undertaking.Name = name;
            undertaking.Description = description;
            undertaking.DateTime = datetime;
            undertaking.Users = new List<User>();
            App.UndertakingRepo.SaveEntity(undertaking);
            Console.WriteLine(App.UndertakingRepo.statusMessage);
        }

        // Make sure the Activiteit is set before its deleted
        // Deletes the selected Activiteit. (Before you delete an activiteit set it first with the set current activiteit function!!)
        public void DeleteCurrentUndertaking()
        {
            App.UndertakingRepo.DeleteEntity(CurrentUndertaking);
            Console.WriteLine(App.UndertakingRepo.statusMessage);
            Refresh();
        }

        // When you want to make an edit to the activiteit that is not an User call this function. When calling make sure you give 4 parameters.
        public static void EditUndertaking(string name = null, string description = null, DateTime? dateTime = null, int? roomId = null, int? eventId = null)
        {
            if (name != null)
                CurrentUndertaking.Name = (string)name;
            if (description != null)
                CurrentUndertaking.Description = (string)description;
            if (dateTime != null)
                CurrentUndertaking.DateTime = (DateTime)dateTime;
            if (roomId != null)
                if (roomId != CurrentUndertaking.RoomId)
                { 
                    VM_Room.SetCurrentRoom(VM_Room.GetSpecificRoom((int)CurrentUndertaking.RoomId));
                    VM_Room.RemoveUndertaking(CurrentUndertaking);
                    VM_Room.SetCurrentRoom(VM_Room.GetSpecificRoom((int)roomId));
                    VM_Room.AddUndertaking(CurrentUndertaking);
                    CurrentUndertaking.RoomId = (int)roomId;
                }
            if (eventId != null)
                if (eventId != CurrentUndertaking.EventId)
                {
                    VM_Event.SetCurrentEvent(VM_Event.GetSpecificEvent((int)CurrentUndertaking.EventId));
                    VM_Event.RemoveUndertaking(CurrentUndertaking);
                    VM_Event.SetCurrentEvent(VM_Event.GetSpecificEvent((int)eventId));
                    VM_Event.AddUndertaking(CurrentUndertaking);
                    CurrentUndertaking.EventId = (int)eventId;
                }
            Savechanges();
        }

        // When you want to get a list with all actviteiten call this function.
        public List<Undertaking> GetUndertaking()
        {
            Refresh();
            return Undertakings;
        }
        // When you want one specific actviteit call this function and make sure you give the right Event ID.
        public Undertaking GetSpecificUndertaking(int id)
        {
            return App.UndertakingRepo.GetSpecificEntity(id);
        }

        // Very important function!! When you want to set the current actvitieit you call this event.
        public static void SetCurrentUndertaking(Undertaking undertaking)
        {
            CurrentUndertaking = undertaking;
        }

        // These functions are for the functions above to save and get events.
        private static void Refresh()
        {
            Undertakings = App.UndertakingRepo.GetEntities();
        }
        private static void Savechanges()
        {
            App.UndertakingRepo.SaveEntity(CurrentUndertaking);
            Console.WriteLine(App.UndertakingRepo.statusMessage);
        }



        // When you want to add an activiteit to an event call this function.
        public static void AddUser(User user, bool loop = false)
        {
            if (loop == false)
            {
                VM_User.SetCurrentUser(user);
                VM_User.AddUndertaking(CurrentUndertaking, true);
            }
            CurrentUndertaking.Users.Add(user);
            Savechanges();
        }
        // When you want to remove an user to an actviteit call this function.
        public static void RemoveUser(User user, bool loop = false)
        {
            if (loop == false)
            {
                VM_User.SetCurrentUser(user);
                VM_User.RemoveActiviteit(CurrentUndertaking, true);
            }
            CurrentUndertaking.Users.Remove(user);
            Savechanges();
        }

        public static void SetEvent(int? eventId, bool loop = false)
        {
            if (loop == false)
            {
                if (CurrentUndertaking.EventId != null)
                {
                    VM_Event.SetCurrentEvent(VM_Event.GetSpecificEvent((int)CurrentUndertaking.EventId));
                    VM_Event.RemoveUndertaking(CurrentUndertaking, true);
                }                
                VM_Event.SetCurrentEvent(VM_Event.GetSpecificEvent((int)eventId));
                VM_Event.AddUndertaking(CurrentUndertaking, true);
            }
            CurrentUndertaking.EventId = eventId;
            Savechanges();
        }
        public static void SetLokaal(int? roomId, bool loop = false)
        {
            if (loop == false)
            {
                if (CurrentUndertaking.RoomId != null)
                {
                    VM_Room.SetCurrentRoom(VM_Room.GetSpecificRoom((int)CurrentUndertaking.RoomId));
                    VM_Room.RemoveUndertaking(CurrentUndertaking, true);
                }
                VM_Room.SetCurrentRoom(VM_Room.GetSpecificRoom((int)roomId));
                VM_Room.AddUndertaking(CurrentUndertaking, true);
            }
            CurrentUndertaking.RoomId = roomId;
            Savechanges();
        }
    }
}
