using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_OOP2
{
    public static class ElectionManager
    {
        // 1. Storage for the "Current" Election
        public static string CurrentTitle { get; set; }
        public static DateTime StartDate { get; set; }
        public static DateTime EndDate { get; set; }
        public static bool IsSetup { get; set; }

        // 2. Logic to determine the Status String
        public static string GetStatus()
        {
            DateTime now = DateTime.Now;

            if (now < StartDate)
                return "UPCOMING";
            else if (now >= StartDate && now <= EndDate)
                return "ACTIVE";
            else
                return "COMPLETED";
        }

        // 3. Logic to determine the Color
        public static Color GetStatusColor()
        {
            string status = GetStatus();
            if (status == "UPCOMING") return Color.Orange;
            if (status == "ACTIVE") return Color.Green;
            return Color.Maroon; // For Completed
        }
    }
}
