using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterLockers
{
	public class Spawner
	{
		public string item { get; set; }
		public int chance { get; set; }
		public int amount { get; set; }
		public int maxamountinlocker { get; set; }
		public bool uciitem { get; set; } = false;
	}
}
