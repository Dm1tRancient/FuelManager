using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MelonLoader.Utils;

namespace FuelManager
{
	internal class Setup
	{
		public static List<string> PossibleMCFiles =
		[
			Path.Combine(MelonEnvironment.ModsDirectory, "FuelManager.modcomponent"),
			Path.Combine(MelonEnvironment.ModsDirectory, "FuelManager.ModdersGearToolbox.modcomponent"),
			Path.Combine(MelonEnvironment.ModsDirectory, "FuelManager.Shared.modcomponent")
		];
		/// <summary>ttt</summary>
		/// <value>Left = whats required, right = which part of this mod requires left</value>
		public static Dictionary<string, string> Dependencies = new()
		{
			{ Path.Combine(MelonEnvironment.ModsDirectory, "AHandyToolbox.modcomponent"), Path.Combine(MelonEnvironment.ModsDirectory, "FuelManager.ModdersGearToolbox.modcomponent") }
		};
		public static bool VerifyMCFiles()
		{
			int result = 0;
			bool shared = File.Exists(PossibleMCFiles[2]);
			bool @default = File.Exists(PossibleMCFiles[0]);
			bool GearAddon = File.Exists(PossibleMCFiles[1]);

			bool gear = File.Exists(Path.Combine(MelonEnvironment.ModsDirectory, "AHandyToolbox.modcomponent"));

			if (!shared) result++;
			if (!@default && !GearAddon) result++;

			if (result > 0)
			{
				Main.Logger.Log($"Mod not installed properly! Following lines will describe what is missing", FlaggedLoggingLevel.Warning);
			}
			if (!shared)
			{
				Main.Logger.Log($"Shared MC file is missing", FlaggedLoggingLevel.Warning);
			}
			if (!@default && !GearAddon)
			{
				Main.Logger.Log($"Neither the default nor the ModdersGearToolbox MC was found", FlaggedLoggingLevel.Warning);
			}
			if (GearAddon && !gear)
			{
				Main.Logger.Log($"ModdersGearToolbox MC was found but the required mod is not installed!", FlaggedLoggingLevel.Warning);
			}
			if (gear && !GearAddon)
			{
				Main.Logger.Log($"AHandyToolbox MC was found but the ModdersGearToolbox MC is not installed. It is recommended to swap to this addon", FlaggedLoggingLevel.Verbose);
			}
			if (result > 0)
			{
				Main.Logger.Log("Setup verification complete", FlaggedLoggingLevel.Debug);
			}

			return result == 0;
		}
	}
}
