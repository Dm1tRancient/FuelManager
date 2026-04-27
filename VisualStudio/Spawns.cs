namespace FuelManager
{
    internal static class Spawns
    {
        internal static void AddToModComponent()
        {
            GearSpawner.SpawnTagManager.AddFunction("FuelManager", GetProbability);
        }

        private static float GetProbability(GearSpawner.DifficultyLevel difficultyLevel, GearSpawner.FirearmAvailability firearmAvailability, GearSpawner.GearSpawnInfo gearSpawnInfo)
        {
            if (gearSpawnInfo.PrefabName != "GEAR_GasCan" || gearSpawnInfo.PrefabName != "GEAR_GasCanFull") return 0f;
            return difficultyLevel switch
            {
                GearSpawner.DifficultyLevel.Pilgram => Settings.Instance.pilgramSpawnExpectation,
                GearSpawner.DifficultyLevel.Voyager => Settings.Instance.voyagerSpawnExpectation,
                GearSpawner.DifficultyLevel.Stalker => Settings.Instance.stalkerSpawnExpectation,
                GearSpawner.DifficultyLevel.Interloper => Settings.Instance.interloperSpawnExpectation,
                GearSpawner.DifficultyLevel.Challenge => Settings.Instance.challengeSpawnExpectation,
                _ => 0f,
            };
        }
    }
}
