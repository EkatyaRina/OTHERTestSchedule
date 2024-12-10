using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TestSchedule.Model;

namespace TestSchedule.Controller
{
    public class MainWindowController
    {
        private readonly string _url = "https://api.adygnet.ru/v1/education/unsecured/schedules/";

        public async Task<List<Schedule>> GetSchedule(string groupName, string facultyName)
        {
            try
            {
                using (HttpClient client = new())
                {
                    var url = _url + $"students?facultyName={facultyName}&groupName={groupName}";

                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    client.DefaultRequestHeaders.Add("X-API-KEY", " MAKLKTAfbUBQZSx8l8ZLI8YfU8yItul4");

                    var result = await client.GetAsync(url);

                    if (result.IsSuccessStatusCode)
                    {
                        var endResult = await JsonSerializer.DeserializeAsync<List<Schedule>>(await result.Content.ReadAsStreamAsync());

                        return endResult;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<string>> GetGroups(string facultyName)
        {
            try
            {
                using (HttpClient client = new())
                {
                    var url = _url + $"facilities/groups?facility={facultyName}";

                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    client.DefaultRequestHeaders.Add("X-API-KEY", " MAKLKTAfbUBQZSx8l8ZLI8YfU8yItul4");

                    var result = await client.GetAsync(url);

                    if (result.IsSuccessStatusCode)
                    {
                        var endResult = await JsonSerializer.DeserializeAsync<List<string>>(await result.Content.ReadAsStreamAsync());

                        return endResult;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
    }
}
