using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_Repository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public string DoorName { get; set; } 
        public string BadgeName { get; set; }

        public Badge() { }

        public Badge(int badgeID, string doorName, string badgeName)
        {
            BadgeID = badgeID;
            DoorName = doorName;
            BadgeName = badgeName;
        }
    }
}
