using Notes.MODEL;


namespace Notes.PAGE;

public partial class CREATEACCOUNT : ContentPage
{
	private users user = new();
	public CREATEACCOUNT()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		
		await user.AddUser(entryfname.Text, entrylname.Text, entryEmail.Text, entrypass.Text,entrytitle.Text,entrymessage.Text);
		
        await DisplayAlert("NOTICE", "ACCOUNT SUCCESSFULLY CREATED", "OK");
    }

	private async void Button_Clicked_1(object sender, EventArgs e)
	{
		await Navigation.PopAsync();				
	}
}