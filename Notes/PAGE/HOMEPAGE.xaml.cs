using Notes.MODEL;
using Notes.PAGE;


namespace Notes.PAGE;

public partial class HOMEPAGE : ContentPage
{
	private users user = new();
	public HOMEPAGE()
	{
		InitializeComponent();
		ListUsers.ItemsSource = user.GetUserList();
	}

	private async void edititem_Clicked(object sender, EventArgs e)
	{
        if (!string.IsNullOrEmpty(App.key))
        {
            await Navigation.PushAsync(new EDITPAGE());
        }
        else
        {
            await DisplayAlert("Data", "Please Select a Data to modify! ", "Got it!");
        }
    }

	private async void ListUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
        App.Emails = (e.CurrentSelection.FirstOrDefault() as users)?.email;
        App.key = await user.GetUserKey(App.Emails);
    }

    private async void BTN_delete_Clicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Alert", "Are You Sure to Delete", "YES", "NO");
        if (result)
        {
            await user.Deletedata();
            return;

        }
    }
}