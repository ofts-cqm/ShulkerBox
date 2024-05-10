using StardewModdingAPI;

namespace ShulkerBox
{
    public class ModEntry : Mod
    {
        public static ModEntry? Instance;
        public static ModConfig Config = new();

        public override void Entry(IModHelper helper)
        {
            Instance = this;
            Config = Helper.ReadConfig<ModConfig>();
        }
    }

    public class ModConfig
    {

    }
}