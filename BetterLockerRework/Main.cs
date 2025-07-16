using Exiled.API.Enums;
using Exiled.API.Features;
using HarmonyLib;
using System;
using Server = Exiled.Events.Handlers.Server;

namespace BetterLockers
{
	public class Main : Plugin<Config>
	{
		private Harmony _harmony;
		private static readonly Main Singleton = new();
		public override string Author => "YannikAufDie1";
		public override PluginPriority Priority { get; } = PluginPriority.Last;
		public static Main Instance => Singleton;
		public override void OnEnabled()
		{
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
