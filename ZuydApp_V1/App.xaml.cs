using SQLite;
using ZuydApp_V1.Data;
using ZuydApp_V1.MVVM.Models;
using ZuydApp_V1.MVVM.Views;

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
            SQLiteConnection connection = new SQLiteConnection(Constants.DBPath, Constants.flags);
            connection.CreateTable<UserEvent>();
            connection.CreateTable<UserUndertaking>();
            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
