using Exiled.API.Enums;
using Exiled.API.Features;
using HarmonyLib;
using System;
using static PlayerList;
using Server = Exiled.Events.Handlers.Server;

namespace BetterLockers
{
	public class Main : Plugin<Config>
	{
		private Harmony _harmony;
		public static Main Instance { get; private set; }
		public override string Author => "YannikAufDie1";
		public override PluginPriority Priority { get; } = PluginPriority.Last;
		public override void OnEnabled()
		{
			Instance = this;
			_harmony = new Harmony("lockerrework.yannik");
			_harmony.PatchAll();
			base.OnEnabled();
		}

		public override void OnDisabled()
		{
			_harmony.UnpatchAll("lockerrework.yannik");
			base.OnDisabled();
		}
	}
}
