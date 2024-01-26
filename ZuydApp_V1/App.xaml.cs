using ZuydApp_V1.Data;
using ZuydApp_V1.MVVM.Models;

namespace ZuydApp_V1
{
    public partial class App : Application
    {
        public static BaseRepo<Activiteit>? ActiviteitRepo { get; private set; }
        public static BaseRepo<Evenement>? EvenementRepo { get; private set; }
        public static BaseRepo<User>? UserRepo { get; private set; }
        public App(BaseRepo<Activiteit>? activiteitRepo, BaseRepo<Evenement>? evenementRepo, BaseRepo<User>? userRepo)
        {
            InitializeComponent();

            ActiviteitRepo = activiteitRepo;
            EvenementRepo = evenementRepo;
            UserRepo = userRepo;
            MainPage = new AppShell();
            MainPage = new AppShell();
        }
    }
}
