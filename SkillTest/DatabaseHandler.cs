using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Threading.Tasks;
using System.Windows;

namespace SkillTest
{
    class DatabaseHandler
    {
        private readonly IFirebaseConfig config;
        private readonly IFirebaseClient client;


        public DatabaseHandler()
        {
            config = new FirebaseConfig
            {
                AuthSecret = "Qqb6EFq6SqsPE6IeUxq1Oi8iVl4Qs1zC04uRsiEC",
                BasePath = "https://szentgyorgyitamas-szakdolgozat-default-rtdb.europe-west1.firebasedatabase.app/"
            };

            client = new FireSharp.FirebaseClient(config);
        }



        public async Task<bool> Login(string userName, string password)
        {
            FirebaseResponse res = await client.GetTaskAsync("users/" + userName);

            try
            {
                User user = res.ResultAs<User>();

                if (user.Password == password)
                {
                    return await Task.FromResult<bool>(true);
                }
                else
                {
                    return await Task.FromResult<bool>(false);
                }
            }
            catch
            {
                return await Task.FromResult<bool>(false);
            }
        }



        public async Task<SetResponse> RegistrateUser(string userName, string password)
        {
            FirebaseResponse userCheck = await client.GetTaskAsync("users/" + userName);

            try
            {
                User user = userCheck.ResultAs<User>();

                MessageBox.Show("Ez a felhasználónév már foglalt!");
                return null;
            }
            catch
            {
                registrationWriter newUser = new registrationWriter
                {
                    Password = password
                };


                return await client.SetTaskAsync("users/" + userName, newUser);
            }
        }
    }
}
