using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure_DS9
{
    class Interactable
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string[] InteractionDescription { get; private set; }

        public bool interactedWith = false;

        public Interactable(string itemName, string itemDesicription, string[] interactionDescription)
        {
            Name = itemName;
            Description = itemDesicription;
            InteractionDescription = interactionDescription;
        }
    }
}
