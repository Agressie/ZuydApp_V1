using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydApp_V1.MVVM.Models;

namespace ZuydApp_V1.MVVM.ViewModels
{
    public class VM_Event
    {
        public static Event? CurrentEvent { get; set; }
        public static List<Event>? Events = new List<Event>();

        // Function to add a new eventement. Make sure to check in Page logic all paremeters are filled and are not NULL!!
        public static void CreateNewEvent(string name, string description, DateTime dateTime, string location)
        {
            Refresh();
            Event @event = new Event();
            @event.Name = name;
            @event.Description = description;
            @event.DateTime = dateTime;
            @event.Location = location;
            @event.Users = new List<User>();
            @event.Undertakings = new List<Undertaking>();
            App.EventRepo.SaveEntity(@event);
            CurrentEvent = @event;
            Console.WriteLine(App.EventRepo.statusMessage);
            Refresh();
        }

        // Make sure the Event is set before its deleted
        // Deletes the selected Event. (Before you delete an event set it first with the set current event function!!)
        public static void DeleteCurrentEvent()
        {
            App.EventRepo.DeleteEntity(CurrentEvent);
            Console.WriteLine(App.EventRepo.statusMessage);
            Refresh();
        }

        // To toggle the publicity status of an event just call this function.
        public static void ToggleEventPublicity()
        {
            CurrentEvent.EventPublic = !CurrentEvent.EventPublic;
            Savechanges();
        }

        // When you want to make an edit to the Event that is not an User or an Activiteit call this function. When calling make sure you give 4 parameters.
        public static void EditEvent(string name = null, string description = null, DateTime? dateTime = null, string location = null)
        {
            if (name != null)
                CurrentEvent.Name = (string)name;
            if (description != null)
                CurrentEvent.Description = (string)description;
            if (dateTime != null)
                CurrentEvent.DateTime = (DateTime)dateTime;
            if (location != null)
                CurrentEvent.Location = (string)location;
            Savechanges();
        }

        // When you want to get a list with all event call this function.
        public static List<Event> GetEvent()
        {
            Refresh();
            return Events;
        }
        // When you want one specific event call this function and make sure you give the right Event ID.
        public static Event GetSpecificEvent(int id)
        {
            return App.EventRepo.GetSpecificEntity(id);
        }

        // Very important function!! When you want to set the current event you call this event.
        public static void SetCurrentEvent(Event @event)
        {
            CurrentEvent = @event;
        }
        
        // These functions are for the functions above to save and get events.
        private static void Refresh()
        {
            Events = App.EventRepo.GetEntitiesWithChildren();
        }
        private static void Savechanges()
        {
            App.EventRepo.SaveEntityWithChildren(CurrentEvent);
            Console.WriteLine(App.EventRepo.statusMessage);
        }



        public static void AddUndertaking(Undertaking undertaking, bool loop = false)
        {
            if (loop = false)
            {
                VM_Undertaking.SetCurrentUndertaking(undertaking);
                VM_Undertaking.SetEvent((int)CurrentEvent.Id, true);
            }

            if (CurrentEvent.Undertakings == null)
                CurrentEvent.Undertakings = new List<Undertaking>();

            CurrentEvent.Undertakings.Add(undertaking);
            Savechanges();
        }

        public static void RemoveUndertaking(Undertaking undertaking, bool loop = false)
        {
            if (loop == false)
            {
                VM_Undertaking.SetCurrentUndertaking(undertaking);
                VM_Undertaking.SetEvent(null, true);
            }

            CurrentEvent.Undertakings.Remove(undertaking);
            Savechanges();
        }

        public static void AddUser(User user, bool loop = false)
        {
            if (loop == false) 
            {
                VM_User.SetCurrentUser(user);
                VM_User.AddEvent(CurrentEvent, true);
            }

            if (CurrentEvent.Users == null)
                CurrentEvent.Users = new List<User>();

            CurrentEvent.Users.Add(user);
            Savechanges();
        }

        public static void RemoveUser(User user, bool loop = false)
        {
            if (loop == false)
            {
                VM_User.SetCurrentUser(user);
                VM_User.RemoveEvent(CurrentEvent, true);
            }
            CurrentEvent.Users.Remove(user);
            Savechanges();
        }
    }
}
