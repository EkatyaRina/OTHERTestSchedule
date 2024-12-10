using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSchedule.Core
{
    public static class FacultySingleton
    {
        public static Dictionary<int, string> FacultyList { get; set; } = new Dictionary<int, string>
{
    { 1, "Инженерно-физический факультет" },
    { 2, "Институт искусств" },
    { 3, "Институт физической культуры и дзюдо" },
    { 4, "Международный факультет" },
    { 5, "Исторический факультет" },
    { 6, "Факультет адыгейской филологии и культуры" },
    { 7, "Факультет естествознания" },
    { 8, "Факультет иностранных языков" },
    { 9, "Факультет математики и компьютерных наук" },
    { 10, "Факультет педагогики и психологии" },
    { 11, "Факультет социальных технологий и туризма" },
    { 12, "Филологический факультет" },
    { 13, "Экономический факультет" },
    { 14, "Юридический факультет" }
};
    }
}
