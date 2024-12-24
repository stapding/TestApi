using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAbonents.Models;

namespace WpfAppAbonents
{
    public class Api
    {
        public static async Task<User?> Auth(string email, string password)
        {
            using(var client = new HttpClient())
            {
                var result = client.GetAsync($"http://localhost:5179/User/auth/{email},{password}").Result;
                return result.StatusCode == System.Net.HttpStatusCode.OK
                    ? JsonConvert.DeserializeObject<User>(await result.Content.ReadAsStringAsync())
                    : null;
            }
        }

        public static async Task<User> Register(string name, string email, string password)
        {
            var user = new User
            {
                Name = name,
                Email = email,
                Password = password,
                Role = "user"
            };

            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var respone = await client.PostAsync("http://localhost:5179/User/register", content);
                respone.EnsureSuccessStatusCode();

                var responseContent = await respone.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(responseContent);
            }
        }

        public static async Task<List<Abonent>> GetAbonents()
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync($"http://localhost:5179/Abonent").Result;
                return result.StatusCode == System.Net.HttpStatusCode.OK
                    ? JsonConvert.DeserializeObject<List<Abonent>>(await result.Content.ReadAsStringAsync())
                    : null;
            }
        }

        public static async Task<List<Abonent>> SearchSurnameAbonents(string toSearch)
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync($"http://localhost:5179/Abonent/search/surname/{toSearch}").Result;
                return result.StatusCode == System.Net.HttpStatusCode.OK
                    ? JsonConvert.DeserializeObject<List<Abonent>>(await result.Content.ReadAsStringAsync())
                    : null;
            }
        }

        public static async Task<List<Abonent>> SearchPhoneAbonents(string toSearch)
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync($"http://localhost:5179/Abonent/search/phone/{toSearch}").Result;
                return result.StatusCode == System.Net.HttpStatusCode.OK
                    ? JsonConvert.DeserializeObject<List<Abonent>>(await result.Content.ReadAsStringAsync())
                    : null;
            }
        }

        public static async Task<Abonent> AddAbonent(string name, string phone, string address, string surname, string pochta, string patronymic)
        {
            var abonent = new Abonent
            {
                Name = name,
                Phone = phone,
                Address = address,
                Surname = surname,
                Pochta = pochta,
                Patronymic = patronymic
            };

            var json = JsonConvert.SerializeObject(abonent);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var respone = await client.PostAsync("http://localhost:5179/Abonent", content);
                respone.EnsureSuccessStatusCode();

                var responseContent = await respone.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Abonent>(responseContent);
            }
        }

        public static async Task<Abonent> EditAbonent(int id, string name, string phone, string address, string surname, string pochta, string patronymic)
        {
            var abonent = new Abonent
            {
                Name = name,
                Phone = phone,
                Address = address,
                Surname = surname,
                Pochta = pochta,
                Patronymic = patronymic
            };

            var json = JsonConvert.SerializeObject(abonent);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var respone = await client.PutAsync($"http://localhost:5179/Abonent/{id}", content);
                respone.EnsureSuccessStatusCode();

                var responseContent = await respone.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Abonent>(responseContent);
            }
        }

        public static async Task<User?> DeleteAbonent(int id)
        {
            using (var client = new HttpClient())
            {
                var result = client.DeleteAsync($"http://localhost:5179/Abonent/{id}").Result;
                return result.StatusCode == System.Net.HttpStatusCode.OK
                    ? JsonConvert.DeserializeObject<User>(await result.Content.ReadAsStringAsync())
                    : null;
            }
        }
    }
}
