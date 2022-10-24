using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using static Notes.App;

namespace Notes.MODEL
{
    public class users
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string Title { get; set; }
        public string Write { get; set; }



        public async Task<bool> AddUser(string fname, string lname, string mail, string pword, string tile ,string write)
        {
            try
            {
                var evaluateEmail = (await Client.Child("Users")
                    .OnceAsync<users>())
                    .FirstOrDefault(a => a.Object.email == mail);

                if (evaluateEmail == null)
                {
                    var user = new users()
                    {
                        firstname = fname,
                        lastname = lname,
                        email = mail,
                        password = pword,
                        Title = tile,
                        Write = write
                    };
                    await Client.Child("Users").PostAsync(user);
                    Client.Dispose();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        public async Task<bool> UserLogin(string Email, string Pass)
        {
            try
            {
                var evaluateEmail = (await Client.Child("Users")
                                  .OnceAsync<users>())
                                  .FirstOrDefault
                                  (a => a.Object.email == Email &&
                                   a.Object.password == Pass);
                return evaluateEmail != null;
            }
            catch
            {
                return false;
            }

        }
        public async Task<string> GetUserKey(string mail)
        {
            try
            {
                var getuserkey = (await Client.Child("Users").OnceAsync<users>()).
                    FirstOrDefault(a => a.Object.email == mail);
                if (getuserkey == null) return null;

                Firstname = getuserkey.Object.firstname;
                Lastname = getuserkey.Object.lastname;
                Password = getuserkey.Object.password;
                Titles = getuserkey.Object.Title;
                Writers = getuserkey.Object.Write;

                return getuserkey?.Key;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        public async Task<bool> editdata(string title, string write)
        {
            try
            {
                var evaluteuser = (await Client
                    .Child("Users")
                    .OnceAsync<users>())
                    .FirstOrDefault
                    (a => a.Object.email == Emails);
                if (evaluteuser != null)
                {
                    users user = new users
                    {
                        email = Emails,
                        firstname = Firstname,
                        lastname = Lastname,
                        Write = write,
                        Title = title,
                        password = Password
                    };
                    await Client.Child("Users").Child(key).PatchAsync(user);
                    Client.Dispose();
                }
                Client.Dispose();
                return false;
            }
            catch (Exception ex)
            {
                Client.Dispose();
                return false;
            }
        }

        public async Task<string> Deletedata()
        {
            try
            {
                await Client
                    .Child($"Users/{key}")
                    .DeleteAsync();
                return "removed";
            }
            catch (Exception ex)
            {
                return " error";
            }
        }





        public ObservableCollection<users> GetUserList()
        {
            var userlist = Client
                 .Child("Users")
                .AsObservable<users>()
                .AsObservableCollection();
            return userlist;

        }

    }
}

