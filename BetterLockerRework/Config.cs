using Exiled.API.Interfaces;
using MapGeneration.Distributors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Core;

namespace BetterLockers
{
	public sealed class Config : IConfig
	{
		public bool IsEnabled { get; set; } = true;
		public bool Debug { get; set; }

		[Description("Stop basegame items from spawning in lockers. StructureTypes that are not in this list will default to false (StandardLocker, LargeGunLocker, ScpPedestal, SmallWallCabinet, ExperimentalWeaponLocker)")]
		public Dictionary<StructureType, bool> DisableBaseGameItems { get; set; } = new Dictionary<StructureType, bool>()
		{
			[StructureType.StandardLocker] = true,
		};

		[Description("Available types: StandardLocker, LargeGunLocker, ScpPedestal, SmallWallCabinet, ExperimentalWeaponLocker")]
		public Dictionary<StructureType, List<Spawner>> LockerSpawns { get; set; } = new Dictionary<StructureType, List<Spawner>>()
		{
			[StructureType.StandardLocker] = new List<Spawner>
			{
				new Spawner
				{
					item = ItemType.GunCOM15.ToString(),
					amount = 1,
					chance = 20,
					maxamountinlocker = 1,
				},
				new Spawner
				{
					item = ItemType.KeycardGuard.ToString(),
					amount = 1,
					chance = 20,
					maxamountinlocker = 1,
				}
			},
			[StructureType.LargeGunLocker] = new List<Spawner>
			{
				new Spawner
				{
					item = ItemType.MicroHID.ToString(),
					amount = 1,
					chance = 1,
					maxamountinlocker = 1,
				}
			},
			[StructureType.ExperimentalWeaponLocker] = new List<Spawner>
			{
				new Spawner
				{
					item = ItemType.MicroHID.ToString(),
					amount = 1,
					chance = 100,
					maxamountinlocker = 1,
				}
			}
		};

		[Description("Keep this off unless you want your console spammed.")]
		public bool DebugMode { get; set; } = false;
	}
}
