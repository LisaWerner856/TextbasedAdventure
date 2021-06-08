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
        public string[] CanBeUsedOn { get; private set; }
        public string[] CanBeUsedByAction { get; private set; }
        public int Ammount { get; private set; }

        public Item(string itemName, string itemDesicription, int ammount = 1)
        {
            Name = itemName;
            Description = itemDesicription;
            Ammount = ammount;
        }

        public string GetItemName()
        {
            return Name.ToLower();
        }

	}
}
