using Notes.PAGE;
using Notes.MODEL;

namespace Notes;

public partial class MainPage : ContentPage
{
	private users user = new();
	public MainPage()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		
		await user.UserLogin(entrymail.Text, entrypassword.Text);
        await DisplayAlert("NOTICE", "LOGIN SUCCESSFULLY", "OK");
		await Navigation.PushAsync(new HOMEPAGE()); 
    }

	private async void Button_Clicked_1(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new CREATEACCOUNT());
	}
}

