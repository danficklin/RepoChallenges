using System;
using System.Collections.Generic;

namespace BadgeLibrary
{
    public class Badge
    {
        public Badge(){}
        public Badge(int badgeID, List<string> doors, string name)
        {
            BadgeID = badgeID;
            Doors = doors;
            Name = name;
        }
        public int BadgeID { get; set; }
        public List<string> Doors { get; set; }
        public string Name { get; set; }
    }
}
