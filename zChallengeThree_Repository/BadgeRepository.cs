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
        Dictionary<int, Badge> _idNames = new Dictionary<int, Badge>();

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
        

        //Delete
        public void RemoveDoorName(Badge doorName)
        {
            _listOfBadges.Remove(doorName);
        }
    }
}
