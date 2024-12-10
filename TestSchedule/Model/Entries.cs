using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestSchedule.Model
{
    public class Entries
    {
        [JsonPropertyName("dayOfWeek")]
        public string? DayOfWeek { get; set; }
        [JsonPropertyName("pairNumber")]
        public string? PairNumber { get; set; }
        [JsonPropertyName("time")]
        public string? Time { get; set; }
        [JsonPropertyName("teacher")]
        public string? Teacher { get; set; }
        [JsonPropertyName("room")]
        public string? Room { get; set; }
        [JsonPropertyName("subject")]
        public string? Subject { get; set; }
        [JsonPropertyName("lessonType")]
        public string? LessonType { get; set; }


        public bool IsAnyFieldNotEmpty()
        {
            return !(string.IsNullOrEmpty(Teacher) &&
                     string.IsNullOrEmpty(Room) &&
                     string.IsNullOrEmpty(Subject) &&
                     string.IsNullOrEmpty(LessonType));
        }
    }
}
