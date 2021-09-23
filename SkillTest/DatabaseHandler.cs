﻿using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.Generic;


namespace SkillTest
{
    internal class DatabaseHandler
    {
        // Variables for communicate with the database
        private readonly IFirebaseConfig config;
        private readonly IFirebaseClient client;


        public DatabaseHandler()
        {
            config = new FirebaseConfig
            {
                // Firebase database config variables
                AuthSecret = "K4VnUigpt5m9CJmMTOchcpTWSDpNNBaDHhyWxskt",
                BasePath = "https://szakdolgozat-szentgyorgyitamas-default-rtdb.firebaseio.com/"
            };

            client = new FireSharp.FirebaseClient(config);
        }



        // Check user for login
        public async Task<bool> Login(string userName, string password)
        {
            FirebaseResponse res = await client.GetTaskAsync("users/" + userName);

            try
            {
                User user = res.ResultAs<User>();

                if (user.Password == password)  // If the password is correct
                {
                    return await Task.FromResult<bool>(true);
                }
                else  // If the password is not correct
                {
                    return await Task.FromResult<bool>(false);
                }
            }
            catch  // If the user is nor exists
            {
                return await Task.FromResult<bool>(false);
            }
        }



        // Check, and add user for registration
        public async Task<SetResponse> RegistrateUser(string userName, string password)
        {
            FirebaseResponse userCheck = await client.GetTaskAsync("users/" + userName);

            try
            {
                User user = userCheck.ResultAs<User>();  // If the user is already exists

                MessageBox.Show("Ez a felhasználónév már foglalt!");
                return null;
            }
            catch  // If it is a new user, registrate it
            {
                registrationWriter newUser = new registrationWriter
                {
                    Password = password
                };


                return await client.SetTaskAsync("users/" + userName, newUser);
            }
        }



        // Registrate child
        public async Task<SetResponse> RegistrateChild(string userName, string childName, string id)
        {
            childRegistrationWriter newChild = new childRegistrationWriter
            {
                ID = id
            };


            return await client.SetTaskAsync("results/" + userName + "/" + childName, newChild);
        }



        // Get the results of a user
        public async Task<JObject> getResults(string userName)
        {
            FirebaseResponse res = await client.GetTaskAsync("results/" + userName);
            JObject children = JObject.Parse(res.Body);

            return children;
        }



        // Save the results into the database
        public async Task<SetResponse> SaveResults(string userName, string child, string testType, string result)
        {
            FirebaseResponse res = await client.GetTaskAsync("results/" + userName + "/" + child);

            JObject tests = JObject.Parse(res.Body);

            foreach (KeyValuePair<string, JToken> test in tests)
            {
                if (test.Key.ToString() == testType)
                {
                    string results = test.Value.ToString();
                    results += ('_' + result);

                    if (testType == "Iránytévesztés")
                    {
                        var newResult = new { Iránytévesztés = results };
                        return await client.SetTaskAsync("results/" + userName + "/" + child + "/", newResult);
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            var totalyNewResult = new { Iránytévesztés = result };
            return await client.SetTaskAsync("results/" + userName + "/" + child + "/", totalyNewResult);
        }
    }
}
