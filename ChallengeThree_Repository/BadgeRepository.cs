using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_Repository
{
    public class BadgeRepository
    {
        // Key in dictionary = BadgeID
        // Value in dictionary = BadgeName
        private Dictionary<int, Badge> _idNames = new Dictionary<int, Badge>();

        //List of badges
        List<Badge> _listOfBadges = new List<Badge>();

        //Create
        public void AddBadgeToList(Badge badge)
        {
            _listOfBadges.Add(badge);
        }
        public void AddBadgeToDictionary(Badge newBadge)
        {
            _idNames.Add(newBadge.BadgeID, newBadge);
        }

        //Read
        public Dictionary<int, Badge> GetBadgeDictionary()
        {
            return _idNames;
        }
        public List<Badge> GetBadgeLists()
        {
            return _listOfBadges;
        }
        public Dictionary<int, Badge> AccessDictionaryElements()
        {
            return _idNames;
        }
        //Update
        public bool UpdateDictionary(int originalBadge, Badge newBadge)
        {
            Badge oldBadge = GetBadgeByBadgeID(originalBadge);

            if (oldBadge != null)
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.DoorName = newBadge.DoorName;
                oldBadge.BadgeName = newBadge.BadgeName;
            }
            return false;
        }

        //Delete
        public void RemoveDoorName(Badge doorName)
        {
            _listOfBadges.Remove(doorName);
        }

        //helper
        public Badge GetBadgeByBadgeID(int badgeID)
        {
            foreach (KeyValuePair<int, Badge> badge in _idNames)
            {
                if (badge.Key == badgeID)
                {
                    return badge.Value;
                }
            }
            return null;
        }
    }
}
