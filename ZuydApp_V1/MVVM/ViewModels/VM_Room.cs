using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydApp_V1.MVVM.Models;

namespace ZuydApp_V1.MVVM.ViewModels
{
    public class VM_Room
    {
        public static Room? CurrentRoom { get; set; }
        public static List<Room>? Rooms = new List<Room>();

        public static void CreateNewRoom(string name)
        {
            Refresh();
            Room room = new Room();
            room.Name = name;
            App.RoomRepo.SaveEntity(room);
            Console.WriteLine(App.RoomRepo.statusMessage);
        }
        public static void DeleteCurrentRoom()
        {
            App.RoomRepo.DeleteEntity(CurrentRoom);
            Console.WriteLine(App.RoomRepo.statusMessage);
            Refresh();
        }
        // When you want to make an edit to the activiteit that is not an User call this function. When calling make sure you give 4 parameters.
        public static void EditActivity(string name = null, string description = null, DateTime? dateTime = null, int? lokaalid = null)
        {
            if (name != null)
                CurrentRoom.Name = (string)name;
            Savechanges();
        }
        // When you want to get a list with all actviteiten call this function.
        public static List<Room> GetRooms()
        {
            Refresh();
            return Rooms;
        }
        // When you want one specific actviteit call this function and make sure you give the right Event ID.
        public static Room GetSpecificRoom(int id)
        {
            return App.RoomRepo.GetSpecificEntity(id);
        }

        // Very important function!! When you want to set the current lokaal you call this event.
        public static void SetCurrentRoom(Room room)
        {
            CurrentRoom = room;
        }

        // These functions are for the functions above to save and get lokalen.
        private static void Refresh()
        {
            Rooms = App.RoomRepo.GetEntities();
        }
        private static void Savechanges()
        {
            App.RoomRepo.SaveEntity(CurrentRoom);
            Console.WriteLine(App.RoomRepo.statusMessage);
        }


        // When you want to add an activiteit to an event call this function.
        public static void AddUndertaking(Undertaking undertaking, bool loop = false)
        {
            if (loop = false)
            {
                VM_Undertaking.SetCurrentUndertaking(undertaking);
                VM_Undertaking.SetLokaal((int)CurrentRoom.Id, true);
            }

            if (CurrentRoom.Undertakings == null)
                CurrentRoom.Undertakings = new List<Undertaking>();

            CurrentRoom.Undertakings.Add(undertaking);
            Savechanges();
        }
        // When you want to remove an user to an actviteit call this function.
        public static void RemoveUndertaking(Undertaking undertaking, bool loop = false)
        {
            if (loop == false)
            {
                VM_Undertaking.SetCurrentUndertaking(undertaking);
                VM_Undertaking.SetLokaal(null, true);
            }
            CurrentRoom.Undertakings.Remove(undertaking);
            Savechanges();
        }
    }
}
