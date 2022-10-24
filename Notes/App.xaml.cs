using Firebase.Database;

namespace Notes;

public partial class App : Application
{

	public static FirebaseClient Client = new("https://notes-bc310-default-rtdb.asia-southeast1.firebasedatabase.app/");
	public static string key, Emails,Firstname,Lastname,Titles,Writers,Password;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
