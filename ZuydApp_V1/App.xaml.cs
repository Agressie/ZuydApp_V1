using ZuydApp_V1.Data;
using ZuydApp_V1.MVVM.Models;

namespace ZuydApp_V1
{
    public partial class App : Application
    {
        public static BaseRepo<Undertaking>? UndertakingRepo { get; private set; }
        public static BaseRepo<Event>? EventRepo { get; private set; }
        public static BaseRepo<User>? UserRepo { get; private set; }
        public static BaseRepo<Room>? RoomRepo {  get; private set; }
        public App(BaseRepo<Undertaking> undertakingRepo, BaseRepo<Event> eventRepo, BaseRepo<User> userRepo, BaseRepo<Room> roomRepo)
        {
            InitializeComponent();

            UndertakingRepo = undertakingRepo;
            EventRepo = eventRepo;
            UserRepo = userRepo;
            RoomRepo = roomRepo;
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
