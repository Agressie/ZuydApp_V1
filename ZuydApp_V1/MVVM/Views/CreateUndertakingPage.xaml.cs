using ZuydApp_V1.MVVM.ViewModels;
using ZuydApp_V1.MVVM.Models;
using ZuydApp_V1.API;

namespace ZuydApp_V1.MVVM.Views;

public partial class CreateUndertakingPage : ContentPage
{
	public CreateUndertakingPage()
	{
		InitializeComponent();
    }

	public void OnCreateUndertakingClicked(object sender, EventArgs e)
	{
        var titleempty = string.IsNullOrEmpty(Entrytitle.Text);
        var locationempty = string.IsNullOrEmpty(EntryRoom.Text);
        var descriptionempty = string.IsNullOrEmpty(EditorDescription.Text);
        DateTime dateTime = DateTime.Now;
        List<Room> rooms = VM_Room.GetRooms();
        foreach (Room room in rooms)
        {
            if (room.Name == EntryRoom.Text)
            {
                if (titleempty == false && locationempty == false && descriptionempty == false)
                    if (EditorDescription.Text.Count() < 250)
                    {
                        VM_Undertaking.CreateNewUndertaking(Entrytitle.Text, EditorDescription.Text, dateTime);
                        VM_Undertaking.SetEvent(VM_Event.CurrentEvent.Id);
                        VM_Undertaking.SetLokaal(room.Id);
                        Navigation.PopAsync();
                    }
            }
            else
            {
                Roominvalid.IsVisible = true;
            }
        }  
    }
}