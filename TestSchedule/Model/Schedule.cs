using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestSchedule.Model
{
    public class Schedule
    {
        [JsonPropertyName("dayOfWeek")]
        public string DayOfWeek { get; set; }
        [JsonPropertyName("entries")]
        public List<Entries> EntryList { get; set; }

       
    }
}
