using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BadgeLibrary
{
    public class BadgeRepository
    {
        private readonly Dictionary<int, List<string>> _repo = new Dictionary<int, List<string>>();
        public bool AddBadge(Badge content) // Create a new badge
        {
            int startingCount = _repo.Count;
            _repo.Add(content.BadgeID, content.Doors);
            return _repo.Count > startingCount;
        }
        public Dictionary<int, List<string>> ListBadges() // Read: List all badges
        {
            return _repo;
        }

        public List<string> GetDoorsByID(int badgeID) // Get doors by badge ID
        {

            foreach(KeyValuePair<int, List<string>> target in _repo) // Look through our collection of badges
            { 
                if(target.Key == badgeID) { return target.Value; } // Return the doors if we find a badge with that ID
            }
            return null; // Return null if we don't have a badge with that ID
        }

        public bool EditBadge(int originalBadgeID, string addedDoor) // Add a door to a badge --- finds the door with the integer, and adds a string to the list of doors
        {
            List<string> oldDoors = GetDoorsByID(originalBadgeID);
            foreach(KeyValuePair<int, List<string>> target in _repo) // Look through our collection of badges
            { 
                if(target.Key == originalBadgeID) // If the badge they specified by ID is in the collection
                { 
                    _repo.Values.Add(addedDoor); // Then add the specified door to the list of Strings
                }  
                
                // Return the doors
            }
            
            
        }

        //         // Update
        // public bool UpdateExistingContent(string originalTitle, StreamingContent newContent)
        // {
        //     // Find the original content
        //     StreamingContent oldContent = GetContentByTitle(originalTitle);

        //     // If we find it, replace it

        //     if(oldContent != null)
        //     {
        //         oldContent.Title = newContent.Title;
        //         oldContent.Description = newContent.Description;
        //         oldContent.MaturityRating = newContent.MaturityRating;
        //         oldContent.StarRating = newContent.StarRating;
        //         oldContent.RunTimeInMinutes = newContent.RunTimeInMinutes;
        //         // oldContent.IsFamilyFriendly = newContent.IsFamilyFriendly;

        //         return true;
        //     }

        //     // If we cannot find it, say so

        //     return false;

        // }
    }
}