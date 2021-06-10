using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure_DS9
{
    class Item
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Useable { get; private set; }
        public string UsingDescription { get; private set; }
        public string UsingCommand { get; private set; }
        public string[] CanBeUsedOn { get; private set; }
        public string[] CanBeUsedByAction { get; private set; }

        public Item(string itemName, string itemDesicription, bool useable, string useDescription = "")
        {
            Name = itemName;
            Description = itemDesicription;
            Useable = useable;
            UsingDescription = useDescription;
        }

        /// <summary>
        /// Returns the name of this item.
        /// </summary>
        /// <returns>Lowercase string</returns>
        public string GetNameLowercase()
        {
            return Name.ToLower();
        }

	}
}
