using BetterLockers;
using Exiled.API.Features;
using HarmonyLib;
using MapGeneration.Distributors;
using System.Linq;

[HarmonyPatch(typeof(Locker), nameof(Locker.FillChamber))]
public static class LockerFillChamberPatch
{
	public static bool Prefix(Locker __instance, LockerChamber ch)
	{
		var cfg = Main.Instance.Config;

		bool blockVanilla = cfg.DisableBaseGameItems.TryGetValue(__instance.StructureType, out bool destroy) && destroy;

		if (!blockVanilla)
		{
			return true; 
		}

		if (cfg.LockerSpawns.TryGetValue(__instance.StructureType, out var spawnerList) && spawnerList.Count > 0)
		{
			var shuffledList = spawnerList.OrderBy(_ => UnityEngine.Random.value).ToList();

			foreach (var spawner in shuffledList)
			{
				int existingCount = 0;

				foreach (var chamber in __instance.Chambers)
				{
					existingCount += chamber.Content.Count(item => item != null && item.ItemId.TypeId == spawner.item);
				}

				if (spawner.maxamountinlocker > 0 && existingCount >= spawner.maxamountinlocker)
				{
					if (cfg.DebugMode)
						Log.Info($"[LockerFillPatch] Skipped {spawner.item} in {__instance.StructureType}: MaxAmountInLocker {spawner.maxamountinlocker} reached.");
					continue;
				}

				if (UnityEngine.Random.Range(1, 101) <= spawner.chance)
				{
					ch.SpawnItem(spawner.item, spawner.amount);

					if (cfg.DebugMode)
						Log.Info($"[LockerFillPatch] Spawned {spawner.item} x{spawner.amount} in {__instance.StructureType}.");
				}
				break;
			}

			return false;
		}

		return false;
	}
}
