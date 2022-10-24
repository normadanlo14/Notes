using Notes.MODEL;
using static Notes.App;


namespace Notes.PAGE;

public partial class EDITPAGE : ContentPage
{
	private users user = new();
	public EDITPAGE()
	{
		InitializeComponent();

	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		title.Text = Titles;
		writer.Text = Writers;
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}

	private async void Button_Clicked_1(object sender, EventArgs e)
	{
		await user.editdata(title.Text,writer.Text);
		await DisplayAlert("NOTICE", "UPDATED SUCCESSFULLY", "OK"); 
	}
}