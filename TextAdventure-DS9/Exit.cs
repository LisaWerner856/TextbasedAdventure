using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure_DS9
{
    class Exit
    {
        public Location LeadsTo { get; private set; }

		public Exit(Location leadsto)
		{
            LeadsTo = leadsto;
		}
	}
}
