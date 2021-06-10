using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure_DS9
{
    class Location
    {
        /// <summary>
        /// List of items at the location.
        /// </summary>
        public List<Item> Items { get; private set; }

        /// <summary>
        /// LocaionName
        /// </summary>
        public string LocationName { get; private set; }

        /// <summary>
        /// Location description to be displayed. 
        /// </summary>
        public string[] Description { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Exit> Exits { get; private set; }

        public int LocationIndex { get; private set; }
        /// <summary>
        /// Location constructor.
        /// </summary>
        /// <param name="locationName">Name of the location.</param>
        /// <param name="locationDescription">Array of strings to describe the location.</param>
        /// <param name="locationIndex">The index of the location.</param>
        /// <param name="itemsAtLocation">A list of items that are at the location.</param>
        public Location(string locationName, string[] locationDescription, int locationIndex, List<Item> itemsAtLocation)
        {
            LocationName = locationName;
            Description = locationDescription;
            LocationIndex = locationIndex;
            Exits = new List<Exit>();
            Items = itemsAtLocation;
        }

        public void AddExit(Exit exit)
        {
            Exits.Add(exit);
        }
        public void AddExit(List<Exit> exits)
        {
            foreach (Exit exit in exits)
            {
                Exits.Add(exit);
            }
        }

        /// <summary>
        /// Writes location and items at the location to the console.
        /// </summary>
        public void ShowLocation()
        {
            // Location description
            Console.WriteLine($"{LocationName}");
            for (int i = 0; i < Description.Length; i++)
            {
                Console.WriteLine($"{Description[i]}");
            }

            if (Items != null)
            {
                // Show items at location
                for (int i = 0; i < Items.Count; i++)
                {
                    Console.WriteLine(Items[i].Description);
                }
            }
            else
            {
                Console.WriteLine("You don't see anything of interesst here.");
            }
            if (Exits != null)
            {
                foreach  (Exit exit in Exits)
                {
                    Console.WriteLine(exit.LeadsTo.LocationName);
                }
            }

        }


        public Item RemoveItem(string itemToRemove)
        {
            foreach (Item item in Items)
            {
                if (item.Name.ToLower() == itemToRemove)
                {
                    Items.Remove(item);
                    return item;
                }
            }

            return null;
        }
    }
}
